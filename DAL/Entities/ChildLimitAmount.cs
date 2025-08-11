using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("child_limit_amount")]
public partial class ChildLimitAmount
{
    [Column("sum")]
    public decimal? Sum { get; set; }
}
