using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Campany.DTOs;
using Campany.Models;
using Campany.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Campany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var exi = await _unitOfWork.ApplicationUserCustomRepo.GetByEmailAsync(dto.Email);

            if(exi != null)
            {
                return BadRequest("Email is exist");
            }
            if(dto.Role != "Admin" ||  dto.Role != "Employee")
            {
                return BadRequest("The Role Must Be Admin or Employee");
            }
            var res = new ApplicationUser
            {
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
            };

            await _unitOfWork.ApplicationUserCustomRepo.Add(res);
            await _unitOfWork.SaveChanges();

            return Ok(res);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var exi = await _unitOfWork.ApplicationUserCustomRepo.GetByEmailAsync(dto.Email);

            if (exi == null)
            {
                return BadRequest("Invalid Email Or Password");
            }
            if (exi.Password != dto.Password)
            {
                return BadRequest("Invalid Email Or Password");
            }

            var token = GenrateToken(exi);

            return Ok(token);
        }


        private string GenrateToken(ApplicationUser user)
        {
            // payload
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Iss"],
                audience: _configuration["JWT:Aud"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
