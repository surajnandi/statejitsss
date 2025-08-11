using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_treasury", Schema = "ifmsadmin")]
public partial class MmGenTreasury
{
    [Column("int_treasury_id")]
    public int IntTreasuryId { get; set; }

    [Column("treasury_code")]
    [StringLength(4)]
    public string? TreasuryCode { get; set; }

    [Column("treasury_name")]
    [StringLength(100)]
    public string? TreasuryName { get; set; }

    [Column("district_code")]
    [StringLength(2)]
    public string? DistrictCode { get; set; }

    [Column("treasury_srl_number")]
    [StringLength(4)]
    public string? TreasurySrlNumber { get; set; }

    [Column("officer_user_id")]
    public long? OfficerUserId { get; set; }

    [Column("officer_name")]
    [StringLength(100)]
    public string? OfficerName { get; set; }

    [Column("address")]
    [StringLength(200)]
    public string? Address { get; set; }

    [Column("address1")]
    [StringLength(200)]
    public string? Address1 { get; set; }

    [Column("address2")]
    [StringLength(200)]
    public string? Address2 { get; set; }

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
    [StringLength(1)]
    public string? ActiveFlag { get; set; }

    [Column("createdby_user_id")]
    public long? CreatedbyUserId { get; set; }

    [Column("created_by", TypeName = "timestamp without time zone")]
    public DateTime? CreatedBy { get; set; }

    [Column("updatedby_user_id")]
    [Precision(8, 0)]
    public decimal? UpdatedbyUserId { get; set; }

    [Column("updated_by", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedBy { get; set; }

    [Column("int_treasury_code")]
    [StringLength(5)]
    public string? IntTreasuryCode { get; set; }

    [Column("treasury_status")]
    [MaxLength(1)]
    public char? TreasuryStatus { get; set; }

    [Column("int_ddo_id")]
    [Precision(6, 0)]
    public decimal? IntDdoId { get; set; }

    [Column("debt_acct_no")]
    [StringLength(15)]
    public string? DebtAcctNo { get; set; }

    [Column("nps_registration_no")]
    [StringLength(10)]
    public string? NpsRegistrationNo { get; set; }

    [Column("pension_flag")]
    [MaxLength(1)]
    public char? PensionFlag { get; set; }

    [Column("ref_code")]
    [Precision(3, 0)]
    public decimal? RefCode { get; set; }
}
