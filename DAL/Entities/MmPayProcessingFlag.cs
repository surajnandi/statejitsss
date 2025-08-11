using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("mm_pay_processing_flag", Schema = "ifmsadmin")]
[Index("ProcessingFlag", Name = "mm_pay_processing_flag_unique", IsUnique = true)]
public partial class MmPayProcessingFlag
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("processing_flag")]
    [Precision(3, 0)]
    public decimal? ProcessingFlag { get; set; }

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

    [Column("active_flag")]
    [StringLength(1)]
    public string? ActiveFlag { get; set; }

    [Column("user_id", TypeName = "character varying")]
    public string? UserId { get; set; }

    [Column("created_timestamp")]
    public DateTime CreatedTimestamp { get; set; }

    [Column("modified_timestamp")]
    public DateTime ModifiedTimestamp { get; set; }

    [Column("modified_user_id", TypeName = "character varying")]
    public string? ModifiedUserId { get; set; }
}
