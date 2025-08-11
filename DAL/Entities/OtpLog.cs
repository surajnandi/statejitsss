using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("otp_log", Schema = "transaction")]
public partial class OtpLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_id", TypeName = "character varying")]
    public string UserId { get; set; } = null!;

    [Column("otp")]
    public int Otp { get; set; }

    [Column("generation_date_time")]
    public TimeOnly? GenerationDateTime { get; set; }

    [Column("otp_ip", TypeName = "character varying")]
    public string? OtpIp { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime? CreatedDate { get; set; }
}
