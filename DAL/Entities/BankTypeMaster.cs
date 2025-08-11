using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("bank_type_master", Schema = "master")]
[Index("BankType", Name = "bank_type_master_unique", IsUnique = true)]
public partial class BankTypeMaster
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("bank_type", TypeName = "character varying")]
    public string BankType { get; set; } = null!;

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }
}
