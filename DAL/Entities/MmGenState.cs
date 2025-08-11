using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_state", Schema = "ifmsadmin")]
public partial class MmGenState
{
    [Column("state_id")]
    [Precision(2, 0)]
    public decimal? StateId { get; set; }

    [Column("state_name")]
    [StringLength(100)]
    public string? StateName { get; set; }

    [Column("state_short_name")]
    [StringLength(3)]
    public string? StateShortName { get; set; }

    [Column("user_id")]
    [Precision(8, 0)]
    public decimal? UserId { get; set; }

    [Column("modified_user_id")]
    [Precision(8, 0)]
    public decimal? ModifiedUserId { get; set; }

    [Column("created_timestamp")]
    public DateOnly CreatedTimestamp { get; set; }

    [Column("modified_timestamp")]
    public DateOnly ModifiedTimestamp { get; set; }

    [Column("dml_status_flag")]
    [Precision(1, 0)]
    public decimal? DmlStatusFlag { get; set; }

    [Column("active_flag")]
    [StringLength(1)]
    public string? ActiveFlag { get; set; }

    [Column("hrms_approve_flag")]
    [StringLength(1)]
    public string? HrmsApproveFlag { get; set; }
}
