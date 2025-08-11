using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("mm_gen_state_updated", Schema = "ifmsadmin")]
public partial class MmGenStateUpdated
{
    [Key]
    [Column("sl_no")]
    public int SlNo { get; set; }

    [Column("state_code")]
    public int? StateCode { get; set; }

    [Column("state_version")]
    public short? StateVersion { get; set; }

    [Column("state_name", TypeName = "character varying")]
    public string? StateName { get; set; }

    [Column("state_lgd_code", TypeName = "character varying")]
    public string? StateLgdCode { get; set; }

    [Column("state_ut")]
    [MaxLength(1)]
    public char? StateUt { get; set; }

    [Column("created_by", TypeName = "character varying")]
    public string? CreatedBy { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }
}
