using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_bank_branch_ifsc", Schema = "ifmsadmin")]
public partial class MmGenBankBranchIfsc
{
    [Column("bank", TypeName = "character varying")]
    public string? Bank { get; set; }

    [Column("ifsc_code", TypeName = "character varying")]
    public string? IfscCode { get; set; }

    [Column("branch_name", TypeName = "character varying")]
    public string? BranchName { get; set; }

    [Column("address", TypeName = "character varying")]
    public string? Address { get; set; }

    [Column("city", TypeName = "character varying")]
    public string? City { get; set; }

    [Column("district", TypeName = "character varying")]
    public string? District { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("stdcode", TypeName = "character varying")]
    public string? Stdcode { get; set; }

    [Column("contact", TypeName = "character varying")]
    public string? Contact { get; set; }

    [Column("active_flag")]
    [StringLength(1)]
    public string? ActiveFlag { get; set; }

    [Column("micr_code")]
    [StringLength(42)]
    public string? MicrCode { get; set; }

    [Column("wef_date")]
    public DateOnly? WefDate { get; set; }

    [Column("created_user_id")]
    public decimal? CreatedUserId { get; set; }

    [Column("created_timestamp")]
    public DateOnly? CreatedTimestamp { get; set; }

    [Column("dml_status_flag")]
    public decimal? DmlStatusFlag { get; set; }
}
