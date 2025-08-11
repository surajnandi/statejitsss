using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("log_user_ativity_work_area", Schema = "master")]
[Index("Flag", Name = "log_user_ativity_work_area_flag_key", IsUnique = true)]
[Index("Name", Name = "log_user_ativity_work_area_name_key", IsUnique = true)]
public partial class LogUserAtivityWorkArea
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("flag")]
    public int Flag { get; set; }

    [Column("name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; }
}
