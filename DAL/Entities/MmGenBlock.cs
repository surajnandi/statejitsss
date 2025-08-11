using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_block", Schema = "ifmsadmin")]
public partial class MmGenBlock
{
    [Column("district_code", TypeName = "character varying")]
    public string? DistrictCode { get; set; }

    [Column("sub_division_code")]
    public int? SubDivisionCode { get; set; }

    [Column("block_code", TypeName = "character varying")]
    public string BlockCode { get; set; } = null!;

    [Column("block_name")]
    [StringLength(100)]
    public string BlockName { get; set; } = null!;

    [Column("status")]
    [StringLength(1)]
    public string? Status { get; set; }

    [Column("deleted_at", TypeName = "timestamp(0) without time zone")]
    public DateTime? DeletedAt { get; set; }

    [Column("created_at", TypeName = "timestamp(0) without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp(0) without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [Column("district_id")]
    public int? DistrictId { get; set; }

    [Column("sub_division_id")]
    public int? SubDivisionId { get; set; }

    [Column("ds_block_name")]
    [StringLength(100)]
    public string? DsBlockName { get; set; }

    [Column("sr_block_code")]
    public int? SrBlockCode { get; set; }

    [Column("sr_block_name")]
    [StringLength(500)]
    public string? SrBlockName { get; set; }
}
