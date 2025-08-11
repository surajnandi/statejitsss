using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("fto_voucher", Schema = "jit")]
public partial class FtoVoucher
{
    [Column("ref_no")]
    [StringLength(50)]
    public string? RefNo { get; set; }

    [Column("payee_id")]
    [StringLength(50)]
    public string? PayeeId { get; set; }

    [Column("voucher_no")]
    [StringLength(150)]
    public string? VoucherNo { get; set; }

    [Column("amount")]
    [Precision(12, 2)]
    public decimal? Amount { get; set; }

    [Column("voucher_date")]
    public DateOnly? VoucherDate { get; set; }

    [Column("desc_charges")]
    [StringLength(150)]
    public string? DescCharges { get; set; }

    [Column("authority")]
    [StringLength(150)]
    public string? Authority { get; set; }
}
