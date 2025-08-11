using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("payee_deduction", Schema = "jit")]
public partial class PayeeDeduction
{
    [Column("payee_id")]
    [StringLength(50)]
    public string? PayeeId { get; set; }

    [Column("ref_no")]
    [StringLength(50)]
    public string? RefNo { get; set; }

    [Column("ded_id")]
    public decimal DedId { get; set; }

    [Column("amount")]
    public double Amount { get; set; }
}
