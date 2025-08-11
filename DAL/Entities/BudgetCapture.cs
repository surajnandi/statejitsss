using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("budget_capture", Schema = "ifmsadmin")]
public partial class BudgetCapture
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("hoa_id")]
    public long? HoaId { get; set; }

    [Column("pfms_head_id")]
    public long? PfmsHeadId { get; set; }

    [Column("budget_prov_amount")]
    public decimal? BudgetProvAmount { get; set; }

    [Column("r_a_amount")]
    public decimal? RAAmount { get; set; }

    [Column("r_a_flag")]
    [StringLength(1)]
    public string? RAFlag { get; set; }

    [Column("revised_estimate_amount")]
    public decimal? RevisedEstimateAmount { get; set; }

    [Column("budget_capture_date")]
    public DateOnly BudgetCaptureDate { get; set; }

    [Column("created_by_username")]
    [StringLength(50)]
    public string? CreatedByUsername { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }
}
