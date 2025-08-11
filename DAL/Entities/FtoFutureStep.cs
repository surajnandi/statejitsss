using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("fto_future_steps", Schema = "master")]
public partial class FtoFutureStep
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("description", TypeName = "character varying")]
    public string? Description { get; set; }

    [Column("module_id")]
    public int? ModuleId { get; set; }

    [Column("pflag")]
    public short? Pflag { get; set; }

    [Column("bill_flag")]
    public short? BillFlag { get; set; }

    [Column("reissue")]
    public bool? Reissue { get; set; }

    [Column("next_step")]
    public short? NextStep { get; set; }

    [Column("steps")]
    public bool? Steps { get; set; }

    [Column("future_steps")]
    public bool FutureSteps { get; set; }

    [Column("icon", TypeName = "character varying")]
    public string? Icon { get; set; }
}
