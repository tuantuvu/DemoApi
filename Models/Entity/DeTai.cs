using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Models.Entity;

[Table("DeTai")]
public partial class DeTai
{
    [Key]
    public string Id { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? MaDeTai { get; set; }

    [StringLength(150)]
    public string? TenDeTai { get; set; }

    [Column(TypeName = "money")]
    public decimal? KinhPhi { get; set; }

    [StringLength(250)]
    public string? NoiThucTap { get; set; }
}
