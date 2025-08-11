using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("tsa_exp_sanction_details", Schema = "jit")]
public partial class TsaExpSanctionDetail
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("ref_no", TypeName = "character varying")]
    public string RefNo { get; set; } = null!;

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("debit_amt")]
    [Precision(15, 2)]
    public decimal? DebitAmt { get; set; }

    [Column("limit_code", TypeName = "character varying")]
    public string? LimitCode { get; set; }

    [Column("hoa_id")]
    public long? HoaId { get; set; }
}
