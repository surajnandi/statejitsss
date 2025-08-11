using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Table("bill_status_master", Schema = "master")]
public partial class BillStatusMaster
{
    [Key]
    [Column("status_id")]
    public short StatusId { get; set; }

    [Column("status_code", TypeName = "character varying")]
    public string StatusCode { get; set; } = null!;
}
