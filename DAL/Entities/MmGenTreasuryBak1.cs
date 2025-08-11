using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_treasury_bak1", Schema = "ifmsadmin")]
public partial class MmGenTreasuryBak1
{
    [Column("int_treasury_id")]
    [Precision(3, 0)]
    public decimal? IntTreasuryId { get; set; }

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
    [Precision(8, 0)]
    public decimal? OfficerUserId { get; set; }

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

    [Column("created_user_id")]
    [Precision(8, 0)]
    public decimal? CreatedUserId { get; set; }

    [Column("created_timestamp")]
    public DateOnly CreatedTimestamp { get; set; }

    [Column("modified_user_id")]
    [Precision(8, 0)]
    public decimal? ModifiedUserId { get; set; }

    [Column("modified_timestamp")]
    public DateOnly ModifiedTimestamp { get; set; }

    [Column("int_treasury_code")]
    [StringLength(5)]
    public string? IntTreasuryCode { get; set; }

    [Column("treasury_status")]
    [StringLength(1)]
    public string? TreasuryStatus { get; set; }

    [Column("int_ddo_id")]
    [Precision(6, 0)]
    public decimal? IntDdoId { get; set; }

    [Column("debt_acct_no")]
    [StringLength(15)]
    public string? DebtAcctNo { get; set; }

    [Column("nps_registration_no")]
    [Precision(10, 0)]
    public decimal? NpsRegistrationNo { get; set; }

    [Column("pension_flag")]
    [StringLength(1)]
    public string? PensionFlag { get; set; }
}
