using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_ddo_bak2", Schema = "ifmsadmin")]
public partial class MmGenDdoBak2
{
    [Column("int_ddo_id")]
    public long IntDdoId { get; set; }

    [Column("treasury_code")]
    [StringLength(4)]
    public string? TreasuryCode { get; set; }

    [Column("ddo_code")]
    [StringLength(9)]
    public string? DdoCode { get; set; }

    [Column("ddo_type")]
    [MaxLength(1)]
    public char? DdoType { get; set; }

    [Column("valid_upto")]
    public DateOnly? ValidUpto { get; set; }

    [Column("designation")]
    [StringLength(200)]
    public string? Designation { get; set; }

    [Column("address")]
    [StringLength(200)]
    public string? Address { get; set; }

    [Column("phone_no1")]
    [StringLength(20)]
    public string? PhoneNo1 { get; set; }

    [Column("phone_no2")]
    [StringLength(20)]
    public string? PhoneNo2 { get; set; }

    [Column("fax")]
    [StringLength(20)]
    public string? Fax { get; set; }

    [Column("e_mail")]
    [StringLength(50)]
    public string? EMail { get; set; }

    [Column("pin")]
    [StringLength(6)]
    public string? Pin { get; set; }

    [Column("active_flag")]
    public bool? ActiveFlag { get; set; }

    [Column("created_by_userid")]
    public long? CreatedByUserid { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_by_userid")]
    [Precision(8, 0)]
    public decimal? UpdatedByUserid { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [Column("ddo_tan_no")]
    [StringLength(10)]
    public string? DdoTanNo { get; set; }

    [Column("int_dept_id")]
    public long? IntDeptId { get; set; }

    [Column("office_name")]
    [StringLength(100)]
    public string? OfficeName { get; set; }

    [Column("station")]
    [StringLength(50)]
    public string? Station { get; set; }

    [Column("controlling_officer")]
    [StringLength(50)]
    public string? ControllingOfficer { get; set; }

    [Column("enrolement_no")]
    [StringLength(25)]
    public string? EnrolementNo { get; set; }

    [Column("nps_registration_no")]
    [StringLength(20)]
    public string? NpsRegistrationNo { get; set; }

    [Column("int_dept_id_hrms")]
    [StringLength(3)]
    public string? IntDeptIdHrms { get; set; }

    [Column("gstin")]
    [StringLength(255)]
    public string? Gstin { get; set; }

    [Column("parent_treasury_code")]
    [StringLength(10)]
    public string? ParentTreasuryCode { get; set; }

    [Column("ref_code")]
    [Precision(6, 0)]
    public decimal? RefCode { get; set; }
}
