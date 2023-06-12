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
    public class RequestToSchoolController : ControllerBase
    {
        private readonly IAlumniRequestService _alumniRequestService;
        private readonly IMapper mapper;
        private readonly TokenUltil tokenUltil;
        public RequestToSchoolController(IAlumniRequestService alumniRequestService, IMapper mapper)
        {
            this._alumniRequestService = alumniRequestService;
            this.mapper = mapper;
            tokenUltil = new TokenUltil();
        }

        [HttpGet("tenant/accessReqeuest"),Authorize(Roles ="tenant")]
        public async Task<ActionResult<PagingResultDTO<AccessRequestDTO>>> GetAccessRequestBySchoolId(
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
                var schoolId = tokenUltil.GetClaimByType(User, Constant.SchoolId).Value;
                var AccessRequestList = await _alumniRequestService.GetAccessRequestsByScchoolId(pageNo, pageSize, int.Parse(schoolId));
                if (AccessRequestList == null)
                {
                    return NoContent();
                }
                var AccessRequestDtoList = new PagingResultDTO<AccessRequestDTO>()
                {
                    CurrentPage = AccessRequestList.CurrentPage,
                    PageSize = AccessRequestList.PageSize,
                    TotalItems = AccessRequestList.TotalItems,
                    Items = AccessRequestList.Items.Select(i => mapper.Map<AccessRequestDTO>(i)).ToList()
                };
                return Ok(AccessRequestDtoList);
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

        [HttpPost("alumni/accessReqeuest")]
        public async Task<ActionResult<int>> CreateAccessRequest([FromBody] AccessRequestAddDTO accessRequestAddDTO)
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
                var request = mapper.Map<AccessRequest>(accessRequestAddDTO);
                var accessrequestId = await _alumniRequestService.CreateAlumniRequest(request);
                return Ok(accessrequestId);
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

        [HttpPut("tenant/accessReqeuest"),Authorize(Roles ="tenant")]
        public async Task<ActionResult<AccessRequestDTO>> updateAccessRequestStatus([FromBody] AccessRequestUpdateDTO accessRequestUpdateDTO)
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
                var updateStatus = await _alumniRequestService.UpdateAccessRequest(accessRequestUpdateDTO.Id, accessRequestUpdateDTO.RequestStatus);
                return Ok(mapper.Map<AccessRequestDTO>(updateStatus));
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
        [HttpDelete("tenant/accessReqeuest"),Authorize(Roles ="tenant")]
        public async Task<ActionResult<string>> deleteAccessRequestStatus([FromQuery] int requestId)
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
                 await _alumniRequestService.DeleteAccessRequest(requestId);
                return Ok("AccessRequest deleted successful with id: "+requestId);
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
