using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models.Khoa
{
    public class OutputKhoa
    {
        public string Id { get; set; } = null!;

        public string? MaKhoa { get; set; }

        public string? TenKhoa { get; set; }

        public string? Sdt { get; set; }

        public string? UrlImages { get; set; }
    }
}
