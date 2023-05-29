using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService service;
        private readonly IMapper mapper;
        public GradeController(IGradeService gradeService, IMapper mapper)
        {
            this.service = gradeService;
            this.mapper = mapper;
        }


        [HttpGet("{schoolId}/{pageNo}/{pageSize}")]
        public async Task<ActionResult<PagingResultDTO<GradeDTO>>> GetGrades(
            [FromRoute, Required(ErrorMessage = "SchoolId is Required")] int schoolId,
            [FromRoute] int pageNo = 1,
            [FromRoute] int pageSize= 10
            )
        {
            try
            {
                

                var GradeList = await service.GetGradePagingResults( pageNo, pageSize, schoolId);
                var GradeDTOList = new PagingResultDTO<GradeDTO>
                {
                    Items = GradeList.Items.Select(g => mapper.Map<GradeDTO>(g)).ToList(),
                    CurrentPage = GradeList.CurrentPage,
                    PageSize = GradeList.PageSize,
                    TotalItems = GradeList.TotalItems
                };
                return Ok(GradeDTOList);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateGrade(GradeAddDTO gradeAddDTO)
        {
            try
            {
                var gradeId = await service.CreateGrade(mapper.Map<Grade>(gradeAddDTO));
                return Ok(gradeId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<GradeDTO>> UpdateGrade(GradeUpdateDTO gradeUpdateDTO)
        {
            try
            {
                var gradeUpdate = await service.UpdateGrade(mapper.Map<Grade>(gradeUpdateDTO));
                return Ok(mapper.Map<GradeDTO>(gradeUpdate));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
