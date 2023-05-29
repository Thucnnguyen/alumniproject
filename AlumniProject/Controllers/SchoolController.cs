using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniProject.Controllers
{
    [Route("api/schools")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IMapper mapper;
        public SchoolController(ISchoolService schoolService, IMapper mapper)
        {
            this._schoolService = schoolService;
            this.mapper = mapper;
        }

        [HttpGet("/subdomain/{subDomain}")]
        public async Task<ActionResult<SchoolDTO>> GetSchoolByDomain([FromRoute] string subDomain )
        {
            var school = await _schoolService.GetSchoolBySubDomain(subDomain);
            if(school == null)
            {
                return NotFound("School not found with SubDomain: " + subDomain);
            }
            return Ok(mapper.Map<SchoolDTO>(school));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDTO>> GetSchoolById([FromRoute] int id)
        {
            var school = await _schoolService.GetSchoolById(id);
            if (school == null)
            {
                return NotFound("School not found with ID: " + id);
            }
            return Ok(mapper.Map<SchoolDTO>(school));
        }
        [HttpPost]
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
                var schoolId = await _schoolService.AddSchool(mapper.Map<School>(schoolAddDTO));
                return Ok(schoolId);
            }catch( Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<int>> UpdateSchool(SchoolUpdateDto schoolUpdateDto)
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
                var school = await _schoolService.UpdateSchool(mapper.Map<School>(schoolUpdateDto));
                return Ok(mapper.Map<SchoolDTO>(school));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
