using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("year_wise_table", Schema = "master")]
public partial class YearWiseTable
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("tab_name", TypeName = "character varying")]
    public string TabName { get; set; } = null!;

    [Column("finyear")]
    public short Finyear { get; set; }

    [Column("sch_name", TypeName = "character varying")]
    public string SchName { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; }
}
