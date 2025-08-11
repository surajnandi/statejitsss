namespace statejitsss.RabbitMQ.Enum
{
    /// <summary>
    /// RabbitMQ Queue Names as constants
    /// </summary>
    public static class RabbitMqQueueName
    {
        // Producer: JIT, Consumer: EBilling
        /// <summary>
        /// Send FTO to eBilling
        /// </summary>
        public const string JitEbillingFto = "wbjit_ebilling_fto";
        public const string JitEbillingFtoAck = "wbjit_ebilling_fto_ack";

        /// <summary>
        /// Send Agency Drawing Limit Sanction to eBilling
        /// </summary>
        public const string JitEbillingAllotment = "wbjit_ebilling_allotment";
        public const string JitEbillingAllotmentWithdrawl = "wbjit_ebilling_allotment_withdrawl";
        public const string JitEbillingAllotmentAck = "wbjit_ebilling_allotment_ack";

        public const string JitEbillingAllotmentWithdrawlAck = "wbjit_ebilling_allotment_withdrawl_ack";

        /// <summary>
        /// Send HOA Wise Allocation to eBilling
        /// </summary>
        public const string JitEbillingMothersanction = "wbjit_ebilling_mothersanction";

        /// <summary>
        /// Send FTO Pull Back Request to eBilling
        /// </summary>
        public const string JitEbillingReturnFtoRequest = "wbjit_ebilling_return_fto_request";

        /// <summary>
        /// Send DDO Mapping For Approval
        /// </summary>
        public const string JitEbillingRequestAgencyDdoMapping = "wbjit_ebilling_request_agency_ddo_mapping";
        /// <summary>
        /// Send DDO Mapping For Approval
        /// </summary>
        public const string JitEbillingActiveHoaMst = "wbjit_ebilling_active_hoa_mst";
        public const string JitEbillingActiveHoaMstAck = "wbjit_ebilling_active_hoa_mst_ack";

        // Producer: EBilling, Consumer: JIT
        /// <summary>
        /// Receive FTO Pull Back Request Approved From eBilling
        /// </summary>
        public const string EbillingJitReturnFtoRequestApproved = "wbjit_ebilling_jit_return_fto_request_approved";

        /// <summary>
        /// FTO return by DDO from eBilling
        /// </summary>
        public const string EbillingJitReturnFto = "wbjit_ebilling_jit_return_fto";

        /// <summary>
        /// FTO Failed beneficiary details from eBilling (TR-26a)
        /// </summary>
        public const string EbillingJitFailedBeneficiary = "wbjit_ebilling_jit_failed_beneficiary";

        /// <summary>
        /// FTO Failed beneficiary details from eBilling (TR-26a)
        /// </summary>
        public const string EbillingJitSucessBeneficiary = "wbjit_ebilling_jit_success_beneficiary";

        public const string EbillingGSTJitFailedBeneficiary = "wbjit_ebilling_jit_gst_failed";

        /// <summary>
        /// ebilling_jit_bill_status
        /// </summary>
        public const string EbillingJitBillStatus = "wbjit_ebilling_jit_bill_status";

        /// <summary>
        /// Beneficiary status from eBilling
        /// </summary>
        public const string EbillingJitBeneficiaryStatus = "wbjit_ebilling_jit_beneficiary_status";

        /// <summary>
        /// Receive DDO Mapping Response For Approval/Denied
        /// </summary>
        public const string EbillingJitResponseAgencyDdoMapping = "wbjit_ebilling_jit_response_agency_ddo_mapping";


        /// <summary>
        /// FTO reject by DDO from eBilling
        /// </summary>
        public const string EbillingJitRejectFto = "wbjit_ebilling_jit_reject_fto";
        /// <summary>
        /// FTO reject by DDO from eBilling
        /// </summary>
        public const string EbillingJitPullbackFto = "wbjit_ebilling_jit_pullback_fto";


        // Producer: JIT, Consumer: CTS
        /// <summary>
        /// Scheme Configuration need to share from JIT to CTS
        /// </summary>
        public const string JitEbillingSchemeConfiguration = "wbjit_ebilling_scheme_config_master";

        // Producer: EBilling, Consumer: CTS
        /// <summary>
        /// Send Bill to Treasury
        /// </summary>
        public const string BillingCtsBillSendToTreasury = "wbjit_billing_cts_bill_send_to_treasury";

        /// <summary>
        /// Send DDO Allotment from Billing to CTS
        /// </summary>
        public const string BillingCtsDdoAllotment = "wbjit_billing_cts_ddo_allotment";

        /// <summary>
        /// Share Bill status from Billing to CTS
        /// </summary>
        public const string BillingCtsBillStatus = "wbjit_billing_cts_bill_status";

        /// <summary>
        /// Share List of Failed Beneficiary corrected from DDO for generation of bill
        /// </summary>
        public const string BillingCtsCorrectedBeneficiary = "wbjit_billing_cts_corrected_beneficiary";

        // Producer: CTS, Consumer: EBilling
        /// <summary>
        /// Share Bill status from CTS to Billing
        /// </summary>
        public const string CtsBillingBillStatus = "wbjit_cts_billing_bill_status";

        /// <summary>
        /// Share List of Failed Beneficiary for Billing
        /// </summary>
        public const string CtsBillingFailedBeneficiary = "wbjit_cts_billing_failed_beneficiary";

        /// <summary>
        /// Share Objected Bill after Return Memo generated at CTS
        /// </summary>
        public const string CtsBillingObjectedBill = "wbjit_cts_billing_objected_bill";

        /// <summary>
        /// Share Failed at PFMS end
        /// </summary>
        public const string CtsBillingPfmsFailed = "wbjit_cts_billing_pfms_failed";

        /// <summary>
        /// Share List of Voucher at voucher generation
        /// </summary>
        public const string CtsBillingVoucher = "wbjit_cts_billing_voucher";

        /// <summary>
        /// Share List of Challan at challan generation
        /// </summary>
        public const string CtsBillingChallan = "wbjit_cts_billing_challan";

        /// <summary>
        /// Share Beneficiary status from CTS
        /// </summary>
        public const string CtsBillingBeneficiaryStatus = "wbjit_cts_billing_beneficiary_status";

        public const string EbillingJitVoucher = "wbjit_ebilling_jit_voucher";

        public const string EbillingMapGenericJitUserAdminToAgencySLS = "jit_ebilling_request_agency_ddo_mapping";

    }
}
