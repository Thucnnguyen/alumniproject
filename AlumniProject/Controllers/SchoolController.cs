using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;
using AlumniProject.Service;
using AlumniProject.Ultils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IAlumniService _alumniService;
        private readonly IMapper mapper;
        private readonly TokenUltil tokenUltil;


        public SchoolController(ISchoolService schoolService, IMapper mapper,IAlumniService alumniService)
        {
            this._schoolService = schoolService;
            this.mapper = mapper;
            tokenUltil = new TokenUltil();
            this._alumniService = alumniService; 
        }

        [HttpGet("alumni/schools/subDomain")]
        public async Task<ActionResult<SchoolDTO>> GetSchoolByDomain([FromQuery] string subDomain)
        {
            var school = await _schoolService.GetSchoolBySubDomain(subDomain);
            if (school == null)
            {
                return NotFound("School not found with SubDomain: " + subDomain);
            }
            return Ok(mapper.Map<SchoolDTO>(school));
        }
        [HttpGet("admin/schools"),Authorize(Roles ="admin")]
        public async Task<ActionResult<PagingResultDTO<SchoolDTO>>> GetAllSchool(
             [FromQuery, Range(1, int.MaxValue), Required(ErrorMessage = "pageNo is Required")] int pageNo = 1,
             [FromQuery, Range(1, int.MaxValue), Required(ErrorMessage = "pageSize is Required")] int pageSize = 10
            )
        {
            try
            {
                var errorMessages = ModelState.Values
                  .SelectMany(v => v.Errors)
                  .Select(e => e.ErrorMessage)
                  .ToList();
                if (errorMessages.Any())
                {
                    return BadRequest(string.Join(", ", errorMessages));
                }
                var SchoolsList = await _schoolService.GetSchools(pageNo, pageSize);
                var SchoolListDto = SchoolsList.Items.Select(s => mapper.Map<SchoolDTO>(s)).ToList();
                var result = new PagingResultDTO<SchoolDTO>()
                {   
                    Items = SchoolListDto,
                    CurrentPage = SchoolsList.CurrentPage,
                    PageSize = SchoolsList.PageSize,
                    TotalItems =SchoolsList.TotalItems
                };
                return Ok(result);
            }
            catch (Exception e)
            {

                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else if (e is BadRequestException)
                {
                    return BadRequest(e.Message);
                }
                else
                {
                    return Conflict(e.Message);
                }
            }
        }

        [HttpGet("alumni/schools"),Authorize(Roles ="tenant,alumni")]
        public async Task<ActionResult<SchoolDTO>> GetSchoolById()
        {
            try
            {
                var schoolId = tokenUltil.GetClaimByType(User, Constant.SchoolId).Value;
                var school = await _schoolService.GetSchoolById(int.Parse(schoolId));
                if (school == null)
                {
                    return NotFound("School not found with ID: " + int.Parse(schoolId));
                }
                return Ok(mapper.Map<SchoolDTO>(school));
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else if (e is BadRequestException)
                {
                    return BadRequest(e.Message);
                }
                else
                {
                    return Conflict(e.Message);
                }
            }

        }
        [HttpPost("tenant/schools"), Authorize(Roles = "alumni")]
        public async Task<ActionResult<int>> AddSchool(SchoolAddDTO schoolAddDTO)
        {
            try
            {
                var errorMessages = ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage)
                   .ToList();
                if (errorMessages.Any())
                {
                    return BadRequest(string.Join(", ", errorMessages));
                }
                var schoolId = tokenUltil.GetClaimByType(User, Constant.SchoolId).Value;
                if(int.Parse(schoolId) != -1)
                {
                    return Conflict("An account can only create one account");
                }
                var schoolIdNew = await _schoolService.AddSchool(mapper.Map<School>(schoolAddDTO));
                var alumniId = tokenUltil.GetClaimByType(User, Constant.AlumniId).Value;
                Alumni alumni = await _alumniService.GetById(int.Parse(alumniId));
                
                alumni.schoolId = schoolIdNew;
                alumni.IsOwner = true;
                await _alumniService.UpdateAlumni(alumni);
                return Ok(schoolIdNew);
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else if (e is BadRequestException)
                {
                    return BadRequest(e.Message);
                }
                else
                {
                    return Conflict(e.Message);
                }
            }
        }
        [HttpPut("tenant/schools"), Authorize(Roles = "tenant")]
        public async Task<ActionResult<SchoolDTO>> UpdateSchool(SchoolUpdateDto schoolUpdateDto)
        {
            try
            {
                var errorMessages = ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage)
                   .ToList();
                if (errorMessages.Any())
                {
                    return BadRequest(string.Join(", ", errorMessages));
                }
                var schoolId = tokenUltil.GetClaimByType(User, Constant.SchoolId).Value;

                School schoolUpdate = mapper.Map<School>(schoolUpdateDto);
                schoolUpdate.Id = int.Parse(schoolId);
                var school = await _schoolService.UpdateSchool(schoolUpdate);
                return Ok(mapper.Map<SchoolDTO>(school));
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else if (e is BadRequestException)
                {
                    return BadRequest(e.Message);
                }
                else
                {
                    return Conflict(e.Message);
                }
            }
        }
        [HttpPut("admin/schools/status"), Authorize(Roles = "admin")]

        public async Task<ActionResult<SchoolDTO>> UpdateSchoolStatus(UpdateSchoolStatusDTO updateSchoolStatusDTO)
        {
            try
            {
                var errorMessages = ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage)
                   .ToList();
                if (errorMessages.Any())
                {
                    return BadRequest(string.Join(", ", errorMessages));
                }
                var school = await _schoolService.UpdateSchoolStatus(updateSchoolStatusDTO.Id,updateSchoolStatusDTO.RequestStatus);
                return Ok(mapper.Map<SchoolDTO>(school));
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else if (e is BadRequestException)
                {
                    return BadRequest(e.Message);
                }
                else
                {
                    return Conflict(e.Message);
                }
            }
        }
    }
}
