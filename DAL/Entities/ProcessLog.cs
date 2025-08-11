using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("process_log", Schema = "transaction")]
[Index("AgencyCode", Name = "idx_process_log_agency_code")]
[Index("RefNo", Name = "idx_process_log_ref_no")]
[Index("UserId", Name = "idx_process_log_user_id")]
public partial class ProcessLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("process_flag")]
    public decimal ProcessFlag { get; set; }

    [Column("agency_code", TypeName = "character varying")]
    public string? AgencyCode { get; set; }

    [Column("user_id", TypeName = "character varying")]
    public string? UserId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("ref_no", TypeName = "character varying")]
    public string RefNo { get; set; } = null!;

    [Column("remarks")]
    public string? Remarks { get; set; }

    [Column("ebill_status")]
    public int? EbillStatus { get; set; }

    [Column("pfms_error_desc", TypeName = "jsonb")]
    public string? PfmsErrorDesc { get; set; }

    [Column("objection_details", TypeName = "jsonb")]
    public string? ObjectionDetails { get; set; }

    [Column("entry_date", TypeName = "timestamp without time zone")]
    public DateTime EntryDate { get; set; }
}
