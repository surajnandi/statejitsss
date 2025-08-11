using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("config")]
public partial class Config
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("latest_version")]
    [StringLength(255)]
    public string? LatestVersion { get; set; }

    [Column("refresh_cache_if_older_than")]
    [StringLength(255)]
    public string? RefreshCacheIfOlderThan { get; set; }

    [Column("req_timeout")]
    [StringLength(255)]
    public string? ReqTimeout { get; set; }

    [Column("carousel_slide_duration")]
    [StringLength(255)]
    public string? CarouselSlideDuration { get; set; }

    [Column("session_check_interval")]
    [StringLength(255)]
    public string? SessionCheckInterval { get; set; }

    [Column("sdmc_flag")]
    [StringLength(255)]
    public string? SdmcFlag { get; set; }

    [Column("logging_flag")]
    [StringLength(255)]
    public string? LoggingFlag { get; set; }

    [Column("payment_max_amt")]
    [StringLength(255)]
    public string? PaymentMaxAmt { get; set; }

    [Column("base_domain")]
    [StringLength(255)]
    public string? BaseDomain { get; set; }

    [Column("otp_enabled_roles")]
    [StringLength(255)]
    public string? OtpEnabledRoles { get; set; }

    [Column("ignore_session_for_routes")]
    [StringLength(255)]
    public string? IgnoreSessionForRoutes { get; set; }

    [Column("sanitizationregex")]
    [StringLength(255)]
    public string? Sanitizationregex { get; set; }

    [Column("r_k_1")]
    [StringLength(255)]
    public string? RK1 { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
