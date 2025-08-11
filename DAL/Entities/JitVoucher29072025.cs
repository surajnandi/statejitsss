using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("jit_voucher_29072025")]
public partial class JitVoucher29072025
{
    [Column("bill_id")]
    public long? BillId { get; set; }
}
