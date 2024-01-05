using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Models.Entity;

[Keyless]
[Table("GiangVien")]
public partial class GiangVien
{
    [StringLength(450)]
    public string? Id { get; set; }

    [Column("MaGV")]
    [StringLength(10)]
    public string? MaGv { get; set; }

    [Column("TenGV")]
    [StringLength(150)]
    public string? TenGv { get; set; }

    [Column(TypeName = "money")]
    public decimal? Luong { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MaKhoa { get; set; }
}
