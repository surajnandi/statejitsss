using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
public partial class AgencySummaryView
{
    [Column("id")]
    public long? Id { get; set; }

    [Column("agencycode")]
    [StringLength(100)]
    public string? Agencycode { get; set; }

    [Column("parentagencycode")]
    [StringLength(100)]
    public string? Parentagencycode { get; set; }

    [Column("agency_name")]
    [StringLength(200)]
    public string? AgencyName { get; set; }

    [Column("csscode")]
    [StringLength(30)]
    public string? Csscode { get; set; }

    [Column("slscode")]
    [StringLength(50)]
    public string? Slscode { get; set; }

    [Column("district_name")]
    [StringLength(50)]
    public string? DistrictName { get; set; }

    [Column("districtlgdcode")]
    [StringLength(100)]
    public string? Districtlgdcode { get; set; }

    [Column("selfamt")]
    public decimal? Selfamt { get; set; }

    [Column("selfavailamount")]
    public decimal? Selfavailamount { get; set; }

    [Column("childamt")]
    public decimal? Childamt { get; set; }

    [Column("childavailamount")]
    public decimal? Childavailamount { get; set; }

    [Column("total_self_fto_amt")]
    public decimal? TotalSelfFtoAmt { get; set; }

    [Column("total_dn_received_amount")]
    public decimal? TotalDnReceivedAmount { get; set; }

    [Column("last_sync", TypeName = "timestamp without time zone")]
    public DateTime? LastSync { get; set; }
}
