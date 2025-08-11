using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("fin_year", Schema = "ifmsadmin")]
public partial class FinYear
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("finyear")]
    public short? Finyear { get; set; }

    [Column("fin_year_view")]
    [StringLength(12)]
    public string? FinYearView { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
