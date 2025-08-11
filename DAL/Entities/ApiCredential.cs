using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("api_credentials", Schema = "api")]
public partial class ApiCredential
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("roleid")]
    public Guid Roleid { get; set; }

    [Column("username", TypeName = "character varying")]
    public string Username { get; set; } = null!;

    [Column("secret_key")]
    public Guid SecretKey { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by", TypeName = "character varying")]
    public string CreatedBy { get; set; } = null!;

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [Column("updated_by", TypeName = "character varying")]
    public string UpdatedBy { get; set; } = null!;
}
