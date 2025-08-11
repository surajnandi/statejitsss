using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("pfms_audit_log", Schema = "transaction")]
public partial class PfmsAuditLog
{
    [Key]
    [Column("log_id")]
    public int LogId { get; set; }

    [Column("table_name")]
    [StringLength(255)]
    public string TableName { get; set; } = null!;

    [Column("operation_type")]
    [StringLength(10)]
    public string OperationType { get; set; } = null!;

    [Column("record_key", TypeName = "jsonb")]
    public string RecordKey { get; set; } = null!;

    [Column("changed_data", TypeName = "jsonb")]
    public string? ChangedData { get; set; }

    [Column("old_data", TypeName = "jsonb")]
    public string? OldData { get; set; }

    [Column("performed_by")]
    [StringLength(255)]
    public string? PerformedBy { get; set; }

    [Column("operation_timestamp", TypeName = "timestamp without time zone")]
    public DateTime? OperationTimestamp { get; set; }

    [Column("fiscal_year")]
    public short? FiscalYear { get; set; }
}
