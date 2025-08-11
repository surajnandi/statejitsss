using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("match_success_02062025")]
public partial class MatchSuccess02062025
{
    [Column("end_to_end_id")]
    [StringLength(150)]
    public string? EndToEndId { get; set; }

    [Column("gross_amount")]
    [Precision(12, 2)]
    public decimal? GrossAmount { get; set; }
}
