using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;
using AlumniProject.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService service;
        private readonly IMapper mapper;
        public ClassController(IClassService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("tenant/classes"),Authorize(Roles ="tenant")]
        public async Task<ActionResult<PagingResultDTO<AlumniClassDTO>>> GetClasses(
            [FromQuery, Required(ErrorMessage = "GradeId is Required")] int gradeId,
            [FromQuery, Range(1, int.MaxValue),Required(ErrorMessage = "pageNo is Required")] int pageNo = 1,
            [FromQuery, Range(1, int.MaxValue),Required(ErrorMessage = "pageSize is Required")] int pageSize = 10
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
                var AlumniClass = await service.GetClassPagingResults(pageNo, pageSize,gradeId);
                
                return Ok(AlumniClass);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet("alumni/classes")]
        public async Task<ActionResult<IEnumerable<AlumniClassDTO>>> GetClassesByGradeId(
            [FromQuery, Required(ErrorMessage = "GradeId is Required")] int gradeId
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
                var alumniClass = await service.GetClassByGradeId(gradeId);
                var alumniClassDTOs = alumniClass.Select(a => mapper.Map<AlumniClassDTO>(a));
                return Ok(alumniClassDTOs);
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
                return BadRequest(e.Message);
            }
        }
        [HttpPost("tenant/classes"), Authorize(Roles = "tenant")]
        public async Task<ActionResult<int>> CreateClass([FromBody]ClassAddDto alumniClassAddDTO)
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
                var classId = await service.CreateClass(mapper.Map<AlumniClass>(alumniClassAddDTO));
                return Ok(classId);
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
        [HttpPut("tenant/classes"), Authorize(Roles = "tenant")]
        public async Task<ActionResult<AlumniClassDTO>> UpdateAlumniClass([FromBody] AlumniClassUpdateDTO alumniClassUpdateDTO)
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
                var alumniClass = mapper.Map<AlumniClass>(alumniClassUpdateDTO);
                var AlumniUpdate = await service.UpdateClass(alumniClass);
                return Ok(mapper.Map<AlumniClassDTO>(AlumniUpdate));
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
        [HttpDelete("tenant/classes/{classId}"), Authorize(Roles = "tenant")]
        public async Task<ActionResult<string>> DeleteClassById([FromRoute] int classId)
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
                await service.DeleteClassById(classId);
                return Ok("Deleted class successful with id: "+ classId);
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
