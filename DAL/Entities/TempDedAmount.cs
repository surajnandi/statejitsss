using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("_temp_ded_amount")]
public partial class TempDedAmount
{
    [Column("ded_amount")]
    public decimal? DedAmount { get; set; }
}
