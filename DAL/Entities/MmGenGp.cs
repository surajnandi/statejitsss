using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_gp", Schema = "ifmsadmin")]
public partial class MmGenGp
{
    [Column("district_code", TypeName = "character varying")]
    public string? DistrictCode { get; set; }

    [Column("sub_division_code", TypeName = "character varying")]
    public string? SubDivisionCode { get; set; }

    [Column("block_code", TypeName = "character varying")]
    public string? BlockCode { get; set; }

    [Column("gram_panchyat_code", TypeName = "character varying")]
    public string? GramPanchyatCode { get; set; }

    [Column("gram_panchyat_name", TypeName = "character varying")]
    public string? GramPanchyatName { get; set; }

    [Column("status", TypeName = "character varying")]
    public string? Status { get; set; }

    [Column("deleted_at", TypeName = "character varying")]
    public string? DeletedAt { get; set; }

    [Column("created_at", TypeName = "character varying")]
    public string? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "character varying")]
    public string? UpdatedAt { get; set; }

    [Column("dist_id", TypeName = "character varying")]
    public string? DistId { get; set; }

    [Column("sub_division_id", TypeName = "character varying")]
    public string? SubDivisionId { get; set; }

    [Column("block_id", TypeName = "character varying")]
    public string? BlockId { get; set; }

    [Column("gram_panchyat_id", TypeName = "character varying")]
    public string? GramPanchyatId { get; set; }

    [Column("ds_gp", TypeName = "character varying")]
    public string? DsGp { get; set; }
}
