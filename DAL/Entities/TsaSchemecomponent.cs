using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("tsa_schemecomponent", Schema = "jit")]
public partial class TsaSchemecomponent
{
    [Column("slscode")]
    [StringLength(50)]
    public string? Slscode { get; set; }

    [Column("financialyear")]
    [StringLength(9)]
    public string? Financialyear { get; set; }

    [Column("shemename")]
    [StringLength(300)]
    public string? Shemename { get; set; }

    [Column("componentcode")]
    [StringLength(50)]
    public string? Componentcode { get; set; }

    [Column("componentname")]
    [StringLength(200)]
    public string? Componentname { get; set; }

    [Column("entrydate")]
    public DateOnly? Entrydate { get; set; }

    [Column("lastsynced")]
    public DateOnly? Lastsynced { get; set; }

    [Column("syncedby")]
    [StringLength(100)]
    public string? Syncedby { get; set; }

    [Column("schemecode")]
    [StringLength(25)]
    public string? Schemecode { get; set; }

    [Column("parentcomponentcode")]
    [StringLength(50)]
    public string? Parentcomponentcode { get; set; }

    [Column("parentcomponentname")]
    [StringLength(500)]
    public string? Parentcomponentname { get; set; }
}
