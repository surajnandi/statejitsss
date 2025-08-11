using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("tsa_exp_details", Schema = "jit")]
[Index("RefNo", Name = "tsa_exp_details_unique_key_ref_no", IsUnique = true)]
public partial class TsaExpDetail
{
    [Column("ref_no")]
    [StringLength(50)]
    public string? RefNo { get; set; }

    [Column("sls_code")]
    [StringLength(50)]
    public string? SlsCode { get; set; }

    [Column("treas_code")]
    [StringLength(3)]
    public string? TreasCode { get; set; }

    [Column("ddo_code")]
    [StringLength(9)]
    public string? DdoCode { get; set; }

    [Column("exp_for")]
    [StringLength(1)]
    public string? ExpFor { get; set; }

    [Column("officeletter_no")]
    [StringLength(30)]
    public string? OfficeletterNo { get; set; }

    [Column("officeletter_file")]
    public byte[]? OfficeletterFile { get; set; }

    [Column("sanction_date")]
    public DateOnly? SanctionDate { get; set; }

    [Column("payee_count")]
    public int? PayeeCount { get; set; }

    [Column("gross_amount")]
    [Precision(12, 2)]
    public decimal? GrossAmount { get; set; }

    [Column("net_amount")]
    [Precision(12, 2)]
    public decimal? NetAmount { get; set; }

    [Column("narration")]
    [StringLength(300)]
    public string? Narration { get; set; }

    [Column("maker_id")]
    [StringLength(50)]
    public string? MakerId { get; set; }

    [Column("entry_date")]
    public DateOnly EntryDate { get; set; }

    [Column("mother_senc_no")]
    [StringLength(500)]
    public string? MotherSencNo { get; set; }

    [Column("mother_senc_date")]
    public DateOnly? MotherSencDate { get; set; }

    [Column("maker_check_status")]
    [StringLength(1)]
    public string? MakerCheckStatus { get; set; }

    [Column("maker_check_date")]
    public DateOnly? MakerCheckDate { get; set; }

    [Column("maker_check_remark")]
    [StringLength(500)]
    public string? MakerCheckRemark { get; set; }

    [Column("checker_check_status")]
    [StringLength(1)]
    public string? CheckerCheckStatus { get; set; }

    [Column("checker_check_date")]
    public DateOnly? CheckerCheckDate { get; set; }

    [Column("checker_check_remark")]
    [StringLength(500)]
    public string? CheckerCheckRemark { get; set; }

    [Column("agencyid")]
    [StringLength(100)]
    public string? Agencyid { get; set; }

    [Column("freze")]
    [StringLength(1)]
    public string? Freze { get; set; }

    [Column("back_bill_status")]
    [StringLength(1)]
    public string? BackBillStatus { get; set; }

    [Column("attachment_sanction")]
    public byte[]? AttachmentSanction { get; set; }

    [Column("ddo_back")]
    [StringLength(1)]
    public string? DdoBack { get; set; }

    [Column("checker_id")]
    [StringLength(100)]
    public string? CheckerId { get; set; }

    [Column("ddo_back_date")]
    public DateOnly? DdoBackDate { get; set; }

    [Column("ddo_back_remarks")]
    [StringLength(1000)]
    public string? DdoBackRemarks { get; set; }
}
