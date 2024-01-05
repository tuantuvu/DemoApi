using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Models.Entity;

[Table("Khoa")]
public partial class Khoa
{
    [Key]
    public string Id { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? MaKhoa { get; set; }

    [StringLength(150)]
    public string? TenKhoa { get; set; }

    [Column("SDT")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Sdt { get; set; }

    [StringLength(1000)]
    public string? Filter { get; set; }

    public string? UrlImages { get; set; }
}
