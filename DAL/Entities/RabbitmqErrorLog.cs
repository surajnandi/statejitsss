using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("rabbitmq_error_log", Schema = "transaction")]
public partial class RabbitmqErrorLog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("queue_name")]
    [StringLength(255)]
    public string QueueName { get; set; } = null!;

    [Column("payload", TypeName = "jsonb")]
    public string Payload { get; set; } = null!;

    [Column("error_message")]
    public string ErrorMessage { get; set; } = null!;

    [Column("created_by")]
    [StringLength(255)]
    public string CreatedBy { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }
}
