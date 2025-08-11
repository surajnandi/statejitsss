using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("tsa_payeemaster", Schema = "jit")]
public partial class TsaPayeemaster
{
    [Column("id")]
    [Precision(11, 0)]
    public decimal? Id { get; set; }

    [Column("payee_id")]
    [StringLength(50)]
    public string? PayeeId { get; set; }

    [Column("payee_name")]
    [StringLength(200)]
    public string? PayeeName { get; set; }

    [Column("ven_type")]
    [StringLength(1)]
    public string? VenType { get; set; }

    [Column("fwh_name")]
    [StringLength(50)]
    public string? FwhName { get; set; }

    [Column("gst_no")]
    [StringLength(15)]
    public string? GstNo { get; set; }

    [Column("pan_no")]
    [StringLength(12)]
    public string? PanNo { get; set; }

    [Column("address1")]
    [StringLength(100)]
    public string? Address1 { get; set; }

    [Column("address2")]
    [StringLength(100)]
    public string? Address2 { get; set; }

    [Column("city")]
    [StringLength(50)]
    public string? City { get; set; }

    [Column("state")]
    [StringLength(50)]
    public string? State { get; set; }

    [Column("country")]
    [StringLength(50)]
    public string? Country { get; set; }

    [Column("district")]
    [StringLength(50)]
    public string? District { get; set; }

    [Column("pincode")]
    [Precision(6, 0)]
    public decimal? Pincode { get; set; }

    [Column("mobile_no")]
    [Precision(10, 0)]
    public decimal? MobileNo { get; set; }

    [Column("phone_no")]
    [Precision(10, 0)]
    public decimal? PhoneNo { get; set; }

    [Column("email_id")]
    [StringLength(100)]
    public string? EmailId { get; set; }

    [Column("agency_code")]
    [StringLength(100)]
    public string? AgencyCode { get; set; }

    [Column("maker_id")]
    [StringLength(100)]
    public string? MakerId { get; set; }

    [Column("entry_date")]
    public DateOnly? EntryDate { get; set; }

    [Column("lastsynced")]
    public DateOnly Lastsynced { get; set; }

    [Column("status")]
    [StringLength(1)]
    public string? Status { get; set; }

    [Column("status_update_date")]
    public DateOnly? StatusUpdateDate { get; set; }

    [Column("aadhaar_no")]
    [StringLength(100)]
    public string? AadhaarNo { get; set; }

    [Column("ad_code")]
    [StringLength(4)]
    public string? AdCode { get; set; }

    [Column("dob")]
    public DateOnly? Dob { get; set; }

    [Column("district_nm")]
    [StringLength(100)]
    public string? DistrictNm { get; set; }
}
