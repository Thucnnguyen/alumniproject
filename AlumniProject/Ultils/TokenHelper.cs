using AlumniProject.Entity;
using AlumniProject.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlumniProject.Ultils
{
    public  class TokenHelper
    {
        private readonly IGradeService _gradeService;
        private readonly IRoleService _roleService;
        private readonly IConfiguration _configuration;

        public TokenHelper(IConfiguration configuration, IGradeService gradeService, IRoleService roleService)
        {
            this._configuration = configuration;
            _gradeService = gradeService;
            _roleService = roleService;
        }

        public async Task<string> CreateToken(Alumni alumni)
        {
            var role = await _roleService.GetRoleById(alumni.RoleId);
            string schoolIdValue = (alumni.schoolId != null) ? alumni.schoolId.ToString() : "-1";
            List<Claim> claims = new List<Claim>()
            {
                new Claim(Constant.AlumniId, alumni.Id.ToString()),
                new Claim(Constant.SchoolId,schoolIdValue),
                new Claim(ClaimTypes.Role, role.Name)

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Token:secret").Value
                ));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
