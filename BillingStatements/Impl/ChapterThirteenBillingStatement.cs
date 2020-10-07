using HelocService.Helpers;
using HelocService.Models.InputCopyBookModels;
using System;
using System.Text;
using HelocService.Helpers;
using System.Linq;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace HelocService.BillingStatements
{
    public class ChapterThirteenBillingStatement : IChapterThirteenBillingStatement
    {
        public ChapterThirteenBillingStatement(ILogger logger)
        {
            Logger = logger;
        }
        #region Object Declaration  ==>
        public ILogger Logger;
        public string ExMessage { get; set; }

        public StringBuilder finalLine;

        #endregion

        #region public Property ==>
        public string PaymentAmount { get; set; }
        public string Principal { get; set; }
        public string PastUnpaidAmount { get; set; }
        public decimal TotalFeesPaid { get; set; }
        public string TotalPaymentAmount { get; set; }
        public string DeferredBalance { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }


        public string PrintStatement { get; set; }
        public string PrimaryBorrowerBKAttorney { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingBKAttorneyAddressLine1 { get; set; }
        public string MailingBKAttorneyAddressLine2 { get; set; }
        public string BorrowerAttorneyMailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string Interest { get; set; }
        public string EscrowTaxesandInsurance { get; set; }
        public string RegularMonthlyPayment { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string CarringtonFoundationDonationPaidLastMonth { get; set; }
        public string CarringtonFoundationDonationPaidYearToDate { get; set; }
        public string PostPetitonPastDueMessage { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string POBoxAddress { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string StateNSF { get; set; }
        public string AutodraftMessage { get; set; }
        public string StateDisclosures { get; set; }
        public string CarringtonCharitableFoundation { get; set; }
        public string PaymentInformationMessage { get; set; }

        #endregion


        public StringBuilder GetFinalChapterThirteenBillingStatement(AccountsModel accountModel, bool isCoBorrower = false)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();

            finalLine.Append(GetPaymentAmount(accountModel) + "|");
            finalLine.Append(GetPrincipal(accountModel) + "|");
            finalLine.Append(GetPastUnpaidAmount(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaid(accountModel) + "|");
            finalLine.Append(GetTotalPaymentAmount(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetTotalPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            finalLine.Append(GetPrintStatement(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingCountry(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetInterest(accountModel) + "|");
            finalLine.Append(GetEscrowTaxesandInsurance(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetCarringtonFoundationDonationPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetCarringtonFoundationDonationPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetPostPetitonPastDueMessage(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");
            return finalLine;
        }

        /* While Calculating Conditions must be applied and copybook fields must be verified twice*/
        public string GetPaymentAmount(AccountsModel accountsModel)
        {
            try
            {
               // DateTime str = CommonHelper.GetDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date);
                //Logger.Trace("STARTED:  Execute to get Payment Amount operation.");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmount = "0.00";
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null &&
                    CommonHelper.GetDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                     CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))))
                {
                    PaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                else
                {
                    PaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                //Logger.Trace("ENDED:    Get Payment Amount operation.");
                return PaymentAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentAmount " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPrincipal(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Principal operation.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
               Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    Principal = "0.00";

                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && CommonHelper.GetDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                        CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))))
                    Principal = "0.00";

                else
                {
                    Principal = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) -
                        Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:    Get to Principal operation.");
                return Principal;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipal " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPastUnpaidAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Past Unpaid Amount operation.");
                PastUnpaidAmount = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData != null
                    ? Convert.ToString(Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) - GetTotalFeesPaid(accountsModel)) : "0";

                //Logger.Trace("ENDED:    Get to Past Unpaid Amount operation.");
                return PastUnpaidAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPastUnpaidAmount " + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetTotalFeesPaid(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid operation.");
                if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData) +
                               Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                               Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {

                    TotalFeesPaid = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData) +
                        Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData) -
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData);
                }
                else
                {
                    TotalFeesPaid = Convert.ToDecimal(0.00);
                }
                //Logger.Trace("ENDED:    Get to Total Fees Paid operation.");
                return TotalFeesPaid;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaid " + ex.TargetSite.Name);
                return Convert.ToDecimal(0.00);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalPaymentAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Payment Amount operation.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalPaymentAmount = "0.00";


                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && CommonHelper.GetDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                     CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))))

                    TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                else
                    TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                //Logger.Trace("ENDED:    Get to Total Payment Amount operation.");
                return TotalPaymentAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaymentAmount " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Deferred Balance operation.");


                if ((accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData)
                    - (accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData))) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(
                        (accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData))
                    - (accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)));
                }

                //Logger.Trace("ENDED:    Get to Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetDeferredBalance " + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Fees And Charges Paid Last Month operation.");

                var result = (from s in accountsModel.TransactionRecordModelList
                              where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                              && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                              select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                if (result != null)
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                    Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData) -
                    Convert.ToDecimal(result));
                }
                else
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                   Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));

                }
                //Logger.Trace("ENDED:    Get to Fees And Charges Paid Last Month operation.");
                return FeesAndChargesPaidLastMonth;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetFeesAndChargesPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Last Month operation.");
                decimal total = 0;
                foreach (var tra in accountModel.TransactionRecordModelList)
                {
                    total +=
                           Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Evar_PackedData) +
                           CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_2) +
                           CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_3) +
                           CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_4) +
                           CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_5);
                }
                //Logger.Trace("ENDED:    Get to Unapplied Funds Paid Last Month operation.");
                return UnappliedFundsPaidLastMonth = Convert.ToString(total);

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetUnappliedFundsPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Paid Last Month operation.");

                var result = (from s in accountsModel.TransactionRecordModelList
                              where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                              && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                              select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                if (result != null)
                { 
                    //Need to know and Add PriorMoAmnt in this section
                    TotalPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData)
                        - Convert.ToDecimal(result)
                        + Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt));
                }
                else
                {
                    TotalPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData)
                        + Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt));
                }
                //Logger.Trace("ENDED:    Get to Total Paid Last Month operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Fees And Charges Paid Year to Date operation.");
                var total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData);

                var result = (from s in accountModel.TransactionRecordModelList
                              where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                              && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                              select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                if (result != null)
                {
                    FeesAndChargesPaidYeartoDate = Convert.ToString(total
                        - Convert.ToDecimal(result));
                }
                else
                {
                    FeesAndChargesPaidYeartoDate = Convert.ToString(total);
                }
                //Logger.Trace("ENDED:    Get to Fees And Charges Paid Year to Date operation.");
                return FeesAndChargesPaidYeartoDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetFeesAndChargesPaidYeartoDate " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Year To Date operation.");
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
                //Logger.Trace("ENDED:    Get to Unapplied Funds Paid Year To Date operation.");
                return UnappliedFundsPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetUnappliedFundsPaidYearToDate " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Paid Year To Date operation.");
                var Total = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                    + (accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0)
                    + Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt));

                var result = (from s in accountModel.TransactionRecordModelList
                              where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                              && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                              select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                if (result != null)
                {
                    TotalPaidYearToDate = Convert.ToString(Convert.ToDecimal(Total)
                        - Convert.ToDecimal(result));
                }
                else
                {
                    TotalPaidYearToDate = Total;
                }

                //Logger.Trace("ENDED:    Get to Get Total Paid Year To Date operation.");
                return TotalPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaidYearToDate " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetSuspense(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Get Suspense operation.");
                decimal total = 0;
                foreach (var tra in accountModel.TransactionRecordModelList)
                {
                    total +=
                Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Evar_PackedData) +
                 CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_2) +
                 CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_3) +
                 CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_4) +
                 CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_5);
                }
                //Logger.Trace("ENDED:    Get to Get Total Paid Year To Date operation.");
                return Suspense  =Convert.ToString(total);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetSuspense " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Miscellaneous operation.");
                decimal total = 0;
                foreach (var tra in accountModel.TransactionRecordModelList)
                {
                 total += Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Lip_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Cr_Ins_PackedData) +
                         CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Pi_Shrtg) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Prin_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Int_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) +
                          Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Optins_PackedData);

                }
                Miscellaneous = Convert.ToString(total);
                //Logger.Trace("ENDED:    To Miscellaneous operation.");
                return Miscellaneous;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMiscellaneous " + ex.TargetSite.Name);
                return "";
            }
        }



        #region  New Method ==>

        public string GetPrintStatement(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Print Statement operation.");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    PrintStatement = string.Empty;
                }
                //Logger.Trace("ENDED:    To Print Statement operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrintStatement" + ExMessage);
            }
            return PrintStatement;
        }
        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel, bool isCoborrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Primary Borrower BK Attorney operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" ||
                   accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == null)
                {
                    PrimaryBorrowerBKAttorney = string.Empty;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    PrimaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    PrimaryBorrowerBKAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    PrimaryBorrowerBKAttorney = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;

                }
                //Logger.Trace("ENDED:    To Print Primary Borrower BK Attorney operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrimaryBorrowerBKAttorney " + ex.TargetSite.Name);
            }
            return PrimaryBorrowerBKAttorney;
        }

        public string GetSecondaryBorrower(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Secondary Borrower operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                    || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    SecondaryBorrower = accountModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
                }
                //Logger.Trace("ENDED:    To Secondary Borrower operation.");              
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetSecondaryBorrower " + ex.TargetSite.Name);
            }
            return SecondaryBorrower;
        }

        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel, bool isCoborrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Mailing BK Attorney AddressLine1 operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBKAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBKAttorneyAddressLine1 = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;

                }
                //Logger.Trace("ENDED:    To Mailing BK Attorney AddressLine1 operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingBKAttorneyAddressLine1 " + ex.TargetSite.Name);
                return "";
            }
            return MailingBKAttorneyAddressLine1;
        }

        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel, bool isCoborrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Mailing BK Attorney AddressLine2 operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBKAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBKAttorneyAddressLine2 = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;

                }                //Logger.Trace("ENDED:    To Mailing BK Attorney AddressLine2 operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingBKAttorneyAddressLine2 " + ex.TargetSite.Name);
            }
            return MailingBKAttorneyAddressLine2;
        }
        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Borrower Attorney Mailing City State Zip operation.");
                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    BorrowerAttorneyMailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    BorrowerAttorneyMailingCityStateZip = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City + "," +
                         accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + "," +
                         accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                }
                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    if (!isCoBorrower)
                        BorrowerAttorneyMailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                    {

                        BorrowerAttorneyMailingCityStateZip = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City + "," +
                                     accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + "," +
                                     accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                    }
                }
                //Logger.Trace("ENDED:    To Borrower Attorney Mailing City State Zip operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBorrowerAttorneyMailingCityStateZip " + ex.TargetSite.Name);
            }
            return BorrowerAttorneyMailingCityStateZip;
        }

        public string GetMailingCountry(AccountsModel accountsModel, bool isCoBorrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Mailing Country operation.");
                if (accountsModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Altr_Cntry;
                }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country;
                }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                {
                    if (isCoBorrower)
                        MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Appl_Country;
                    else
                        MailingCountry = "null";
                }
                else
                {
                    MailingCountry = "null";
                }
                //Logger.Trace("ENDED:    To Mailing Country operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingCountry " + ex.TargetSite.Name);
            }
            return MailingCountry;
        }

        public string GetInterest(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest operation.");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData != null
                    && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    Interest = "0.00";
                else if (accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null
                    && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    Interest = "0.00";
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null
                    && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null && CommonHelper.GetDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))))
                    Interest = "0.00";
                //Logger.Trace("ENDED:    To Interest operation.");


            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterest " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
            return Interest;
        }
        public string GetEscrowTaxesandInsurance(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Escrow Taxes and Insurance operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowTaxesandInsurance = "0.00";
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    EscrowTaxesandInsurance = "0.00";
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null &&
                    CommonHelper.GetDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))))
                    EscrowTaxesandInsurance = "0.00";
                //Logger.Trace("ENDED:    To Escrow Taxes and Insurance operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowTaxesandInsurance" + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
            return EscrowTaxesandInsurance;
        }
        public string GetRegularMonthlyPayment(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPayment = "0.00";
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null &&
                    CommonHelper.GetDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))))
                    RegularMonthlyPayment = "0.00";
                //Logger.Trace("ENDED:    To Regular Monthly Payment operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPayment" + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
            return RegularMonthlyPayment;
        }
        public string GetBuydownBalance(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Buy down Balance operation.");
                if (Convert.ToDecimal(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                    BuydownBalance = "N/A";
                else
                    BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                //Logger.Trace("ENDED:    To Buy down Balance operation.");


            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBuydownBalance " + ex.TargetSite.Name);
            }
            return BuydownBalance;
        }
        public string GetPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Partial Claim operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                    PartialClaim = "N/A";
                else
                    PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                //Logger.Trace("ENDED:    To Partial Claim operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPartialClaim " + ex.TargetSite.Name);
            }
            return PartialClaim;
        }
        public string GetInterestRateUntil(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest Rate Until operation.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                    InterestRateUntil = "Until " + CommonHelper.GetDateInDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date);
                else
                    InterestRateUntil = null;
                //Logger.Trace("ENDED:    To Interest Rate Until operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestRateUntil " + ex.TargetSite.Name);
            }
            return InterestRateUntil;
        }

        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Prepayment Penalty operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                    PrepaymentPenalty = "Yes";
                else
                    PrepaymentPenalty = "No";
                //Logger.Trace("ENDED:    To Prepayment Penalty operation.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrepaymentPenalty " + ex.TargetSite.Name);
            }
            return PrepaymentPenalty;
        }
        public string GetCarringtonFoundationDonationPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Carrington Foundation Donation Paid Last Month operation.");

                if (Convert.ToDecimal(accountModel.detModel.PriorMoAmnt) > 0
                    || Convert.ToDecimal(accountModel.detModel.YTDAmnt) > 0)
                {
                    CarringtonFoundationDonationPaidLastMonth = "CharitableFoundation_MessageFlag";
                }
                //Logger.Trace("ENDED:    To Carrington Foundation Donation Paid Last Month operation.");
                return CarringtonFoundationDonationPaidLastMonth;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCarringtonFoundationDonationPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetCarringtonFoundationDonationPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Carrington Foundation Donation Paid Year To Date operation.");

                if (Convert.ToDecimal(accountModel.detModel.PriorMoAmnt) > 0
                    || Convert.ToDecimal(accountModel.detModel.YTDAmnt) > 0)
                {
                    CarringtonFoundationDonationPaidYearToDate = "CharitableFoundation_MessageFlag";
                }
                //Logger.Trace("ENDED:    To Carrington Foundation Donation Paid Year To Date operation.");
                return CarringtonFoundationDonationPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCarringtonFoundationDonationPaidYearToDate " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetPostPetitonPastDueMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Post Petiton Past Due Message operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null)
                {
                    TimeSpan timeSpan = CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Run_Date) -
                                    CommonHelper.GetDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date);
                    if (timeSpan.Days >= 45)
                        PostPetitonPastDueMessage = "We have not received all of your mortgage payments due since you filed for bankruptcy.";
                }
                //Logger.Trace("ENDED:    To Post Petiton Past Due Message operation.");
                return PostPetitonPastDueMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPostPetitonPastDueMessage " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }

        public string GetCMSPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to CMS Partial Claim operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                    && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                    CMSPartialClaim = "CMSPartialClaim_MessageFlag";
                //Logger.Trace("ENDED:    To CMS Partial Claim operation.");
                return CMSPartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCMSPartialClaim " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetHUDPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get HUD Partial Claim operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                    && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                    HUDPartialClaim = "HUDPartialClaim_MessageFlag"; 
                //Logger.Trace("ENDED:    To HUD Partial Claim operation.");
                return HUDPartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetHUDPartialClaim " + ex.TargetSite.Name);
                return "";
            }
        }
        
        public string GetPOBoxAddress(AccountsModel accountModel)
        {
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Payment Information Message");
                if (mailingState.Any(m => m == "KS")
                    || mailingState.Any(m => m == "LA")
                    || mailingState.Any(m => m == "NM")
                    || mailingState.Any(m => m == "OK")
                    || mailingState.Any(m => m == "TX"))
                {
                    POBoxAddress = "PO Box 660586 Dallas, " + mailingAddress + " 75266-0586";
                }
                else
                {
                    POBoxAddress = "PO Box 7006 Pasadena, " + mailingAddress + " 91109-9998";
                }
                //Logger.Trace("ENDED:  To Get Payment Information Message");
                return POBoxAddress;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPOBoxAddress " + ex.TargetSite.Name);
                return "";
            }
            //try
            //{
            //    //Logger.Trace("STARTED:  Execute to Get POBox Address operation.");
            //    if (accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
            //         || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA"
            //         || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM"
            //         || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
            //         || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
            //    {
            //        POBoxAddress = "PO Box 660586 Dallas, " + accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + " 75266-0586";
            //    }
            //    else
            //    {
            //        POBoxAddress = "PO Box 7006 Pasadena, " + accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + " 91109-9998";
            //    }
            //    //Logger.Trace("ENDED:    To POBox Address operation.");
            //    return POBoxAddress;
            //}

            //catch (Exception ex)
            //{
            //    Logger.Error(ex, "GetPOBoxAddress " + ex.TargetSite.Name);
            //    return "";
            //}
        }
        //public string GetDate(AccountsModel accountModel)
        //{
        //    if (accountModel.FeeRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Date = accountModel.FeeRecordModel.RSSI_FEE_DATE_ASSESSED;
        //    else
        //        Date = accountModel.MasterFileDataPart_1Model.Rssi_Bank_Trans_PackedData;
        //    return Date;

        //}
        //public string GetAmount(AccountsModel accountModel)
        //{
        //    if (Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData;
        //    else if (accountModel.TransactionRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Amount = accountModel.TransactionRecordModel.RSSI_FEE_AMT_ASSESSED;
        //    else
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData;
        //    return Amount;

        //}
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Lender Placed Insurance Message operation.");
                if ((accountModel.EscrowRecordModel.Any(r => r.rssi_esc_type == "20")
                      || accountModel.EscrowRecordModel.Any(r => r.rssi_esc_type == "21")
                      && accountModel.EscrowRecordModel.Any(r => r.Rssi_Ins_Co == "2450")
                     && (accountModel.EscrowRecordModel.Any(er => er.Rssi_Ins_Ag == "29000")
                      || accountModel.EscrowRecordModel.Any(eri => eri.Rssi_Ins_Ag == "29005")
                     || accountModel.EscrowRecordModel.Any(ins => ins.Rssi_Ins_Ag == "43000")
                       || accountModel.EscrowRecordModel.Any(insg => insg.Rssi_Ins_Ag == "43001"))))
                {
                    LenderPlacedInsuranceMessage = "LenderPlacedInsurance_MessageFlag";
                }
                //Logger.Trace("ENDED:    To Lender Placed Insurance Message operation.");
                return LenderPlacedInsuranceMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLenderPlacedInsuranceMessage " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetStateNSF(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get State NSF operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6)
                {
                    StateDisclosures = "StateDisclosures6_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16)
                {
                    StateDisclosures = "StateDisclosures16_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18)
                {
                    StateDisclosures = "StateDisclosures18_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42)
                {
                    StateDisclosures = "StateDisclosures42_MessageFlag";
                }
                //Logger.Trace("ENDED:    To State NSF operation.");
                return StateDisclosures;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateNSF " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetAutodraftMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Auto draft Message operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 &&
                       Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft_MessageFlag";
                }
                else
                {
                    AutodraftMessage = accountModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData;
                }
                //Logger.Trace("ENDED:    To Auto draft Message operation.");
                return AutodraftMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAutodraftMessage " + ex.TargetSite.Name);
                return "";
            }
        }

        //What to do if the condition is satisfied
        public string GetStateDisclosures(AccountsModel accountModel)
        {
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());
            try
            {
                //Logger.Trace("STARTED:  Execute to Get State Disclosures operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 4
                      && mailingState.Any(m => m == "AR")) 
                {
                    StateDisclosures = "StateDisclosures4AR_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                    && mailingState.Any(m => m == "CO"))
                {
                    StateDisclosures = "StateDisclosures6CO_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 12
                    && mailingState.Any(m => m == "HI"))
                {
                    StateDisclosures = "StateDisclosures12HI_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 22
                    && mailingState.Any(m => m == "MA")) 
                {
                    StateDisclosures = "StateDisclosures4AR_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 24
                    && mailingState.Any(m => m == "MN")) 
                {
                    StateDisclosures = "StateDisclosures24MN_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && mailingState.Any(m => m == "NC"))
                {
                    StateDisclosures = "StateDisclosures33NC_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 34
                    && mailingState.Any(m => m == "NY"))
                {
                    StateDisclosures = "StateDisclosures34NY_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 43
                   && mailingState.Any(m => m == "TN"))
                {
                    StateDisclosures = "StateDisclosures43TN_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 44
                   && mailingState.Any(m => m == "TX")) 
                {
                    StateDisclosures = "StateDisclosures44TX_MessageFlag";
                }
                //Logger.Trace("ENDED:    To State Disclosures operation.");
                return StateDisclosures;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateDisclosures " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Carrington Charitable Foundation operation.");
                if (accountModel.detModel.Eligible != null
                   && accountModel.detModel.PriorMoAmnt != null
                   && accountModel.detModel.YTDAmnt != null)
                {
                    if (accountModel.detModel.Eligible == "Yes"
                        || Convert.ToDecimal(accountModel.detModel.PriorMoAmnt) > 0
                        || Convert.ToDecimal(accountModel.detModel.YTDAmnt) > 0)
                    {
                        CarringtonCharitableFoundation = "CharitableFoundation_MessageFlag"; 
                    }
                }
                //Logger.Trace("ENDED:    To Carrington Charitable Foundation operation.");
                return CarringtonCharitableFoundation;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCarringtonCharitableFoundation " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Payment Information Message");
                if (mailingState.Any(m => m == "KS")
                    || mailingState.Any(m => m == "LA")
                    || mailingState.Any(m => m == "NM")
                    || mailingState.Any(m => m == "OK")
                    || mailingState.Any(m => m == "TX"))
                {
                    PaymentInformationMessage = "PO Box 660586 Dallas, " + mailingAddress + " 75266-0586";
                }
                else
                {
                    PaymentInformationMessage = "PO Box 7006 Pasadena, " + mailingAddress + " 91109-9998";
                }
                //Logger.Trace("ENDED:  To Get Payment Information Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentInformationMessage " + ex.TargetSite.Name);
            }
            return PaymentInformationMessage;
        }
        #endregion
    }
}