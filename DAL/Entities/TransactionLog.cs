using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("transaction_log", Schema = "transaction")]
public partial class TransactionLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("ref_no", TypeName = "character varying")]
    public string? RefNo { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("created_by", TypeName = "character varying")]
    public string? CreatedBy { get; set; }

    [Column("fiscal_year")]
    public short? FiscalYear { get; set; }
}
