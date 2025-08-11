using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("v_forward_to_userid")]
public partial class VForwardToUserid
{
    [Column("id")]
    public long? Id { get; set; }
}
