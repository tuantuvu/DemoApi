using DemoApi.Models.Authentication;
using DemoApi.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly QuanLySinhVienContext _context;
        public TaiKhoanController(QuanLySinhVienContext context)
        {
            _context = context;
        }

        [HttpPost("dang-ky")]
        public async Task<IActionResult> DangKy(InputUser input)
        {
            var item = await _context.TaiKhoans.FirstOrDefaultAsync(c => c.Email == input.Email || c.UserName == input.Username);
            if (item != null) return BadRequest();

            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.Email = input.Email;
            taiKhoan.NormalizedEmail = input.Email.ToUpper();
            taiKhoan.UserName = input.Username;
            taiKhoan.NormalizedUserName = input.Username.ToUpper();
            taiKhoan.PasswordHash = input.Password;
            taiKhoan.EmailConfirmed = true;

            _context.TaiKhoans.Add(taiKhoan);
            _context.SaveChanges();

            return Ok(taiKhoan);
        }
    }
}
