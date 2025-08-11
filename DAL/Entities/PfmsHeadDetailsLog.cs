using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("pfms_head_details_log", Schema = "ifmsadmin")]
public partial class PfmsHeadDetailsLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("pfms_id")]
    public int PfmsId { get; set; }

    [Column("goi_scheme_code")]
    public int? GoiSchemeCode { get; set; }

    [Column("goi_scheme_name")]
    [StringLength(150)]
    public string? GoiSchemeName { get; set; }

    [Column("state_scheme_code")]
    [StringLength(25)]
    public string? StateSchemeCode { get; set; }

    [Column("state_scheme_name")]
    [StringLength(150)]
    public string? StateSchemeName { get; set; }

    [Column("department_code")]
    [StringLength(25)]
    public string? DepartmentCode { get; set; }

    [Column("department_name")]
    [StringLength(150)]
    public string? DepartmentName { get; set; }

    [Column("demand_no")]
    public int? DemandNo { get; set; }

    [Column("major_head")]
    public int? MajorHead { get; set; }

    [Column("sub_major")]
    public int? SubMajor { get; set; }

    [Column("minor")]
    public int? Minor { get; set; }

    [Column("scheme")]
    public int? Scheme { get; set; }

    [Column("detail")]
    public int? Detail { get; set; }

    [Column("sub_detail")]
    public int? SubDetail { get; set; }

    [Column("voted")]
    [StringLength(2)]
    public string? Voted { get; set; }

    [Column("description")]
    [StringLength(150)]
    public string? Description { get; set; }

    [Column("central_state_share")]
    [StringLength(25)]
    public string? CentralStateShare { get; set; }

    [Column("budget_code", TypeName = "character varying")]
    public string? BudgetCode { get; set; }

    [Column("hoa_id")]
    public long? HoaId { get; set; }

    [Column("is_top_up")]
    public bool? IsTopUp { get; set; }

    [Column("status")]
    public short? Status { get; set; }

    [Column("central_function_head")]
    [StringLength(25)]
    public string? CentralFunctionHead { get; set; }

    [Column("object_head")]
    [StringLength(5)]
    public string? ObjectHead { get; set; }

    [Column("financial_year")]
    [StringLength(9)]
    public string? FinancialYear { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("update_by", TypeName = "character varying")]
    public string? UpdateBy { get; set; }

    [Column("update_on")]
    public DateOnly? UpdateOn { get; set; }

    [Column("update_by_ip", TypeName = "character varying")]
    public string? UpdateByIp { get; set; }
}
