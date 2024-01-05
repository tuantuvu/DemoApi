using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Models.Entity;

[Table("SinhVien")]
public partial class SinhVien
{
    [Key]
    public string Id { get; set; } = null!;

    [Column("MaSV")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MaSv { get; set; }

    [Column("TenSV")]
    [StringLength(150)]
    public string? TenSv { get; set; }

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    [Column(TypeName = "date")]
    public DateTime? NgaySinh { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MaKhoa { get; set; }
}
