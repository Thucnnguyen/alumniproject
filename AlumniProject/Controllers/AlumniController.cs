using AlumniProject.Data;
using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.Service;
using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniProject.Controllers
{
    [Route("api/alumnis")]
    [ApiController]
    public class AlumniController : ControllerBase
    {
        IAlumniService service;
        IMapper mapper;
        public AlumniController(IAlumniService alumniService, IMapper mapper)
        {
            this.service = alumniService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PagingResultDTO<AlumniDTO>>> GetAlumni([FromQuery]int PageNo=1,[FromQuery] int PageSize=10)
        {
            PagingResultDTO<Alumni> alumniList = await service.GetAll(PageNo,PageSize);
            PagingResultDTO<AlumniDTO> alumniDTOs = new PagingResultDTO<AlumniDTO>
            {
                Items = alumniList.Items.Select(a => mapper.Map<AlumniDTO>(a)).ToList(),
                CurrentPage = alumniList.CurrentPage,
                PageSize = alumniList.PageSize,
                TotalItems = alumniList.TotalItems
            };
            return Ok(alumniDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alumni>> GetAlumniById([FromRoute] int id)
        {
            var alumni = await service.GetById(id);
            if(alumni == null)
            {
                return NotFound("Alumni not found with ID: " + id);
            }
            return Ok(mapper.Map<AlumniDTO>(alumni));
        }

       /* [HttpPost]
        public async Task<ActionResult<bool>> AddAlumni([FromBody] AlumniDTO alumniDTO)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(string.Join(", ", errorMessages));
            }
            else
            {
                var alumni = mapper.Map<Alumni>(alumniDTO);
                var isSuccess = await service.AddAlumni(alumni);
                return Ok(isSuccess);
            }
        }*/

        [HttpPut]
        public async Task<ActionResult<AlumniDTO>> UpdateAlumni([FromBody] AlumniUpdateDTO alumniUpdateDTO)
        {
            var alumni = await service.GetById(alumniUpdateDTO.Id);
            if (alumni == null)
            {
                return NotFound("Alumni not found with ID: " + alumniUpdateDTO.Id);
            }

            var updateAlumni = await service.UpdateAlumni(mapper.Map<Alumni>(alumniUpdateDTO));
            return Ok(mapper.Map<AlumniDTO>(updateAlumni));

        }
        /*[HttpPost("/auth/google")]
        public async Task<ActionResult<string>> GoogleSignIn([FromBody] GoogleSignInRequest request)
        {
            var token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.IdToken);

            string userId = token.Subject;
            string email = token.Claims["email"].ToString();
            if(email != null)
            {
                var existAlumni = service.GetAlumniByEmail(email);
                if(existAlumni == null)
                {
                    UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(userId);
                    string name = userRecord.DisplayName;
                    string phone = userRecord.PhoneNumber;
                    string avatar = userRecord.PhotoUrl;
                    

                }
                            
            }
            else
            {
                return Unauthorized("Token wrong");
            }
            
        }*/
    }
}
