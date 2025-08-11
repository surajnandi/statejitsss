using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using statejitsss.DAL.Entities;

namespace statejitsss.DAL;

public partial class StateJitDbContext : DbContext
{
    public StateJitDbContext()
    {
    }

    public StateJitDbContext(DbContextOptions<StateJitDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgencySummaryView> AgencySummaryViews { get; set; }

    public virtual DbSet<ApiCredential> ApiCredentials { get; set; }

    public virtual DbSet<BankTypeMaster> BankTypeMasters { get; set; }

    public virtual DbSet<BillStatusMaster> BillStatusMasters { get; set; }

    public virtual DbSet<BtDetail> BtDetails { get; set; }

    public virtual DbSet<BtDetailsLog> BtDetailsLogs { get; set; }

    public virtual DbSet<BudgetCapture> BudgetCaptures { get; set; }

    public virtual DbSet<CaptchaCode> CaptchaCodes { get; set; }

    public virtual DbSet<ChildLimitAmount> ChildLimitAmounts { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<DashboardView> DashboardViews { get; set; }

    public virtual DbSet<ExpPayeeComponent> ExpPayeeComponents { get; set; }

    public virtual DbSet<Expenditureamount> Expenditureamounts { get; set; }

    public virtual DbSet<FinYear> FinYears { get; set; }

    public virtual DbSet<FtoFutureStep> FtoFutureSteps { get; set; }

    public virtual DbSet<FtoVoucher> FtoVouchers { get; set; }

    public virtual DbSet<InlimitAgencyA> InlimitAgencyAs { get; set; }

    public virtual DbSet<JitSuccess20250703> JitSuccess20250703s { get; set; }

    public virtual DbSet<JitVoucher29072025> JitVoucher29072025s { get; set; }

    public virtual DbSet<LogUserActivityTaskType> LogUserActivityTaskTypes { get; set; }

    public virtual DbSet<LogUserAtivityWorkArea> LogUserAtivityWorkAreas { get; set; }

    public virtual DbSet<MatchSuccess02062025> MatchSuccess02062025s { get; set; }

    public virtual DbSet<MmGenBankBranchIfsc> MmGenBankBranchIfscs { get; set; }

    public virtual DbSet<MmGenBlock> MmGenBlocks { get; set; }

    public virtual DbSet<MmGenDdo> MmGenDdos { get; set; }

    public virtual DbSet<MmGenDdoBak2> MmGenDdoBak2s { get; set; }

    public virtual DbSet<MmGenDepartment> MmGenDepartments { get; set; }

    public virtual DbSet<MmGenDistrict> MmGenDistricts { get; set; }

    public virtual DbSet<MmGenDistrictBkup> MmGenDistrictBkups { get; set; }

    public virtual DbSet<MmGenGp> MmGenGps { get; set; }

    public virtual DbSet<MmGenState> MmGenStates { get; set; }

    public virtual DbSet<MmGenStateUpdated> MmGenStateUpdateds { get; set; }

    public virtual DbSet<MmGenTreasury> MmGenTreasuries { get; set; }

    public virtual DbSet<MmGenTreasuryBak1> MmGenTreasuryBak1s { get; set; }

    public virtual DbSet<MmPayProcessingFlag> MmPayProcessingFlags { get; set; }

    public virtual DbSet<OtpLog> OtpLogs { get; set; }

    public virtual DbSet<PayeeDeduction> PayeeDeductions { get; set; }

    public virtual DbSet<PfmsAuditLog> PfmsAuditLogs { get; set; }

    public virtual DbSet<PfmsHeadDetail> PfmsHeadDetails { get; set; }

    public virtual DbSet<PfmsHeadDetails2425> PfmsHeadDetails2425s { get; set; }

    public virtual DbSet<PfmsHeadDetailsBk> PfmsHeadDetailsBks { get; set; }

    public virtual DbSet<PfmsHeadDetailsLog> PfmsHeadDetailsLogs { get; set; }

    public virtual DbSet<ProcessLog> ProcessLogs { get; set; }

    public virtual DbSet<RabbitmqErrorLog> RabbitmqErrorLogs { get; set; }

    public virtual DbSet<RabbitmqLog> RabbitmqLogs { get; set; }

    public virtual DbSet<RabbitmqLog2425> RabbitmqLog2425s { get; set; }

    public virtual DbSet<RabbitmqTransactionLog> RabbitmqTransactionLogs { get; set; }

    public virtual DbSet<RepTest> RepTests { get; set; }

    public virtual DbSet<TempDedAmount> TempDedAmounts { get; set; }

    public virtual DbSet<TotDistributedAmt> TotDistributedAmts { get; set; }

    public virtual DbSet<TotalTransactionView> TotalTransactionViews { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    public virtual DbSet<TransactionLog2425> TransactionLog2425s { get; set; }

    public virtual DbSet<TsaAgencyDetail> TsaAgencyDetails { get; set; }

    public virtual DbSet<TsaExpDetail> TsaExpDetails { get; set; }

    public virtual DbSet<TsaExpPayeeDetail> TsaExpPayeeDetails { get; set; }

    public virtual DbSet<TsaExpSanctionDetail> TsaExpSanctionDetails { get; set; }

    public virtual DbSet<TsaPayeeBank> TsaPayeeBanks { get; set; }

    public virtual DbSet<TsaPayeemaster> TsaPayeemasters { get; set; }

    public virtual DbSet<TsaSchemecomponent> TsaSchemecomponents { get; set; }

    public virtual DbSet<VForwardToUserid> VForwardToUserids { get; set; }

    public virtual DbSet<YearWiseTable> YearWiseTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:StateJitDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgencySummaryView>(entity =>
        {
            entity.ToView("agency_summary_view");
        });

        modelBuilder.Entity<ApiCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("api_credentials_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.SecretKey).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<BankTypeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bank_type_master_pk");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<BillStatusMaster>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("bill_status_master_pkey");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BtDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bt_details_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.Demand).IsFixedLength();
            entity.Property(e => e.Detailhead).IsFixedLength();
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.Major).IsFixedLength();
            entity.Property(e => e.Minorhead).IsFixedLength();
            entity.Property(e => e.Planstatus).IsFixedLength();
            entity.Property(e => e.Schemehead).IsFixedLength();
            entity.Property(e => e.Subdetail).IsFixedLength();
            entity.Property(e => e.Submajor).IsFixedLength();
        });

        modelBuilder.Entity<BtDetailsLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bt_details_log_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.Demand).IsFixedLength();
            entity.Property(e => e.Detailhead).IsFixedLength();
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.Major).IsFixedLength();
            entity.Property(e => e.Minorhead).IsFixedLength();
            entity.Property(e => e.Planstatus).IsFixedLength();
            entity.Property(e => e.Schemehead).IsFixedLength();
            entity.Property(e => e.Subdetail).IsFixedLength();
            entity.Property(e => e.Submajor).IsFixedLength();
        });

        modelBuilder.Entity<BudgetCapture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("budget_capture_pkey");
        });

        modelBuilder.Entity<CaptchaCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("captcha_code_pkey");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("config_pkey");

            entity.Property(e => e.IsActive).HasDefaultValue(false);
        });

        modelBuilder.Entity<DashboardView>(entity =>
        {
            entity.ToView("dashboard_view");
        });

        modelBuilder.Entity<FinYear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fin_year_pkey");

            entity.Property(e => e.IsActive).HasDefaultValue(false);
        });

        modelBuilder.Entity<FtoFutureStep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fto_future_steps_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FutureSteps).HasDefaultValue(false);
            entity.Property(e => e.Reissue).HasDefaultValue(false);
            entity.Property(e => e.Steps).HasDefaultValue(false);
        });

        modelBuilder.Entity<LogUserActivityTaskType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("log_user_activity_task_type_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<LogUserAtivityWorkArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("log_user_ativity_work_area_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<MmGenBankBranchIfsc>(entity =>
        {
            entity.Property(e => e.ActiveFlag).HasDefaultValueSql("'Y'::character varying");
            entity.Property(e => e.DmlStatusFlag).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<MmGenBlock>(entity =>
        {
            entity.Property(e => e.DsBlockName).HasDefaultValueSql("NULL::character varying");
        });

        modelBuilder.Entity<MmGenDdo>(entity =>
        {
            entity.HasKey(e => e.DdoId).HasName("mm_gen_ddo_pkey");
        });

        modelBuilder.Entity<MmGenDdoBak2>(entity =>
        {
            entity.Property(e => e.DdoCode).IsFixedLength();
            entity.Property(e => e.DdoTanNo).IsFixedLength();
            entity.Property(e => e.Fax).IsFixedLength();
            entity.Property(e => e.IntDdoId).HasDefaultValueSql("nextval('ifmsadmin.ddo_id_seq'::regclass)");
            entity.Property(e => e.IntDeptIdHrms).IsFixedLength();
            entity.Property(e => e.NpsRegistrationNo).IsFixedLength();
            entity.Property(e => e.PhoneNo1).IsFixedLength();
            entity.Property(e => e.PhoneNo2).IsFixedLength();
            entity.Property(e => e.Pin).IsFixedLength();
            entity.Property(e => e.TreasuryCode).IsFixedLength();
        });

        modelBuilder.Entity<MmGenDepartment>(entity =>
        {
            entity.Property(e => e.IntDeptId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<MmGenDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mm_gen_district_pkey");
        });

        modelBuilder.Entity<MmGenStateUpdated>(entity =>
        {
            entity.HasKey(e => e.SlNo).HasName("mm_gen_state_updated_pkey");

            entity.Property(e => e.SlNo).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<MmGenTreasury>(entity =>
        {
            entity.Property(e => e.DebtAcctNo).IsFixedLength();
            entity.Property(e => e.DistrictCode).IsFixedLength();
            entity.Property(e => e.Fax).IsFixedLength();
            entity.Property(e => e.IntTreasuryCode).IsFixedLength();
            entity.Property(e => e.IntTreasuryId).HasDefaultValueSql("nextval('ifmsadmin.treasury_id_seq'::regclass)");
            entity.Property(e => e.NpsRegistrationNo).IsFixedLength();
            entity.Property(e => e.Pin).IsFixedLength();
            entity.Property(e => e.TreasuryCode).IsFixedLength();
            entity.Property(e => e.TreasurySrlNumber).IsFixedLength();
        });

        modelBuilder.Entity<MmPayProcessingFlag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mm_pay_processing_flag_pkey");
        });

        modelBuilder.Entity<OtpLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("otp_log_pk");
        });

        modelBuilder.Entity<PfmsAuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("pfms_audit_log_pkey");

            entity.Property(e => e.FiscalYear).HasDefaultValueSql("get_active_fin_year()");
            entity.Property(e => e.OperationTimestamp).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<PfmsHeadDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pfms_head_details_pkey1_1");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('ifmsadmin.pfms_head_details_id_seq1'::regclass)");
            entity.Property(e => e.IsTopUp).HasDefaultValue(false);
        });

        modelBuilder.Entity<PfmsHeadDetails2425>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pfms_head_details_pkey1");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('ifmsadmin.pfms_head_details_id_seq1'::regclass)");
            entity.Property(e => e.IsTopUp).HasDefaultValue(false);
        });

        modelBuilder.Entity<PfmsHeadDetailsBk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pfms_head_details_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('ifmsadmin.pfms_head_details_id_seq'::regclass)");
            entity.Property(e => e.IsTopUp).HasDefaultValue(false);
        });

        modelBuilder.Entity<PfmsHeadDetailsLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pfms_head_details_log_pkey");

            entity.Property(e => e.IsTopUp).HasDefaultValue(false);
        });

        modelBuilder.Entity<ProcessLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("process_log_pkey");

            entity.Property(e => e.EntryDate).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<RabbitmqErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rabbitmq_error_log_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<RabbitmqLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rabbitmq_log_pkey_2526");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.FinancialYear).HasDefaultValueSql("get_active_fin_year()");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<RabbitmqLog2425>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rabbitmq_log_pkey_2425");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('transaction.rabbitmq_log_id_seq'::regclass)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.FinancialYear).HasDefaultValueSql("get_active_fin_year()");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<RabbitmqTransactionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rabbitmq_transaction_log_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<RepTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rep_test_pkey");
        });

        modelBuilder.Entity<TotalTransactionView>(entity =>
        {
            entity.ToView("total_transaction_view");
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_log_pkey_2526");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.FiscalYear).HasDefaultValueSql("get_active_fin_year()");
        });

        modelBuilder.Entity<TransactionLog2425>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transaction_log_pkey_2425");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('transaction.transaction_log_id_seq'::regclass)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.FiscalYear).HasDefaultValueSql("get_active_fin_year_2425()");
        });

        modelBuilder.Entity<TsaAgencyDetail>(entity =>
        {
            entity.HasKey(e => e.AgencyId).HasName("tsa_agency_details_pkey");
        });

        modelBuilder.Entity<TsaExpSanctionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jit_tsa_exp_sanction_details_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<YearWiseTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("year_wise_table_pkey");
        });
        modelBuilder.HasSequence("payee_id").StartsAt(2697582L);
        modelBuilder.HasSequence("seq_drawing_limit")
            .HasMin(0L)
            .HasMax(1000000000L);
        modelBuilder.HasSequence("seq_generic_jit_user")
            .HasMin(0L)
            .HasMax(1000000000L);
        modelBuilder.HasSequence("shmseq")
            .HasMin(0L)
            .HasMax(1000000000L);
        modelBuilder.HasSequence("snaoperator_seque")
            .HasMin(0L)
            .HasMax(1000000000L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
