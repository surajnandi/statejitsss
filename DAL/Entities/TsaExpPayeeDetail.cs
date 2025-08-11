using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("tsa_exp_payee_details", Schema = "jit")]
public partial class TsaExpPayeeDetail
{
    [Column("maker_id")]
    [StringLength(50)]
    public string? MakerId { get; set; }

    [Column("ref_no")]
    [StringLength(50)]
    public string? RefNo { get; set; }

    [Column("payee_id")]
    [StringLength(50)]
    public string? PayeeId { get; set; }

    [Column("amount")]
    [Precision(12, 2)]
    public decimal? Amount { get; set; }

    [Column("ded_amount")]
    [Precision(12, 2)]
    public decimal? DedAmount { get; set; }

    [Column("net_amount")]
    [Precision(12, 2)]
    public decimal? NetAmount { get; set; }
}
