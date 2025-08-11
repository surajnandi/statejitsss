using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("rabbitmq_log_2425", Schema = "transaction")]
public partial class RabbitmqLog2425
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("queue_name", TypeName = "character varying")]
    public string? QueueName { get; set; }

    [Column("payload", TypeName = "jsonb")]
    public string? Payload { get; set; }

    [Column("created_by", TypeName = "character varying")]
    public string? CreatedBy { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("financial_year")]
    public int? FinancialYear { get; set; }
}
