using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("tsa_payee_bank", Schema = "jit")]
public partial class TsaPayeeBank
{
    [Column("payee_id")]
    [StringLength(50)]
    public string? PayeeId { get; set; }

    [Column("bank_name")]
    [StringLength(100)]
    public string? BankName { get; set; }

    [Column("acc_no")]
    [StringLength(20)]
    public string? AccNo { get; set; }

    [Column("ifsc_code")]
    [StringLength(15)]
    public string? IfscCode { get; set; }

    [Column("agency_code")]
    [StringLength(100)]
    public string? AgencyCode { get; set; }

    [Column("entry_date")]
    public DateOnly? EntryDate { get; set; }

    [Column("maker_id")]
    [StringLength(100)]
    public string? MakerId { get; set; }

    [Column("cancelled_cheque")]
    public byte[]? CancelledCheque { get; set; }
}
