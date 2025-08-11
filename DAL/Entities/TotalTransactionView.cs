using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
public partial class TotalTransactionView
{
    [Column("month")]
    public string? Month { get; set; }

    [Column("total_fto")]
    public long? TotalFto { get; set; }

    [Column("total_fto_amount")]
    public decimal? TotalFtoAmount { get; set; }

    [Column("total_success_amount")]
    public decimal? TotalSuccessAmount { get; set; }

    [Column("total_expenditure")]
    public decimal? TotalExpenditure { get; set; }

    [Column("total_failed_amount")]
    public decimal? TotalFailedAmount { get; set; }

    [Column("total_failed_payee")]
    public long? TotalFailedPayee { get; set; }
}
