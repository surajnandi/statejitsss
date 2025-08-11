using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_district_bkup", Schema = "ifmsadmin")]
public partial class MmGenDistrictBkup
{
    [Column("int_district_id")]
    [Precision(5, 0)]
    public decimal? IntDistrictId { get; set; }

    [Column("district_code")]
    [StringLength(3)]
    public string? DistrictCode { get; set; }

    [Column("district_name")]
    [StringLength(50)]
    public string? DistrictName { get; set; }

    [Column("active_flag")]
    [StringLength(1)]
    public string? ActiveFlag { get; set; }

    [Column("state_id")]
    [Precision(2, 0)]
    public decimal? StateId { get; set; }

    [Column("user_id")]
    [Precision(8, 0)]
    public decimal? UserId { get; set; }

    [Column("created_timestamp")]
    public DateOnly CreatedTimestamp { get; set; }

    [Column("modified_user_id")]
    [Precision(8, 0)]
    public decimal? ModifiedUserId { get; set; }

    [Column("modified_timestamp")]
    public DateOnly ModifiedTimestamp { get; set; }

    [Column("district_id")]
    [StringLength(3)]
    public string? DistrictId { get; set; }

    [Column("district_census_code")]
    [StringLength(5)]
    public string? DistrictCensusCode { get; set; }
}
