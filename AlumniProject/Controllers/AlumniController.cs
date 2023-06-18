using AlumniProject.Data;
using AlumniProject.Dto;
using AlumniProject.Entity;
using AlumniProject.ExceptionHandler;
using AlumniProject.Service;
using AlumniProject.Service.ServiceImp;
using AlumniProject.Ultils;
using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumniController : ControllerBase
    {
        private readonly IAlumniService service;
        private readonly IConfiguration _configuration;
        private readonly IGradeService _gradeService;
        private readonly IRoleService _roleService;
        private readonly IMapper mapper;
        private readonly TokenUltil tokenUltil;

        public AlumniController(IAlumniService alumniService, IMapper mapper, IConfiguration configuration, IGradeService gradeService, IRoleService roleService)
        {
            this.service = alumniService;
            this.mapper = mapper;
            this._configuration = configuration;
            this._gradeService = gradeService;
            this._roleService = roleService;
            tokenUltil = new TokenUltil();
        }
        /* [HttpGet]
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
         }*/

        [HttpGet("alumnis"), Authorize(Roles = ("tenant,alumni"))]
        public async Task<ActionResult<AlumniDTO>> GetAlumniById()
        {
            var id = tokenUltil.GetClaimByType(User, Constant.AlumniId).Value;

            var alumni = await service.GetById(int.Parse(id));
            if (alumni == null)
            {
                return NotFound("Alumni not found with ID: " + id);
            }
            return Ok(mapper.Map<AlumniDTO>(alumni));
        }
        /*[HttpPost("alumnis/login")]
        public async Task<ActionResult<string>> login([FromBody] GoogleSignInRequest request)
        {
            var firebaseToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.IdToken);
            string email = firebaseToken.Claims["email"].ToString();
            if (email != null)
            {
                var alumni = await service.GetAlumniByEmail(email);
                if (alumni == null)
                {
                    return NotFound("Alumni not found with email: " + email);
                }
                var tokenHelper = new TokenHelper(_configuration, _gradeService, _roleService);
                var token = await tokenHelper.CreateToken(alumni);
                return Ok(token);

            }
            return BadRequest("Firebase Token has email not valid");

        }*/
        [HttpPost("alumnis/login")]
        public async Task<ActionResult<string>> login([FromQuery] string token)
        {
            var tokenHelper = new TokenHelper(_configuration, _gradeService, _roleService);

            try
            {
                //var alumni = await service.GetAlumniByEmail("");
                tokenHelper.DecodeJwtToken(token);
                //var token = await tokenHelper.CreateToken(alumni);
                return Ok("");
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                    //Alumni newAlumni = new Alumni()
                    //{
                    //    FullName = "",
                    //    Email = email,
                    //    Phone = "",
                    //    RoleId = (int)RoleEnum.alumni,
                    //};

                    //var newAlumniID = await service.AddAlumni(newAlumni);
                    //var alumni = await service.GetById(newAlumniID);
                    //var token = await tokenHelper.CreateToken(alumni);
                    //return token;

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

        [HttpPost("tenant/register")]
        public async Task<ActionResult<int>> registerTenant([FromBody] TenantRegisterDTO tenantRegisterDTO)
        {
            try
            {


                Alumni tenantAdd = mapper.Map<Alumni>(tenantRegisterDTO);
                tenantAdd.RoleId = (int)RoleEnum.alumni;
                var tenantID = await service.AddAlumni(tenantAdd);
                return Ok(tenantID);
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

        [HttpPut("alumnis"), Authorize(Roles = "alumni,tenant")]
        public async Task<ActionResult<AlumniDTO>> UpdateAlumni([FromBody] AlumniUpdateDTO alumniUpdateDTO)
        {
            try
            {
                var alumniIdClaims = tokenUltil.GetClaimByType(User, Constant.AlumniId).Value;
                var alumniId = int.Parse(alumniIdClaims);
                var alumni = await service.GetById(alumniId);
                if (alumni == null)
                {
                    return NotFound("Alumni not found with ID: " + alumniId);
                }
                Alumni alumniUpdate = mapper.Map<Alumni>(alumniUpdateDTO);
                alumniUpdate.Id = alumniId;
                var updateAlumni = await service.UpdateAlumni(alumniUpdate);
                return Ok(mapper.Map<AlumniDTO>(updateAlumni));
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
