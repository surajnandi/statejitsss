using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("tsa_agency_details", Schema = "jit")]
public partial class TsaAgencyDetail
{
    [Column("agencycode")]
    [StringLength(100)]
    public string? Agencycode { get; set; }

    [Column("agency_name")]
    [StringLength(200)]
    public string? AgencyName { get; set; }

    [Column("statelgdcode")]
    [StringLength(10)]
    public string? Statelgdcode { get; set; }

    [Column("districtlgdcode")]
    [StringLength(100)]
    public string? Districtlgdcode { get; set; }

    [Column("blocklgdcode")]
    [StringLength(100)]
    public string? Blocklgdcode { get; set; }

    [Column("panchayatlgdcode")]
    [StringLength(100)]
    public string? Panchayatlgdcode { get; set; }

    [Column("villagecode")]
    [StringLength(100)]
    public string? Villagecode { get; set; }

    [Column("tehsillgdcode")]
    [StringLength(100)]
    public string? Tehsillgdcode { get; set; }

    [Column("townlgdcode")]
    [StringLength(100)]
    public string? Townlgdcode { get; set; }

    [Column("wardlgdcode")]
    [StringLength(100)]
    public string? Wardlgdcode { get; set; }

    [Column("cityname")]
    [StringLength(50)]
    public string? Cityname { get; set; }

    [Column("entry_date")]
    public DateOnly? EntryDate { get; set; }

    [Column("update_date")]
    public DateOnly? UpdateDate { get; set; }

    [Column("created_by")]
    [StringLength(100)]
    public string? CreatedBy { get; set; }

    [Column("sls_scheme_code")]
    [StringLength(50)]
    public string? SlsSchemeCode { get; set; }

    [Key]
    [Column("agency_id")]
    public long AgencyId { get; set; }
}
