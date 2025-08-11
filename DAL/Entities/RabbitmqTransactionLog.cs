using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("rabbitmq_transaction_log", Schema = "transaction")]
public partial class RabbitmqTransactionLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("queue_name", TypeName = "character varying")]
    public string? QueueName { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
}
