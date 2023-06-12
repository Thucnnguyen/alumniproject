﻿using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;
using AlumniProject.Service;
using AlumniProject.Ultils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlumniProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService service;
        private readonly IMapper mapper;
        private readonly TokenUltil tokenUltil;
        public MajorController(IMajorService majorService, IMapper mapper)
        {
            this.service = majorService;
            this.mapper = mapper;
            tokenUltil = new TokenUltil();
        }


        [HttpGet("alumni/majors"), Authorize(Roles = "tenant,alumni")]
        public async Task<ActionResult<IEnumerable<MajorDTO>>> GetMajorByAlumniId()
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
                var alumniId = tokenUltil.GetClaimByType(User, Constant.AlumniId).Value;
                var majorList = await service.GetMajorByAlumniId(int.Parse(alumniId));
                if(majorList == null || majorList.Count() == 0)
                {
                    return NoContent();
                }
                var majorDtoList = majorList.Select(m => mapper.Map<MajorDTO>(m));
                return Ok(majorDtoList);
            }catch(Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return BadRequest(e.Message);
                }
            }
        }
        [HttpPost("alumni/majors"), Authorize(Roles = "tenant,alumni")]
        public async Task<ActionResult<int>> CreateMajor([FromBody]MajorAddDto majorAddDto)
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
                var alumniId = tokenUltil.GetClaimByType(User, Constant.AlumniId).Value;
                Major major = mapper.Map<Major>(majorAddDto);
                major.AlumniId = int.Parse(alumniId);
                var majorId = await service.CreateMajor(major);
                return Ok(majorId);
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return BadRequest(e.Message);
                }
            }
        }
        [HttpPut("alumni/majors"), Authorize(Roles = "tenant,alumni")]
        public async Task<ActionResult<MajorDTO>> UpdateMajor([FromBody] MajorUpdateDTO majorUpdateDTO)
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
                var alumniId = tokenUltil.GetClaimByType(User, Constant.AlumniId).Value;
                Major major = mapper.Map<Major>(majorUpdateDTO);
                major.AlumniId = int.Parse(alumniId);
                var majorUpdate = await service.UpdateMajor(major);
                return Ok(mapper.Map<MajorDTO>(major));
            }catch(Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpDelete("alumni/majors"), Authorize(Roles = "tenant,alumni")]
        public async Task<ActionResult<string>> DeleteMajor([FromQuery] int majorId)
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
                await service.DeleteMajor(majorId);
                return Ok("Deleted  Success!");
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}
