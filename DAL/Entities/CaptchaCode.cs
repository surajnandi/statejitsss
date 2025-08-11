using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("captcha_code", Schema = "transaction")]
public partial class CaptchaCode
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("captcha_cd", TypeName = "character varying")]
    public string? CaptchaCd { get; set; }

    [Column("generation_date_time")]
    public DateTime? GenerationDateTime { get; set; }
}
