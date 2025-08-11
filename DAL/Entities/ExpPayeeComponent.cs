using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("exp_payee_components", Schema = "jit")]
public partial class ExpPayeeComponent
{
    [Column("ref_no")]
    [StringLength(50)]
    public string? RefNo { get; set; }

    [Column("payee_id")]
    [StringLength(50)]
    public string? PayeeId { get; set; }

    [Column("componentcode")]
    [StringLength(50)]
    public string? Componentcode { get; set; }

    [Column("amount")]
    [Precision(12, 2)]
    public decimal? Amount { get; set; }

    [Column("entry_date")]
    public DateOnly EntryDate { get; set; }

    [Column("slscode")]
    [StringLength(50)]
    public string? Slscode { get; set; }
}
