using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("inlimit_agency_a")]
public partial class InlimitAgencyA
{
    [Column("coalesce")]
    public decimal? Coalesce { get; set; }
}
