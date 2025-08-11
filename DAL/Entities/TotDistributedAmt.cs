using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("tot_distributed_amt")]
public partial class TotDistributedAmt
{
    [Column("coalesce")]
    public decimal? Coalesce { get; set; }
}
