using HelocService.Helpers;
using HelocService.Models.InputCopyBookModels;
using HelocService.Helpers;
using System;
using System.Linq;
using System.Text;

namespace HelocService.BillingStatements
{
    public class OptionARMBillingStatement : IOptionARMBillingStatement
    {
        public OptionARMBillingStatement(ILogger logger)
        {
            Logger = logger;
        }
        #region Object Declaration  ==>
        public ILogger Logger;
        public string ExMessage { get; set; }

        public StringBuilder finalLine;

        #endregion

        #region public Property ==>
        public string AmountDueOption1 { get; set; }
        public string AmountDueOption2 { get; set; }
        public string AmountDueOption3 { get; set; }
        public string AmountDueOption4 { get; set; }
        public string PastDueBalance { get; set; }
        public string DeferredBalance { get; set; }
        public string UnappliedFunds { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string FeesandChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string PrincipalOption1 { get; set; }
        public string AssistanceAmountOption1 { get; set; }
        public string ReplacementReserveOption1 { get; set; }
        public string OverduePaymentsOption1 { get; set; }
        public string TotalFeesChargedOption1 { get; set; }
        public string TotalFeesPaidOption1 { get; set; }
        public string TotalAmountDueOption1 { get; set; }
        public string PrincipalOption2 { get; set; }
        public string AssistanceAmountOption2 { get; set; }
        public string ReplacementReserveOption2 { get; set; }
        public string OverduePaymentsOption2 { get; set; }
        public string TotalFeesChargedOption2 { get; set; }
        public string TotalFeesPaidOption2 { get; set; }
        public string TotalAmountDueOption2 { get; set; }
        public string PrincipalOption3 { get; set; }
        public string AssistanceAmountOption3 { get; set; }
        public string ReplacementReserveOption3 { get; set; }
        public string OverduePaymentsOption3 { get; set; }
        public string TotalFeesChargedOption3 { get; set; }
        public string TotalFeesPaidOption3 { get; set; }
        public string TotalAmountDueOption3 { get; set; }
        public string PrincipalOption4 { get; set; }
        public string AssistanceAmountOption4 { get; set; }
        public string ReplacementReserveOption4 { get; set; }
        public string OverduePaymentsOption4 { get; set; }
        public string TotalFeesChargedOption4 { get; set; }
        public string TotalFeesPaidOption4 { get; set; }
        public string TotalAmountDueOption4 { get; set; }
        public string MinimumLatePaymentAmount { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string TotalDue { get; set; }

        public string Hold { get; set; }
        public string Attention { get; set; }
        public string PrimaryBorrower { get; set; }
        public string MailingCountry { get; set; }
        public string PaymentIsReceivedAfter { get; set; }
        public string LateFee { get; set; }
        public string ChargeOffNoticeNoticeMessage { get; set; }
        public string NegativeAmortization { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }

        public string InterestOption1 { get; set; }
        public string EscrowOption1 { get; set; }
        public string RegularMonthlyPaymentOption1 { get; set; }
        public string InterestOption2 { get; set; }
        public string EscrowOption2 { get; set; }
        public string RegularMonthlyPaymentOption2 { get; set; }
        public string InterestOption3 { get; set; }
        public string EscrowOption3 { get; set; }
        public string RegularMonthlyPaymentOption3 { get; set; }
        public string InterestOption4 { get; set; }
        public string EscrowOption4 { get; set; }
        public string RegularMonthlyPaymentOption4 { get; set; }
        public string Option4MinimumDescription { get; set; }

        public string POBoxAddress { get; set; }
        public string DueDate { get; set; }
        public string IfReceivedAfterDate { get; set; }
        public string LateChargeAmount { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string ModificationDate { get; set; }
        public string MaturityDate { get; set; }
        public string DelinquencyNoticebox { get; set; }
        public string LossMitigtationNotice { get; set; }
        public string ForeclosureNotice { get; set; }
        public string ACHMessage { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string BankruptcyMessage { get; set; }
        public string RepaymentPlanMessage { get; set; }
        public string StateNSFMessage { get; set; }
        public string ChargeOffNotice { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string StateDisclosures { get; set; }
        public string PaymentInformationMessage { get; set; }

        public string RecentPayment6 { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; private set; }
        public string MailingCityStateZip { get; private set; }
        public string IfPaymentisReceivedAfter { get; private set; }
        public string chargeOffNotice { get; private set; }
        public string stateDisclosures { get; private set; }
        public string paymentInformationMessage { get; private set; }

        #endregion
        public StringBuilder GetFinalOptionARMBillingStatement(AccountsModel accountsModel, bool isCoBorrower = false)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();

            finalLine.Append(GetTotalFeesChargedOption1(accountsModel) + "|");
            finalLine.Append(GetDeferredBalance(accountsModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption4(accountsModel) + "|");

            finalLine.Append(GetAmountDueOption1(accountsModel) + "|");
            finalLine.Append(GetAmountDueOption2(accountsModel) + "|");
            finalLine.Append(GetAmountDueOption3(accountsModel) + "|");
            finalLine.Append(GetAmountDueOption4(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption1(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption1(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption1(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption1(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption2(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption2(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption2(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption2(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption2(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption2(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption3(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption3(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption3(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption3(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption3(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption3(accountsModel) + "|");
            finalLine.Append(GetPrincipalOption4(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption4(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption4(accountsModel) + "|");
            finalLine.Append(GetOverduePaymentsOption4(accountsModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption4(accountsModel) + "|");
            finalLine.Append(GetTotalAmountDueOption4(accountsModel) + "|");
            finalLine.Append(GeUnappliedFundsPaidLastMonth(accountsModel) + "|");
            finalLine.Append(GetFeesandChargesPaidYeartoDate(accountsModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountsModel) + "|");
            finalLine.Append(GeSuspense(accountsModel) + "|");
            finalLine.Append(GetMiscellaneous(accountsModel) + "|");
            finalLine.Append(GetTotalDue(accountsModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountsModel) + "|");
            finalLine.Append(GetUnappliedFunds(accountsModel) + "|");
            finalLine.Append(GetPastDueBalance(accountsModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountsModel) + "|");
            finalLine.Append(GetAssistanceAmountOption1(accountsModel) + "|");
            finalLine.Append(GetReplacementReserveOption1(accountsModel) + "|");
            finalLine.Append(GetMinimumLatePaymentAmount(accountsModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption3(accountsModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption2(accountsModel) + "|");

            finalLine.Append(GetHold(accountsModel) + "|");
            finalLine.Append(GetAttention(accountsModel, isCoBorrower) + "|");
            finalLine.Append(GetPrimaryBorrower(accountsModel, isCoBorrower) + "|");
            finalLine.Append(GetSecondaryBorrower(accountsModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingAddressLine1(accountsModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingAddressLine2(accountsModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingCityStateZip(accountsModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingCountry(accountsModel) + "|");
            finalLine.Append(GetPaymentIsReceivedAfter(accountsModel) + "|");
            finalLine.Append(GetLateFee(accountsModel) + "|");
            finalLine.Append(GetChargeOffNoticeNoticeMessage(accountsModel) + "|");
            finalLine.Append(GetNegativeAmortization(accountsModel) + "|");
            finalLine.Append(GetBuydownBalance(accountsModel) + "|");
            finalLine.Append(GetPartialClaim(accountsModel) + "|");
            finalLine.Append(GetInterestOption1(accountsModel) + "|");
            finalLine.Append(GetEscrowOption1(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption1(accountsModel) + "|");
            finalLine.Append(GetInterestOption2(accountsModel) + "|");
            finalLine.Append(GetEscrowOption2(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption2(accountsModel) + "|");
            finalLine.Append(GetInterestOption3(accountsModel) + "|");
            finalLine.Append(GetEscrowOption3(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption3(accountsModel) + "|");
            finalLine.Append(GetInterestOption4(accountsModel) + "|");
            finalLine.Append(GetEscrowOption4(accountsModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption4(accountsModel) + "|");
            finalLine.Append(GetOption4MinimumDescription(accountsModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountsModel) + "|");
            finalLine.Append(GetReceivedAfterDate(accountsModel) + "|");
            finalLine.Append(GetLateChargeAmount(accountsModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountsModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountsModel) + "|");
            finalLine.Append(GetModificationDate(accountsModel) + "|");
            finalLine.Append(GetMaturityDate(accountsModel) + "|");
            finalLine.Append(GetDelinquencyNoticebox(accountsModel) + "|");
            finalLine.Append(GetLossMitigtationNotice(accountsModel) + "|");
            finalLine.Append(GetForeclosureNotice(accountsModel) + "|");
            finalLine.Append(GetACHMessage(accountsModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountsModel) + "|");
            finalLine.Append(GetBankruptcyMessage(accountsModel) + "|");
            finalLine.Append(GetRepaymentPlanMessage(accountsModel) + "|");
            finalLine.Append(GetStateNSFMessage(accountsModel) + "|");
            finalLine.Append(GetChargeOffNotice(accountsModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountsModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountsModel) + "|");
            finalLine.Append(GetStateDisclosures(accountsModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountsModel) + "|");
            finalLine.Append(GetRecentPayment6(accountsModel) + "|");
            finalLine.Append(GetRecentPayment5(accountsModel) + "|");
            finalLine.Append(GetRecentPayment4(accountsModel) + "|");
            finalLine.Append(GetRecentPayment3(accountsModel) + "|");
            finalLine.Append(GetRecentPayment2(accountsModel) + "|");
            finalLine.Append(GetRecentPayment1(accountsModel) + "|");
            return finalLine;
        }


        /* While Calculating Conditions must be applied*/

        #region Calculation ==>>


        /// <summary>
        /// 11
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption1(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option 1 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption1 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption1 = "N/A";
                }
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                }
                //Logger.Trace("ENDED:   To Amount Due Option 1 operation.");
                return AmountDueOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption1" + ex.TargetSite.Name);
                return "";
            }

        }
        /// <summary>
        /// 12
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption2(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option 2 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption2 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else
                {
                    AmountDueOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                }
                //Logger.Trace("ENDED:   To Amount Due Option 2 operation.");
                return AmountDueOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption2" + ex.TargetSite.Name);
                return "";
            }

        }
        /// <summary>
        /// 13
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption3(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option 3 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption3 = "0";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else
                {
                    AmountDueOption3 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                //Logger.Trace("ENDED:   To Amount Due Option 3 operation.");
                return AmountDueOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 14
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAmountDueOption4(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option 4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption4 = "0";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption4 = "N/A";
                }
                else
                {
                    AmountDueOption4 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                        Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }

                //Logger.Trace("ENDED:   To Amount Due Option 4 operation.");
                return AmountDueOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAmountDueOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 21
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPastDueBalance(AccountsModel model)
        {
            try
            {
                PastDueBalance = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                     Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                     Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPastDueBalance" + ex.TargetSite.Name);
                return "";
            }
            return PastDueBalance;
        }
        /// <summary>
        /// 22
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel model)
        {

            try
            {

                if (Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) -
                Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) -
                   Convert.ToDecimal(model.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                //Logger.Trace("ENDED:    To Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetDeferredBalance" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 26
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            try
            {
                UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
                return UnappliedFunds;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalDue" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 31
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetFeesAndChargesPaidLastMonth(AccountsModel model)
        {

            try
            {
                return Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                     Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalDue" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 32
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GeUnappliedFundsPaidLastMonth(AccountsModel model)
        {
            try
            {
                decimal total = 0;
                foreach (var tra in model.TransactionRecordModelList)
                {
                    total += Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Evar_PackedData)
                         +  CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_2)
                         +  CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_3)
                         +  CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_4)
                         + CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_5);

                }
                return UnappliedFundsPaidLastMonth = Convert.ToString(total);

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GeUnappliedFundsPaidLastMonth" + ex.TargetSite.Name);
                return "";
            }

        }
        /// <summary>
        /// 37
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetFeesandChargesPaidYeartoDate(AccountsModel model)
        {
            try
            {
                return Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +
                                           Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetFeesandChargesPaidYeartoDate" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 38
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
                return UnappliedFundsPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetUnappliedFundsPaidYearToDate" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 39
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {


            try
            {
                TotalPaidYearToDate = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                                         + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                                         + accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                                         + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));


                return TotalPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaidYearToDate" + ex.TargetSite.Name);
                return "";
            }

        }

        /// <summary>
        /// 41
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption1(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option 1 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PrincipalOption1 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    PrincipalOption1 = "null";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PrincipalOption1 = "null";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PrincipalOption1 = "null";
                }
                else
                {
                    PrincipalOption1 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData) -
                                            Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }

                //Logger.Trace("ENDED:   To Principal Option 1 operation.");
                return PrincipalOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 44
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAssistanceAmountOption1(AccountsModel model)
        {

            try
            {
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption1 = string.Empty; //"then do not print the Assistance Amount line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AssistanceAmountOption1 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption1 = "0.00";
                }
                else
                {
                    AssistanceAmountOption1 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                return AssistanceAmountOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 45
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetReplacementReserveOption1(AccountsModel model)
        {
            try
            {

                if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                     + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption1 = string.Empty; // "then do not print the Replacement Reserve line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    ReplacementReserveOption1 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption1 = "0.00";
                }
                else
                {
                    ReplacementReserveOption1 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                            - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                        - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0);
                }
                return ReplacementReserveOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 47
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetOverduePaymentsOption1(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 1 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else
                {
                    //not found total fees paid
                    OverduePaymentsOption1 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption1(model) != "null" ? GetTotalFeesPaidOption1(model) : "0.00"));
                }
                //Logger.Trace("ENDED:   To Overdue Payments Option 1 operation.");
                return OverduePaymentsOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 48
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to get Total Fees Charged Option1 operation.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption1 = "null";
                }
                else
                {

                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                             + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    var result = (from s in accountsModel.TransactionRecordModelList
                                  where s.Rssi_Log_Tran == "5605"
                                  && s.Rssi_Tr_Fee_Code == "67"
                                  select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                    var res = (from s in accountsModel.TransactionRecordModelList
                               where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                               && s.Rssi_Tr_Fee_Code == "198"
                               select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                    if (result != null)
                    {
                        Total -= Convert.ToDecimal(result);
                    }
                    else if (res != null)
                    {
                        Total -= Convert.ToDecimal(res);
                    }
                    //else
                    //{
                    //    TotalFeesChargedOption1 = Convert.ToString(Total);
                    //}
                    TotalFeesChargedOption1 = Convert.ToString(Total);
                }
                //Logger.Trace("ENDED:    Total Fees Charged Option1 operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption1" + ex.TargetSite.Name);
                return "";
            }
            return TotalFeesChargedOption1;
        }
        /// <summary>
        /// 49
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalFeesPaidOption1(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 1 operation.");
                // need to check
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";


                else if ((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(GetTotalFeesChargedOption1(model) != "null" ? GetTotalFeesChargedOption1(model) : "0.00"))
                {
                    TotalFeesPaidOption1 = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesChargedOption1(model) != "null" ? GetTotalFeesChargedOption1(model) : "0.00")));
                }
                else
                    TotalFeesPaidOption1 = "0.00";
                //Logger.Trace("ENDED:   Total Fees Paid Option 1 operation.");
                return TotalFeesPaidOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 50
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalAmountDueOption1(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total AmountDue Option 1 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption1 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalAmountDueOption1 = "Option Not Available";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption1 = "Option Not Available";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption1 = "Option Not Available";

                else
                    TotalAmountDueOption1 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));

                //Logger.Trace("ENDED:   Get Total AmountDue Option 1 operation.");
                return TotalAmountDueOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 51
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption2(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption2 = "null";
                else
                {
                    PrincipalOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:   Get Principal Option2 operation.");
                return PrincipalOption2;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 54
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAssistanceAmountOption2(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = string.Empty; // "do not print the Assistance Amount line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";

                else
                {
                    AssistanceAmountOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                //Logger.Trace("ENDED:   Get Assistance Amount Option 2 operation.");
                return AssistanceAmountOption2;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 55
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetReplacementReserveOption2(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option2 operation.");

                if ((Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                   - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                    - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                   + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption2 = string.Empty; // "do not print the Replacement Reserve line";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else
                {
                    ReplacementReserveOption2 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                                - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                                - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }

                //Logger.Trace("ENDED:   Get Replacement Reserve Option2 operation.");
                return ReplacementReserveOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 57
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetOverduePaymentsOption2(AccountsModel model)
        {
            //what is - Total Fees Paid
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";


                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption2(model) != "null" ? GetTotalFeesPaidOption2(model) : "0.00"));
                }
                //Logger.Trace("ENDED:   Get Overdue Payments Option 2 operation.");
                return OverduePaymentsOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 58
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption2 = "null";
                }
                else
                {
                    //var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                    //+ Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    //if (Convert.ToDecimal(accountsModel.TransactionRecordModelList.Rssi_Log_Tran) == 5605
                    //    && (Convert.ToDecimal(accountsModel.TransactionRecordModelList.Rssi_Tr_Fee_Desc) == 67))
                    //{
                    //    Total = Total - Convert.ToDecimal(accountsModel.TransactionRecordModelList.Rssi_Tr_Amt_PackedData);
                    //}
                    //if ((Convert.ToDecimal(accountsModel.TransactionRecordModelList.Rssi_Log_Tran) == 5605
                    //     || Convert.ToDecimal(accountsModel.TransactionRecordModelList.Rssi_Log_Tran) == 5707)
                    //     && (Convert.ToDecimal(accountsModel.TransactionRecordModelList.Rssi_Tr_Fee_Desc) == 198))
                    //{
                    //    Total = Total - Convert.ToDecimal(accountsModel.TransactionRecordModelList.Rssi_Tr_Amt_PackedData);
                    //}
                    //else
                    //{
                    //    TotalFeesChargedOption2 = Convert.ToString(Total);
                    //}
                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                                + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    var result = (from s in accountsModel.TransactionRecordModelList
                                  where s.Rssi_Log_Tran == "5605"
                                  && s.Rssi_Tr_Fee_Code == "67"
                                  select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                    var res = (from s in accountsModel.TransactionRecordModelList
                               where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                               && s.Rssi_Tr_Fee_Code == "198"
                               select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                    if (result != null)
                    {
                        Total -= Convert.ToDecimal(result);
                    }
                    else if (res != null)
                    {
                        Total -= Convert.ToDecimal(res);
                    }

                    TotalFeesChargedOption1 = Convert.ToString(Total);
                }
                return TotalFeesChargedOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 59
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalFeesPaidOption2(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 2 operation.");

                // need to check
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if ((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                          -Convert.ToDecimal(GetTotalFeesChargedOption2(model) != "null" ? GetTotalFeesChargedOption2(model) : "0.00"))
                {
                    TotalFeesPaidOption2 = Convert.ToString((Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesChargedOption2(model) != "null" ? GetTotalFeesChargedOption2(model) : "0.00")));
                }
                else
                    TotalFeesPaidOption2 = "0.00";
                //Logger.Trace("ENDED:   Get Total Fees Paid Option 2 operation.");
                return TotalFeesPaidOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 60
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalAmountDueOption2(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Amount Due Option 2 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption2 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalAmountDueOption2 = "Option Not Available";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption2 = "Option Not Available";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption2 = "Option Not Available";

                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                //Logger.Trace("ENDED:   Get Total Amount Due Option 2 operation.");
                return TotalAmountDueOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 61
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption3(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option 3 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption3 = "0.00";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    PrincipalOption3 = "null";

                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption3 = "null";

                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption3 = "null";

                else
                {
                    PrincipalOption3 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                     - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:   Get Principal Option 3 operation.");
                return PrincipalOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 64
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAssistanceAmountOption3(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 3 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption3 = string.Empty; //"then do not print the Assistance Amount line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption3 = "0.00";
                }
                else
                {
                    AssistanceAmountOption3 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                //Logger.Trace("ENDED:   Get Assistance Amount Option 3 operation.");
                return AssistanceAmountOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 65
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetReplacementReserveOption3(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option 3 operation.");

                if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                    - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption3 = string.Empty; // "then do not print the Replacement Reserve line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption3 = "0.00";
                }
                else
                {
                    ReplacementReserveOption3 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) -
                                             Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData) -
                                              Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData) +
                                             Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));
                }
                //Logger.Trace("ENDED:   Get Replacement Reserve Option 3 operation.");
                return ReplacementReserveOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 67
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetOverduePaymentsOption3(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 3 operation.");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    OverduePaymentsOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption3 = "null";
                else
                {
                    OverduePaymentsOption3 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                         - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                                          - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                        - Convert.ToDecimal(GetTotalFeesPaidOption3(accountsModel) != "null" ? GetTotalFeesPaidOption3(accountsModel) : "0.00"));
                }

                //Logger.Trace("ENDED:   Get Replacement Overdue Payments Option 3 operation.");
                return OverduePaymentsOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 68
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption3 = "null";
                }
                else
                {
                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                               + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    var result = (from s in accountsModel.TransactionRecordModelList
                                  where s.Rssi_Log_Tran == "5605"
                                  && s.Rssi_Tr_Fee_Code == "67"
                                  select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                    var res = (from s in accountsModel.TransactionRecordModelList
                               where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                               && s.Rssi_Tr_Fee_Code == "198"
                               select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                    if (result != null)
                    {
                        Total -= Convert.ToDecimal(result);
                    }
                    else if (res != null)
                    {
                        Total -= Convert.ToDecimal(res);
                    }
                }
                return TotalFeesChargedOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 69
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 3 operation.");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                          + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                          Convert.ToDecimal(GetTotalFeesChargedOption3(accountsModel) != "null" ? GetTotalFeesChargedOption3(accountsModel) : "0.00"))
                {
                    TotalFeesPaidOption3 = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesChargedOption3(accountsModel) != "null" ? GetTotalFeesChargedOption3(accountsModel) : "0.00")));
                }
                else
                    TotalFeesPaidOption3 = "0.00";

                //Logger.Trace("ENDED:   Get Total Fees Paid Option 3 operation.");
                return TotalFeesPaidOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 70
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalAmountDueOption3(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Amount Due Option 3 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "0.00";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalAmountDueOption3 = "Option Not Available";
                }
                else
                {
                    TotalAmountDueOption3 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                //Logger.Trace("ENDED:   Get Total Amount Due Option 3 operation.");
                return TotalAmountDueOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 71
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetPrincipalOption4(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option 4 operation.");
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PrincipalOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                {
                    PrincipalOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PrincipalOption4 = "0.00";
                }
                else
                {
                    PrincipalOption4 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                        - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:   Get Principal Option 4 operation.");
                return PrincipalOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipalOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 74
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAssistanceAmountOption4(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Assistance Amount Option 4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption4 = String.Empty; //"then do not print the Assistance Amount line.";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AssistanceAmountOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AssistanceAmountOption4 = "0.00";
                }
                else
                {
                    AssistanceAmountOption4 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                //Logger.Trace("ENDED:   Get Assistance Amount Option 4 operation.");
                return AssistanceAmountOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAssistanceAmountOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 75
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetReplacementReserveOption4(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Replacement ReserveOption 4 operation.");

                if (Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                   - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                    - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                    - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption4 = string.Empty; // "then do not print the Replacement Reserve line.";
                }
                else if (model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData != null && Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    ReplacementReserveOption4 = "0.00";
                }
                else if (model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null && Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    ReplacementReserveOption4 = "0.00";
                }
                else
                {
                    ReplacementReserveOption4 = Convert.ToString(Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                        - Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                        - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                        + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData)
                        );
                }
                //Logger.Trace("ENDED:   Get Replacement ReserveOption 4 operation.");
                return ReplacementReserveOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReplacementReserveOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 77
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetOverduePaymentsOption4(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option 4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    OverduePaymentsOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    OverduePaymentsOption4 = "0.00";
                }
                else
                {
                    //string calvalue = (GetTotalFeesPaidOption3(model));// == null ? 0 : Convert.ToDecimal(GetTotalFeesPaidOption3(model))).ToString();
                    //string calvalue1 = calvalue == "null" ? "0" : calvalue;

                    OverduePaymentsOption4 =
                    Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                        - Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                        - Convert.ToDecimal(GetTotalFeesPaidOption4(model) != "null" ? GetTotalFeesPaidOption4(model) : "0.00"));

                    //(GetTotalFeesPaidOption3(model)==null ? 0:  Convert.ToDecimal(GetTotalFeesPaidOption3(model))) );
                }
                //Logger.Trace("ENDED:   Get Overdue Payments Option 4 operation.");
                return OverduePaymentsOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOverduePaymentsOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 78
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to get Total Fees Charged Option4 operation.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData != null && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "0";
                }
                else if (accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption4 = "0";
                }
                else
                {
                    var Total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                               + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                    var result = (from s in accountsModel.TransactionRecordModelList
                                  where s.Rssi_Log_Tran == "5605"
                                  && s.Rssi_Tr_Fee_Code == "67"
                                  select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                    var res = (from s in accountsModel.TransactionRecordModelList
                               where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                               && s.Rssi_Tr_Fee_Code == "198"
                               select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                    if (result != null)
                    {
                        Total -= Convert.ToDecimal(result);
                    }
                    else if (res != null)
                    {
                        Total -= Convert.ToDecimal(res);
                    }

                    TotalFeesChargedOption4 = Convert.ToString(Total);
                }
                //Logger.Trace("ENDED:   Total Fees Charged Option4 operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesChargedOption4 " + ex.TargetSite.Name);
                return "";
            }
            return TotalFeesChargedOption4;
        }
        /// <summary>
        /// 79
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalFeesPaidOption4(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option 4 operation.");

                //var TotalFeeCharged = Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                //    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesPaidOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesPaidOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                    + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                    < Convert.ToDecimal(GetTotalFeesChargedOption4(model) != "null" ? GetTotalFeesChargedOption4(model) : "0.00"))
                {
                    TotalFeesPaidOption4 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                   + Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                   - Convert.ToDecimal(GetTotalFeesChargedOption4(model) != "null" ? GetTotalFeesChargedOption4(model) : "0.00"));
                }
                else
                {
                    TotalFeesPaidOption4 = "0";
                }
                //Logger.Trace("ENDED:   Get Total Fees Paid Option 4  operation.");
                return TotalFeesPaidOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaidOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 80
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalAmountDueOption4(AccountsModel model)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total AmountDue Option4 operation.");

                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalAmountDueOption4 = "0.00";
                }
                else if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalAmountDueOption4 = "0.00";
                }
                else
                {
                    TotalAmountDueOption4 = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }
                //Logger.Trace("ENDED:   Get  Total AmountDue Option4   operation.");
                return TotalAmountDueOption4;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalAmountDueOption4" + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 96
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetMinimumLatePaymentAmount(AccountsModel model)
        {
            try
            {
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    MinimumLatePaymentAmount = "N/A";
                }
                else
                {
                    MinimumLatePaymentAmount = Convert.ToString(Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) +
                    Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData) +
                    Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData)));
                }
                return MinimumLatePaymentAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMinimumLatePaymentAmount" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 104
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GeSuspense(AccountsModel model)
        {
            try
            {
                decimal total = 0;
                foreach (var tra in model.TransactionRecordModelList)
                {
                    total += Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Evar_PackedData) +
                                CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_2) +
                                CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_3) +
                                CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_4) +
                                CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_5);
                }
                return Suspense = Convert.ToString(total);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GeSuspense" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 105
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetMiscellaneous(AccountsModel model)
        {
            try
            {
                decimal total = 0;
                foreach (var tra in model.TransactionRecordModelList)
                {
                    total +=
                  (tra.Rssi_Tr_Amt_To_Lip_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Lip_PackedData))
                + (tra.Rssi_Tr_Amt_To_Cr_Ins_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Cr_Ins_PackedData))
                + (tra.Rssi_Tr_Amt_To_Pi_Shrtg == null ? 0 : CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Pi_Shrtg))
                + (tra.Rssi_Tr_Amt_To_Def_Prin_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Prin_PackedData))
                + (tra.Rssi_Tr_Amt_To_Def_Int_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Int_PackedData))
                + (tra.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData))
                + (tra.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData))
                + (tra.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData))
                + (tra.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData))
                + (tra.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData))
                + (tra.Rssi_Tr_Amt_To_Def_Optins_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Def_Optins_PackedData));
                }

                Miscellaneous = Convert.ToString(total);
            }

            catch (Exception ex)
            {
                Logger.Error(ex, "GetMiscellaneous" + ex.TargetSite.Name);
                return "";
            }
            return Miscellaneous;
        }
        /// <summary>
        /// 121
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetTotalDue(AccountsModel model)
        {
            try
            {
                if (Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalDue = "0.00";
                else
                {
                    TotalDue = Convert.ToString(Convert.ToDecimal(model.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(model.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }
                return TotalDue;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalDue" + ex.TargetSite.Name);
                return "";
            }
        }


        #endregion

        #region Condition Statement ==>
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetHold(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Hold");

                if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    Hold = "create image but do not mail";
                }
                else
                {
                    Hold = accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt;
                }
                //Logger.Trace("ENDED:  To Get Hold");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Hold;
        }
        /// <summary>
        /// 2
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <param name="isCoBorrower"></param>
        /// <returns></returns>
        public string GetAttention(AccountsModel accountsModel, bool isCoBorrower)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get attention.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        Attention = accountsModel.MasterFileDataPart_1Model.Rssi_Prim_Attention;
                    else
                        Attention = null;
                }
                //Logger.Trace("ENDED: Get get attention.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAttention" + ExMessage);

            }
            return Attention;
        }
        /// <summary>
        /// 3
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <param name="isCoBorrower"></param>
        /// <returns></returns>
        public string GetPrimaryBorrower(AccountsModel accountsModel, bool isCoBorrower)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get primary borrower.");

                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_F;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_F;
                }
                //Logger.Trace("ENDED: Get get primary borrower.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrimaryBorrower" + ExMessage);

            }

            return PrimaryBorrower;
        }

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <param name="isCoBorrower"></param>
        /// <returns></returns>
        public string GetSecondaryBorrower(AccountsModel accountsModel, bool isCoBorrower)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get secondary borrower.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        SecondaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
                    else
                        SecondaryBorrower = null;
                }
                return SecondaryBorrower;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrimaryBorrower" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 5
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetMailingAddressLine1(AccountsModel accountsModel, bool isCoBorrower)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get mailing address line1.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Adrs1;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Adrs1;
                }

                //Logger.Trace("ENDED: Get get mailing address line1.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingAddressLine1" + ExMessage);

            }

            return MailingAddressLine1;
        }
        /// <summary>
        /// 6
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetMailingAddressLine2(AccountsModel accountsModel, bool isCoBorrower)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get mailing address line2.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Adrs2;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Adrs2;
                }
                //Logger.Trace("ENDED: Get get mailing address line2.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingAddressLine2" + ExMessage);

            }
            return MailingAddressLine2;
        }
        /// <summary>
        /// 7
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get mailing city state zip.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Zip;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Zip;
                }
                //Logger.Trace("ENDED: Get get mailing city state zip.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingCityStateZip" + ExMessage);

            }
            return MailingCityStateZip;
        }
        /// <summary>
        /// 8
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetMailingCountry(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get mailing country.");
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
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Appl_Country;
                }
                else
                {
                    MailingCountry = null;
                }
                return MailingCountry;
                //Logger.Trace("ENDED: Get get mailing mailing country.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingCountry" + ExMessage);
                return "";
            }

        }
        /// <summary>
        /// 16
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetPaymentIsReceivedAfter(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get payment received after.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    IfPaymentisReceivedAfter = "suppress Late Charge message_ Flag";
                }
                else
                {
                    IfPaymentisReceivedAfter = accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Dte;
                }
                //Logger.Trace("ENDED: Get get payment received after.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPaymentReceivedAfter" + ExMessage);

            }
            return IfPaymentisReceivedAfter;
        }
        /// <summary>
        /// 17
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetLateFee(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get late fee.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    LateFee = "suppress Late Charge message_ Flag";
                }
                else
                {
                    LateFee = accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get late fee.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetLateFee" + ExMessage);
            }
            return LateFee;
        }
        /// <summary>
        /// 18
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetChargeOffNoticeNoticeMessage(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                    ChargeOffNoticeNoticeMessage = "ChargeOff_MessageFlag";
                else if ((Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30)
                        && (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0))
                    ChargeOffNoticeNoticeMessage = "Delinquency_MessageFlag";
                else if ((Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30)
                        && (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0))
                    ChargeOffNoticeNoticeMessage = "Re-Finance_ChargeOff_MessageFlag";
                return ChargeOffNoticeNoticeMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetChargeOffNoticeNoticeMessage" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 23
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetNegativeAmortization(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
                    NegativeAmortization = "N/A";
                else
                    NegativeAmortization = accountModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData;
                return NegativeAmortization;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetNegativeAmortization" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 24
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetBuydownBalance(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                    BuydownBalance = "N/A";
                else
                    BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;

                return BuydownBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBuydownBalance" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 25
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetPartialClaim(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                    PartialClaim = "N/A";
                else
                    PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;

                return PartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPartialClaim" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 42
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetInterestOption1(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption1 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    InterestOption1 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption1 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                { InterestOption1 = null; }
                else
                {
                    InterestOption1 = accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                return InterestOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 43
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetEscrowOption1(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption1 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    EscrowOption1 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption1 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                { EscrowOption1 = null; }
                else
                {
                    EscrowOption1 = accountModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;
                }
                return EscrowOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 46
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRegularMonthlyPaymentOption1(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption1 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption1 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                { RegularMonthlyPaymentOption1 = null; }
                else
                {
                    RegularMonthlyPaymentOption1 = accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData;
                }
                return RegularMonthlyPaymentOption1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption1" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 52
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetInterestOption2(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption2 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    InterestOption2 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption2 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption2 = null;
                }
                else
                {
                    InterestOption2 = accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                return InterestOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 53
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetEscrowOption2(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption2 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    EscrowOption2 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption2 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                { EscrowOption2 = null; }
                else
                {
                    EscrowOption2 = accountModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;
                }
                return EscrowOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 56
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRegularMonthlyPaymentOption2(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption2 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption2 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                { RegularMonthlyPaymentOption2 = null; }
                else
                {
                    RegularMonthlyPaymentOption2 = accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData;
                }
                return RegularMonthlyPaymentOption2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption2" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 62
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetInterestOption3(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption3 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    InterestOption3 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption3 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption3 = null;
                }
                else
                {
                    InterestOption3 = accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                return InterestOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 63
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetEscrowOption3(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption3 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    EscrowOption3 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption3 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                { EscrowOption3 = null; }
                else
                {
                    EscrowOption3 = accountModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;
                }
                return EscrowOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 66
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRegularMonthlyPaymentOption3(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption3 = "0.00";
                else if (Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = null;
                }
                else if (
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) <
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption3 = null;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                { RegularMonthlyPaymentOption3 = null; }
                else
                {
                    RegularMonthlyPaymentOption3 = accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData;
                }
                return RegularMonthlyPaymentOption3;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption3" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 72
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetInterestOption4(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    InterestOption4 = "0.00";

                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) >
                     Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                {
                    InterestOption4 = accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption4 = "0.00";
                }
                else
                    InterestOption4 = accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                return InterestOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 73
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetEscrowOption4(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowOption4 = "0.00";
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption4 = "0.00";
                }
                else
                {
                    EscrowOption4 = accountModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;
                }
                return EscrowOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 76
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRegularMonthlyPaymentOption4(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPaymentOption4 = "0.00";
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption4 = "0.00"; ;
                }
                else
                {
                    RegularMonthlyPaymentOption4 = accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData;
                }
                return RegularMonthlyPaymentOption4;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPaymentOption4" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 81
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetOption4MinimumDescription(AccountsModel accountModel)
        {
            try
            {
                if ((Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                        - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) > 0)
                    Option4MinimumDescription = "Your principal balance will decrease and you will be closer to paying off your loan.";
                else if ((Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                    - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) == 0)
                    Option4MinimumDescription = "Your principal balance will stay the same and you will not be closer to paying off your loan.";
                else if ((Convert.ToDecimal(accountModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                    - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData)) < 0)
                    Option4MinimumDescription = "Your principal balance will increase.You will be borrowing more money and losing equity in your home.";

                return Option4MinimumDescription;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetOption4MinimumDescription" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 88
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPOBoxAddress(AccountsModel accountsModel)
        {
            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                       || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA"
                       || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM"
                       || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                       || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {
                    POBoxAddress = "PO Box 660586 " + accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + ", TX 75266-0586";
                }
                else
                {
                    POBoxAddress = "PO Box 7006 " + accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + ", CA 91109-9998";
                }
                return POBoxAddress;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPOBoxAddress" + ex.TargetSite.Name);
                return "";
            }

        }
        /// <summary>
        /// 94
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetReceivedAfterDate(AccountsModel accountsModel)
        {

            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    IfReceivedAfterDate = "SuppressLateCharge_MessageFlag";
                }
                else
                {
                    IfReceivedAfterDate = accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Dte;
                }

                return IfReceivedAfterDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetReceivedAfterDate" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 95
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetLateChargeAmount(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    LateChargeAmount = "suppress Late Charge message_ Flag";
                }
                else
                {
                    LateChargeAmount = accountsModel.MasterFileDataPart_1Model.Rssi_Late_Amt_PackedData;
                }

                return LateChargeAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLateChargeAmount" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 97
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetDate(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Date");

                var result = accountModel.TransactionRecordModelList.Where(m => Convert.ToDecimal(m.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0).FirstOrDefault();
                var fee = accountModel.FeeRecordModel.Where(m => m.Rssi_Fd_Fee_Type == "000").FirstOrDefault();

                if (fee != null)
                    Date = fee.Rssi_Fd_Assess_Date;

                else
                {
                    Date = accountModel.TransactionRecordModelList.FirstOrDefault()?.Rssi_Tr_Date_PackedData;
                }
                //Logger.Trace("ENDED:  To Get Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Date != null ? Convert.ToString(CommonHelper.GetDateTime(Date)) : string.Empty;

        }
        /// <summary>
        /// 99
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetAmount(AccountsModel accountModel)
        {


            try
            {
                decimal amt = 0;
                //Logger.Trace("STARTED:  Execute to Get Amount");
                var result = accountModel.TransactionRecordModelList.Where(m => Convert.ToDecimal(m.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0).FirstOrDefault();
                var fee = accountModel.FeeRecordModel.Where(m => m.Rssi_Fd_Fee_Type == "000").FirstOrDefault();

                if (result != null)
                    amt = Convert.ToDecimal(result.Rssi_Tr_Exp_Fee_Amt_PackedData);

                else if (fee != null)
                {
                    amt = Convert.ToDecimal(fee.Rssi_Fd_Assess_Amt);
                }
                else
                {
                    foreach (var i in accountModel.TransactionRecordModelList)
                    {
                        amt += Convert.ToDecimal(i.Rssi_Tr_Amt_PackedData);
                    }

                }

                Amount = Convert.ToString(amt);
                //Logger.Trace("ENDED:  To Get Amount");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Amount;
        }
        /// <summary>
        /// 109
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetInterestRateUntil(AccountsModel accountsModel)
        {
            //if (Convert.ToUInt64(Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
            try
            {
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    InterestRateUntil = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date);
                }
                else
                {
                    InterestRateUntil = null;
                }

                return InterestRateUntil;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestRateUntil" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 111
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {
            try
            {
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                    PrepaymentPenalty = "Yes";
                else
                    PrepaymentPenalty = "No";

                return PrepaymentPenalty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrepaymentPenalty" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 112
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetModificationDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get modification date.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    ModificationDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Modify_Date);
                }
                else
                {
                    ModificationDate = "N/A";
                }
                //Logger.Trace("Get get modification date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetmodificationDate" + ExMessage);

            }
            return ModificationDate;
        }
        /// <summary>
        /// 113
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetMaturityDate(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    MaturityDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date);
                }
                else
                {
                    MaturityDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Mat_Date);
                }
                return MaturityDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMaturityDate" + ex.TargetSite.Name);

                return "";
            }
        }
        /// <summary>
        /// 114
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetDelinquencyNoticebox(AccountsModel accountsModel)
        {
            try
            {
                decimal val = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq);

                if (val >= 30 && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    DelinquencyNoticebox = "DelinquencyNotice_MessageFlag";
                }
                else
                {
                    DelinquencyNoticebox = "";
                }
                return DelinquencyNoticebox;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetDelinquencyNoticebox" + ex.TargetSite.Name);

                return "";
            }
        }
        /// <summary>
        /// 115
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRecentPayment6(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get recent payment6.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_5; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0
                    && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; ;
                }
                //Logger.Trace("ENDED: Get  recent payment6.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment6" + ex.TargetSite.Name);

                return "";
            }

            return RecentPayment6;
        }
        /// <summary>
        /// 116
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRecentPayment5(AccountsModel accountModel)
        {

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                   && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                   && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment5" + ex.TargetSite.Name);

                return "";
            }

            return RecentPayment5;
        }
        /// <summary>
        /// 117
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRecentPayment4(AccountsModel accountModel)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment4");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                  && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                  && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)

                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment5");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment4" + ex.TargetSite.Name);

                return "";
            }
            return RecentPayment4;
        }
        /// <summary>
        /// 118
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRecentPayment3(AccountsModel accountModel)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment3");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                 && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)

                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment3" + ex.TargetSite.Name);

                return "";
            }

            return RecentPayment3;
        }
        /// <summary>
        /// 119
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRecentPayment2(AccountsModel accountModel)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment2");
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)

                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment2" + ex.TargetSite.Name);

                return "";
            }

            return RecentPayment2;
        }
        /// <summary>
        /// 120
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetRecentPayment1(AccountsModel accountModel)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment1");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRecentPayment1" + ex.TargetSite.Name);
                return "";
            }

            return RecentPayment1;
        }

        /// <summary>
        /// 125
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetLossMitigtationNotice(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get loss mitigtation notice.");
                if (!String.IsNullOrEmpty(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) && accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program != "   ")
                {
                    if ((int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) >= 2
                        && int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) <= 10)
                        || (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) >= 12
                        && int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) <= 14))
                    {
                        LossMitigtationNotice = "PLEASE TAKE NOTICE that You have agreed to the following loss mitigation program: " + accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLossMitigtationNotice" + ex.TargetSite.Name);

                return "";
            }
            return LossMitigtationNotice;
        }
        /// <summary>
        /// 126
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetForeclosureNotice(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get foreclosure notice.");
                if (accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date != null && accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date != "")
                {
                    if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date).IncludeCenturyDate(true)) > 0)
                    {
                        ForeclosureNotice = "PLEASE TAKE NOTICE that Carrington Mortgage Services, LLC has made the first notice or filing required to start a foreclosure.";
                    }
                }
            }
            //Logger.Trace("ENDED: Get get foreclosure notice.");
            catch (Exception ex)
            {
                Logger.Error(ex, "GetForeclosureNotice" + ex.TargetSite.Name);
                return "";
            }
            return ForeclosureNotice;
        }
        /// <summary>
        /// 127a
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetACHMessage(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get ACH message.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData).IncludeCenturyDate(true)) == 0 &&
                      Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) == 0)
                {
                    ACHMessage = "AutoPayService_MessageFlag";
                }
                //Logger.Trace("ENDED: Get ACH message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetACHMessage" + ExMessage);

            }

            return ACHMessage;
        }
        /// <summary>
        /// 127b
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get lender placed insurance message.");
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
                return LenderPlacedInsuranceMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLenderPlacedInsuranceMessage" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 127d
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetBankruptcyMessage(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get bankruptcy message.");

                var result = (from s in accountsModel.ArchivedBankruptcyDetailRecordModel
                              where CommonHelper.GetFormatedDateTime(s.Rssi_K_B_Dschg_Dt_PackedData) > Convert.ToDateTime("01/01/01")
                                               && CommonHelper.GetFormatedDateTime(s.Rssi_K_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("01/01/01")
                              select (s)).FirstOrDefault();

                if (result != null)
                    BankruptcyMessage = "Bankruptcy_MessageFlag";


                //Logger.Trace("ENDED: Get get bankruptcy message.");
                return BankruptcyMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBankruptcyMessage" + ex.TargetSite.Name);

                return "";
            }
        }
        /// <summary>
        /// 127e
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetRepaymentPlanMessage(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get repayment plan message.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Repy_Remain_Bal_PackedData != "00000C")
                {
                    RepaymentPlanMessage = "RepaymentPlan_MessageFlag";
                }
                //Logger.Trace("ENDED: Get get  repayment plan message.");

                return RepaymentPlanMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRepaymentPlanMessage" + ex.TargetSite.Name);

                return "";
            }
        }
        /// <summary>
        /// 127f
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetStateNSFMessage(AccountsModel accountsModel)
        {
            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6")
                {
                    StateNSFMessage = "StateNSF6_MessageFlag";
                }
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16")
                {
                    StateNSFMessage = "StateNSF16_MessageFlag";
                }
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18")
                {
                    StateNSFMessage = "StateNSF18_MessageFlag";
                }
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "43")
                {
                    StateNSFMessage = "StateNSF43_MessageFlag";
                }

                return StateNSFMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateNSFMessage" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 127h
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetChargeOffNotice(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get charge off notice.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData).IncludeCenturyDate(true)) > 0)
                {
                    chargeOffNotice = "ChargeOff_MessageFlag";
                }
                //Logger.Trace("ENDED: Get charge off notice.");
                return chargeOffNotice;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetChargeOffNotice" + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 127i
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get CMS partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                    && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                {
                    chargeOffNotice = "CMSPartialClaim_MessageFlag";
                }
                //Logger.Trace("ENDED: Get CMS partial claim.");
                return chargeOffNotice;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCMSPartialClaim" + ex.TargetSite.Name);
                return "";
            }
        }
        /// <summary>
        /// 127j
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get hud partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                    && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                {
                    HUDPartialClaim = "HUDPartialClaim_MessageFlag";
                }
                //Logger.Trace("ENDED: Get hud partial claim.");
            }

            catch (Exception ex)
            {
                Logger.Error(ex, "GetHUDPartialClaim" + ex.TargetSite.Name);
                return "";
            }
            return HUDPartialClaim;
        }
        /// <summary>
        /// 128
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetStateDisclosures(AccountsModel accountModel)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get State Disclosures operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 4
                      && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "AR")
                {
                    StateDisclosures = "StateDisclosures4AR_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                    && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "CO")
                {
                    StateDisclosures = "StateDisclosures6CO_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 12
                    && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "HI")
                {
                    StateDisclosures = "StateDisclosures12HI_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 22
                    && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "MA")
                {
                    StateDisclosures = "StateDisclosures4AR_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 24
                    && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "MN")
                {
                    StateDisclosures = "StateDisclosures24MN_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NC")
                {
                    StateDisclosures = "StateDisclosures33NC_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 34
                    && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NY")
                {
                    StateDisclosures = "StateDisclosures34NY_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 43
                   && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TN")
                {
                    StateDisclosures = "StateDisclosures43TN_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 44
                   && accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {
                    StateDisclosures = "StateDisclosures44TX_MessageFlag";
                }
                //Logger.Trace("ENDED:    To State Disclosures operation.");
                return StateDisclosures;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateDisclosures" + ex.TargetSite.Name);

                return "";
            }
        }
        /// <summary>
        /// 129
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get payment information message.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {
                    paymentInformationMessage = "PO Box 660586 Dallas, " + accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + " 75266-0586";
                }
                else
                {
                    paymentInformationMessage = "PO Box 7006 Pasadena, " + accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + " 91109-9998";
                }
                //Logger.Trace("ENDED: Get payment information message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentInformationMessage" + ex.TargetSite.Name);

                return "";
            }
            return paymentInformationMessage;
        }

        #endregion
    }
}
