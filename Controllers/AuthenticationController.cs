using DemoApi.Models.Authentication;
using DemoApi.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly QuanLySinhVienContext _context;
        public AuthenticationController(IConfiguration configuration, QuanLySinhVienContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> XacThuc(InputUser input)
        {
            var item = await _context.TaiKhoans.FirstOrDefaultAsync(c => c.Email == input.Email
            && c.UserName == input.Username
            && c.PasswordHash == input.Password);
            if (item == null) return Unauthorized();
            var token = GenerateJWT(item);
            return Ok(new OutputToken
            {
                Token = token,
                RefreshToken = null,
                InvokeToken = null,
                Times = null
            });
        }

        private string GenerateJWT(TaiKhoan taikhoan)
        {
            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256Signature);
            //var role = _context.Roles.FirstOrDefault(c => c.Id == taikhoan.Id);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, taikhoan.Id),
                new Claim(ClaimTypes.Name, taikhoan.UserName),
                new Claim(ClaimTypes.Role, "users"),
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Issuer"],
                claims,
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(10)).DateTime,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
