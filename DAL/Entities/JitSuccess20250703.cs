using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("jit_success_20250703")]
public partial class JitSuccess20250703
{
    [Column("ref_no")]
    [StringLength(100)]
    public string? RefNo { get; set; }

    [Column("end_to_end_id")]
    [StringLength(150)]
    public string? EndToEndId { get; set; }
}
