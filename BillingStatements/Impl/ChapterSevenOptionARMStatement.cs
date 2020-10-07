using HelocService.Helpers;
using HelocService.Models.InputCopyBookModels;
using System;
using System.Text;
using HelocService.Helpers;
using System.Linq;

namespace HelocService.BillingStatements
{
    public class ChapterSevenOptionARMStatement : IChapterSevenOptionARMStatement
    {
        public string AmountDueOption1 { get; set; }
        public string AmountDueOption2 { get; set; }
        public string AmountDueOption3 { get; set; }
        public string AmountDueOption4 { get; set; }
        public string PrincipalOption1 { get; set; }
        public string AssistanceAmount { get; set; }
        public string ReplacementReserve { get; set; }
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
        public string FeesandChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string FeesandChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYeartoDate { get; set; }
        public string PaymentAmountOption1 { get; set; }
        public string PaymentAmountOption2 { get; set; }
        public string PaymentAmountOption3 { get; set; }
        public string PaymentAmountOption4 { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string DeferredBalance { get; set; }
        public string TotalDue { get; set; }
        public string Hold { get; set; }
        public string PrimaryBorrowerBKAttorney { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingBKAttorneyAddressLine1 { get; set; }
        public string MailingBKAttorneyAddressLine2 { get; set; }
        public string BorrowerAttorneyMailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string PaymentDate { get; set; }
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

        public string Date { get; set; }
        public string Amount { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string AccountHistoryInformationbox { get; set; }
        public string RecentPayment6 { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string StateNSF { get; set; }
        public string AutodraftMessage { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string StateDisclosures { get; set; }
        public string PaymentInformationMessage { get; set; }

        public string ExMessage { get; set; }
        public string MailingBkAttorneyAddressLine1 { get; private set; }
        public string MailingBkAttorneyAddressLine2 { get; private set; }
        public string PrimaryBorrowerBkAttorney { get; private set; }

        public StringBuilder finalLine;

        public ILogger Logger;

        public ChapterSevenOptionARMStatement(ILogger logger)
        {
            Logger = logger;
        }

        public StringBuilder GetFinalChapterSevenOptionARMStatement(AccountsModel accountModel, bool isCoborrower = false)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();
            finalLine.Append(GetAmountDueOption1(accountModel) + "|");
            finalLine.Append(GetAmountDueOption2(accountModel) + "|");
            finalLine.Append(GetAmountDueOption3(accountModel) + "|");
            finalLine.Append(GetAmountDueOption4(accountModel) + "|");
            finalLine.Append(GetPrincipalOption1(accountModel) + "|");
            finalLine.Append(GetAssistanceAmount(accountModel) + "|");
            finalLine.Append(GetReplacementReserve(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption1(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption1(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption1(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption1(accountModel) + "|");
            finalLine.Append(GetPrincipalOption2(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption2(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption2(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption2(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption2(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption2(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption2(accountModel) + "|");
            finalLine.Append(GetPrincipalOption3(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption3(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption3(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption3(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption3(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption3(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption3(accountModel) + "|");
            finalLine.Append(GetPrincipalOption4(accountModel) + "|");
            finalLine.Append(GetAssistanceAmountOption4(accountModel) + "|");
            finalLine.Append(GetReplacementReserveOption4(accountModel) + "|");
            finalLine.Append(GetOverduePaymentsOption4(accountModel) + "|");
            finalLine.Append(GetTotalFeesChargedOption4(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaidOption4(accountModel) + "|");
            finalLine.Append(GetTotalAmountDueOption4(accountModel) + "|");
            finalLine.Append(GetFeesandChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GeUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesandChargesPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption1(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption2(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption3(accountModel) + "|");
            finalLine.Append(GetPaymentAmountOption4(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetTotalDue(accountModel) + "|");

            //Conditional methods
            finalLine.Append(GetHold(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel, isCoborrower) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel, isCoborrower) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel, isCoborrower) + "|");
            finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel, isCoborrower) + "|");
            finalLine.Append(GetMailingCountry(accountModel, isCoborrower) + "|");
            finalLine.Append(GetPaymentDate(accountModel) + "|");
            finalLine.Append(GetInterestOption1(accountModel) + "|");
            finalLine.Append(GetEscrowOption1(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption1(accountModel) + "|");
            finalLine.Append(GetInterestOption2(accountModel) + "|");
            finalLine.Append(GetEscrowOption2(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption2(accountModel) + "|");
            finalLine.Append(GetInterestOption3(accountModel) + "|");
            finalLine.Append(GetEscrowOption3(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption3(accountModel) + "|");
            finalLine.Append(GetInterestOption4(accountModel) + "|");
            finalLine.Append(GetEscrowOption4(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPaymentOption4(accountModel) + "|");
            finalLine.Append(GetOption4MinimumDescription(accountModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountModel) + "|");
            finalLine.Append(GetDate(accountModel) + "|");
            finalLine.Append(GetAmount(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetAccountHistoryInformationbox(accountModel) + "|");
            finalLine.Append(GetRecentPayment6(accountModel) + "|");
            finalLine.Append(GetRecentPayment5(accountModel) + "|");
            finalLine.Append(GetRecentPayment4(accountModel) + "|");
            finalLine.Append(GetRecentPayment3(accountModel) + "|");
            finalLine.Append(GetRecentPayment2(accountModel) + "|");
            finalLine.Append(GetRecentPayment1(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");
            return finalLine;
        }

        /* While Calculating Conditions must be applied*/
        public string GetAmountDueOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option1");

                if (accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    AmountDueOption1 = "0.00";
                }
                else if (accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData == "0")
                {
                    AmountDueOption1 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption1 = "N/A";
                }
                else if (accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData == "0")
                {
                    AmountDueOption1 = "N/A";
                }
                else
                {
                    AmountDueOption1 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Amount Due Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption1;
        }

        public string GetAmountDueOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption2 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption2 = "N/A";
                }
                else
                {
                    AmountDueOption2 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));

                }
                //Logger.Trace("ENDED:  To Get Amount Due Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption2;
        }

        public string GetAmountDueOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    AmountDueOption3 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption3 = "N/A";
                }
                else
                {
                    AmountDueOption3 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Amount Due Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption3;
        }
        public string GetAmountDueOption4(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount Due Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDueOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    AmountDueOption4 = "N/A";
                }
                else
                {
                    AmountDueOption4 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Amount Due Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AmountDueOption4;
        }


        public string GetPrincipalOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption1 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    PrincipalOption1 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption1 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption1 = "null";
                else
                {
                    PrincipalOption1 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                     - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Principal Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption1;
        }
        public string GetAssistanceAmount(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Assistance Amount");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmount = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmount = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmount = "0.00";

                else
                {
                    AssistanceAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                //Logger.Trace("ENDED:  To Get Assistance Amount");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmount;
        }
        public string GetReplacementReserve(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Replacement Reserve");

                if ((Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
               - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
               - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
               + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserve = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserve = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserve = "0.00";


                else
                {
                    ReplacementReserve = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                                - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                //Logger.Trace("ENDED:  To Get Replacement Reserve");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserve;
        }
        public string GetOverduePaymentsOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption1 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption1 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption1 = "null";


                else
                {

                    OverduePaymentsOption1 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                        - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                    - Convert.ToDecimal(GetTotalFeesPaidOption1(accountsModel)));
                }
                //Logger.Trace("ENDED:  To Get Overdue Payments Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption1;
        }
        public string GetTotalFeesChargedOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    TotalFeesChargedOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
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
                        Total -= Convert.ToDecimal(result);
                    }

                    TotalFeesChargedOption1 = Convert.ToString(Total);

                }
                //Logger.Trace("ENDED:  To Get Total Fees Charged Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption1;
        }
        public string GetTotalFeesPaidOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption1 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption1 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption1 = "null";



                else if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                          + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(GetTotalFeesChargedOption1(accountsModel)))
                {
                    TotalFeesPaidOption1 = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesChargedOption1(accountsModel))));
                }
                else
                    TotalFeesPaidOption1 = "0.00";
                //Logger.Trace("ENDED:  To Get Total Fees Paid Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption1;
        }
        public string GetTotalAmountDueOption1(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Amount Due Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption1 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                    TotalAmountDueOption1 = "Option Not Available";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption1 = "Option Not Available";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption1 = "Option Not Available";


                else
                    TotalAmountDueOption1 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                   + Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData)
                                   + Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

                if (TotalAmountDueOption1 == null)
                    TotalAmountDueOption1 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                      + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                //Logger.Trace("ENDED:  To Get Total Amount Due Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption1;
        }


        public string GetPrincipalOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption2 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption2 = "null";
                else
                {
                    PrincipalOption2 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                     - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("STARTED:  To Get Principal Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption2;
        }
        public string GetAssistanceAmountOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Assistance Amount Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption2 = "0.00";
                else
                {
                    AssistanceAmountOption2 = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1));
                }
                //Logger.Trace("ENDED:  To Get Assistance Amount Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmountOption2;
        }
        public string GetReplacementReserveOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option2");

                if ((Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
              - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
              - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
              + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption2 = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption2 = "0.00";

                else
                {
                    ReplacementReserveOption2 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                                                - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt3_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                //Logger.Trace("ENDED:  To Get Replacement Reserve Option2");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserveOption2;
        }
        public string GetOverduePaymentsOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption2 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    OverduePaymentsOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption2 = "null";

                else
                {
                    OverduePaymentsOption2 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                        - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption2(accountsModel)));


                }
                //Logger.Trace("ENDED:  To Get Overdue Payments Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption2;
        }
        public string GetTotalFeesChargedOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "null";
                }

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    TotalFeesChargedOption2 = "null";
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

                    TotalFeesChargedOption2 = Convert.ToString(Total);

                }
                //Logger.Trace("ENDED:  To Get Total Fees Charged Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption2;
        }
        public string GetTotalFeesPaidOption2(AccountsModel accountsModel)
        {

            try
            {
                // need to check
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option2");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption2 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption2 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption2 = "null";

                else if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                          + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(GetTotalFeesChargedOption2(accountsModel)))
                {
                    TotalFeesPaidOption2 = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesChargedOption2(accountsModel))));
                }
                else
                    TotalFeesPaidOption2 = "0.00";
                //Logger.Trace("ENDED:  To Get Total Fees Paid Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption2;
        }
        public string GetTotalAmountDueOption2(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Amount Due Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption2 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                    TotalAmountDueOption2 = "Option Not Available";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption2 = "Option Not Available";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption2 = "Option Not Available";

                else
                    TotalAmountDueOption2 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));

                //Logger.Trace("ENDED:  To Get Total Amount Due Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption2;
        }

        public string GetPrincipalOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    PrincipalOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    PrincipalOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption3 = "null";
                else
                {
                    PrincipalOption3 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                     - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Principal Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption3;
        }
        public string GetAssistanceAmountOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Assistance Amount Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption3 = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption3 = "0.00";
                else
                {
                    AssistanceAmountOption3 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                //Logger.Trace("ENDED:  To Get Assistance Amount Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmountOption3;
        }
        public string GetReplacementReserveOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option3");

                if ((Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
             - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
             - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
             + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption3 = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption3 = "0.00";
                else
                {
                    ReplacementReserveOption3 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                                                - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt2_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                //Logger.Trace("ENDED:  To Get Replacement Reserve Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserveOption3;
        }
        public string GetOverduePaymentsOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option3");

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
                                     - Convert.ToDecimal(GetTotalFeesPaidOption3(accountsModel)));
                }
                //Logger.Trace("ENDED:  To Get Overdue Payments Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption3;
        }
        public string GetTotalFeesChargedOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    TotalFeesChargedOption3 = "null";
                }

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    TotalFeesChargedOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
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

                    TotalFeesChargedOption3 = Convert.ToString(Total);

                }

                //Logger.Trace("ENDED:  To Get Total Fees Charged Option3");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption3;
        }
        public string GetTotalFeesPaidOption3(AccountsModel accountsModel)
        {

            try
            {
                // need to check
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalFeesPaidOption3 = "null";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption3 = "null";


                else if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                          + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(GetTotalFeesChargedOption3(accountsModel)))
                {
                    TotalFeesPaidOption3 = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesChargedOption3(accountsModel))));
                }
                else
                    TotalFeesPaidOption3 = "0.00";

                //Logger.Trace("ENDED:  To Get Total Fees Paid Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption3;
        }
        public string GetTotalAmountDueOption3(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Amount Due Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption3 = "0.00";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                    TotalAmountDueOption3 = "Option Not Available";

                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                    TotalAmountDueOption3 = "Option Not Available";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption3 = "Option Not Available";


                else
                    TotalAmountDueOption3 = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                       + Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)

                                   );
                //Logger.Trace("ENDED:  To Get Total Amount Due Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption3;
        }


        public string GetPrincipalOption4(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Principal Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    PrincipalOption4 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData))
                    PrincipalOption4 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    PrincipalOption4 = "0.00";


                else
                {
                    PrincipalOption4 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                     - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Principal Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrincipalOption4;
        }
        public string GetAssistanceAmountOption4(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Assistance Amount Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmountOption4 = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmountOption4 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmountOption4 = "0.00";

                else
                {
                    AssistanceAmountOption4 = (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * (-1)).ToString();
                }

                //Logger.Trace("ENDED:  To Get Assistance Amount Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AssistanceAmountOption4;
        }
        public string GetReplacementReserveOption4(AccountsModel accountsModel)
        {
            //Logger.Trace("STARTED:  Execute to Get Replacement Reserve Option4");
            try
            {
                if ((Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
            - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
            - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
            + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                    ReplacementReserveOption4 = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveOption4 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveOption4 = "0.00";


                else
                {
                    ReplacementReserveOption4 = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData)
                                                - Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));

                }
                //Logger.Trace("ENDED:  To Get Replacement Reserve Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return ReplacementReserveOption4;
        }
        public string GetOverduePaymentsOption4(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Overdue Payments Option4");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    OverduePaymentsOption4 = "0.00";
                else
                {
                    OverduePaymentsOption4 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                       - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                     - Convert.ToDecimal(GetTotalFeesPaidOption4(accountsModel)));
                }
                //Logger.Trace("ENDED:  To Get Overdue Payments Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return OverduePaymentsOption4;
        }


        public string GetTotalFeesChargedOption4(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Charged Option4");
                if ((accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData)) == 0)
                {
                    TotalFeesChargedOption4 = "0.00";
                }
                else if ((accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData)) == 0)
                {
                    TotalFeesChargedOption4 = "0.00";
                }
                else
                {
                    var Total = (accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData))
                    + (accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));


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
                //Logger.Trace("ENDED:  To Get Total Fees Charged Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesChargedOption4;
        }
        public string GetTotalFeesPaidOption4(AccountsModel accountsModel)
        {
            // need to check

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalFeesPaidOption4 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalFeesPaidOption4 = "0.00";

                else if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                          + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                           Convert.ToDecimal(GetTotalFeesChargedOption4(accountsModel)))
                {
                    TotalFeesPaidOption4 = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesChargedOption4(accountsModel))));
                }
                else
                    TotalFeesPaidOption4 = "0.00";
                //Logger.Trace("ENDED:  To Get Total Fees Paid Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalFeesPaidOption4;
        }
        public string GetTotalAmountDueOption4(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Amount Due Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDueOption4 = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    TotalAmountDueOption4 = "0.00";


                else
                    TotalAmountDueOption4 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                       + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                //Logger.Trace("ENDED:  Execute to Get Total Amount Due Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalAmountDueOption4;
        }


        public string GetFeesandChargesPaidLastMonth(AccountsModel accountsModel)//Issue
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Fees and Charges Paid Last Month");

                var result = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
              + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData);

                var resu = (from s in accountsModel.TransactionRecordModelList
                            where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                            && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                            select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();


                FeesandChargesPaidLastMonth = Convert.ToString(result - Convert.ToDecimal(resu));

                //Logger.Trace("ENDED:  To Get Fees and Charges Paid Last Month");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return FeesandChargesPaidLastMonth;
        }

        public string GeUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Last Month");

                decimal result = 0;
                foreach (var item in accountsModel.TransactionRecordModelList)
                {
                    result += Convert.ToDecimal(item.Rssi_Tr_Amt_To_Evar_PackedData) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_2) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_3) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_4) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_5);

                }

                UnappliedFundsPaidLastMonth = Convert.ToString(result);


                //Logger.Trace("ENDED:  To Get Unapplied Funds Paid Last Month");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return UnappliedFundsPaidLastMonth;
        }
        public string GetFeesandChargesPaidYeartoDate(AccountsModel accountsModel)//Issue
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get fees and charges paid year to date");
                var total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +
                    Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData);

                var rec = (from s in accountsModel.TransactionRecordModelList
                           where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                           && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                           select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();


                FeesandChargesPaidYeartoDate = Convert.ToString(total - Convert.ToDecimal(rec));
                //Logger.Trace("ENDED: Get fees and charges paid year to date");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetFeesAndChargesPaidYeartoDate" + ExMessage);
            }
            return FeesandChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)//Issue
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Year To Date");

                UnappliedFundsPaidYearToDate = Convert.ToString(
                    accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L"
                    ? (accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData)) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L"
                    ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData)) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L"
                    ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData)) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L"
                    ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData)) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L"
                    ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData)) : 0);

                //Logger.Trace("ENDED:  To Get Unapplied Funds Paid Year To Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return UnappliedFundsPaidYearToDate;

        }


        public string GetTotalPaidYeartoDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Year To Date");
                var total = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                 + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                 + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                 + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                 + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData);


                total += accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L"
                  ? (accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData)) : 0
                  + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L"
                  ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData)) : 0
                  + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L"
                  ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData)) : 0
                  + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L"
                  ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData)) : 0
                  + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L"
                  ? (accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData.Trim() == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData)) : 0;


                var res = (from s in accountsModel.TransactionRecordModelList
                           where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                           && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                           select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();


                TotalPaidYeartoDate = Convert.ToString(total - Convert.ToDecimal(res));

                //Logger.Trace("ENDED:  To Get Unapplied Funds Paid Year To Date");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalPaidYeartoDate;


        }
        public string GetPaymentAmountOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Payment Amount Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    PaymentAmountOption1 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PaymentAmountOption1 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption1 = "N/A";
                }
                else
                {
                    PaymentAmountOption1 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Payment Amount Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption1;
        }
        public string GetPaymentAmountOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Payment Amount Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    PaymentAmountOption2 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PaymentAmountOption2 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption2 = "N/A";
                }
                else
                {
                    PaymentAmountOption2 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Payment Amount Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption2;
        }
        public string GetPaymentAmountOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Payment Amount Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    PaymentAmountOption3 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    PaymentAmountOption3 = "N/A";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption3 = "N/A";
                }
                else
                {
                    PaymentAmountOption3 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Payment Amount Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption3;
        }
        public string GetPaymentAmountOption4(AccountsModel accountsModel)
        {

            try
            {

                //Logger.Trace("STARTED:  Execute to Get Payment Amount Option4");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    PaymentAmountOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    PaymentAmountOption4 = "N/A";
                }
                else
                {
                    PaymentAmountOption4 = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Payment Amount Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentAmountOption4;
        }

        public string GetSuspense(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Suspense");            
                decimal result = 0;
                foreach (var item in accountsModel.TransactionRecordModelList)
                {
                    result += Convert.ToDecimal(item.Rssi_Tr_Amt_To_Evar_PackedData) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_2) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_3) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_4) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_5);

                }

                Suspense = Convert.ToString(result);
                //Logger.Trace("ENDED:  To Get Suspense");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Suspense;
        }

        public string GetMiscellaneous(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Miscellaneous");

                decimal total = 0;
                foreach (var tra in accountsModel.TransactionRecordModelList)
                {
                    total += (tra.Rssi_Tr_Amt_To_Lip_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Lip_PackedData))
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

                //Logger.Trace("ENDED:  To Get Miscellaneous");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Miscellaneous;
        }

        public string GetDeferredBalance(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Deferred Balance");

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
                //Logger.Trace("ENDED:  To Get Deferred Balance");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return DeferredBalance;
        }
        public string GetTotalDue(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Due");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalDue = "0.00";
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Total Due");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalDue;
        }


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

        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel, bool isCoborrower = false)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get primary borrower bKAttorney");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" ||
                    accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == null)
                {
                    PrimaryBorrowerBkAttorney = string.Empty;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    PrimaryBorrowerBkAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    PrimaryBorrowerBkAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    PrimaryBorrowerBkAttorney = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;

                }

                //Logger.Trace("ENDED: Get primary borrower bKAttorney");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPrimaryBorrowerBKAttorney" + ExMessage);
            }

            return PrimaryBorrowerBkAttorney;
        }

        public string GetSecondaryBorrower(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get secondary borrower");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y" ||
                    accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    SecondaryBorrower = accountModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
                }
                //Logger.Trace("ENDED: Get secondary borrower");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetSecondaryBorrower" + ExMessage);
            }

            return SecondaryBorrower;
        }

        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel, bool isCoborrower = false)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get mailing bKAttorney addressLine1.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBkAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBkAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBkAttorneyAddressLine1 = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;

                }
                //Logger.Trace("ENDED: Get mailing bKAttorney addressLine1.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine1" + ExMessage);
            }
            return MailingBkAttorneyAddressLine1;
        }

        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel, bool isCoborrower = false)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get mailing bKAttorney addressLine2.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBkAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBkAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBkAttorneyAddressLine2 = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;

                }
                //Logger.Trace("ENDED: Get mailing bKAttorney addressLine2.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine2" + ExMessage);
            }
            return MailingBkAttorneyAddressLine2;
        }

        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Borrower Attorney Mailing City State Zip");

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
                //Logger.Trace("ENDED:  To Get Borrower Attorney Mailing City State Zip");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return BorrowerAttorneyMailingCityStateZip;
        }
        /// <summary>
        /// 8
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetMailingCountry(AccountsModel accountsModel, bool isCoBorrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Mailing Country");

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
                //Logger.Trace("ENDED:  To Get Mailing Country");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return MailingCountry;
        }
        /// <summary>
        /// 15
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPaymentDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Mailing Country");

                PaymentDate = accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte;

                //Logger.Trace("ENDED:  To Get Mailing Country");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentDate;
        }

        public string GetInterestOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    InterestOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption1 = "null";
                }
                else
                {
                    InterestOption1 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                //Logger.Trace("ENDED:  To Get Interest Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption1;
        }
        public string GetEscrowOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Escrow Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    EscrowOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption1 = "null";
                }
                else
                {
                    EscrowOption1 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Escrow Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption1;
        }
        public string GetRegularMonthlyPaymentOption1(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option1");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption1 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption1 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData;
                }
                //Logger.Trace("ENDED:  To Get Regular Monthly Payment Option1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption1;
        }


        public string GetInterestOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    InterestOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption2 = "null";
                }
                else
                {
                    InterestOption2 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Interest Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption2;
        }
        public string GetEscrowOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Escrow Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    EscrowOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption2 = "null";
                }
                else
                {
                    EscrowOption2 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Escrow Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption2;
        }
        public string GetRegularMonthlyPaymentOption2(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option2");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption2 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption2 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Regular Monthly Payment Option2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption2;
        }

        public string GetInterestOption3(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    InterestOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    InterestOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption3 = "null";
                }
                else
                {
                    InterestOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                }
                //Logger.Trace("ENNDED:  To Get Interest Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption3;

        }
        public string GetEscrowOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Escrow Option3");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    EscrowOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    EscrowOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption3 = "null";
                }
                else
                {
                    EscrowOption3 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Escrow Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption3;
        }
        public string GetRegularMonthlyPaymentOption3(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option3");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData)
                    < Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData))
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption3 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption3 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Regular Monthly Payment Option3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption3;
        }

        public string GetInterestOption4(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest Option4");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    InterestOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    InterestOption4 = "null";
                }
                else
                {
                    InterestOption4 = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Interest Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return InterestOption4;
        }
        public string GetEscrowOption4(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Escrow Option4");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    EscrowOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowOption4 = "null";
                }
                else
                {
                    EscrowOption4 = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Escrow Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return EscrowOption4;
        }
        public string GetRegularMonthlyPaymentOption4(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment Option4");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption4 = "0.00";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    RegularMonthlyPaymentOption4 = "null";
                }
                else
                {
                    RegularMonthlyPaymentOption4 = accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData;

                }
                //Logger.Trace("ENDED:  To Get Regular Monthly Payment Option4");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RegularMonthlyPaymentOption4;
        }

        public string GetOption4MinimumDescription(AccountsModel accountsModel)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option4 Minimum Description");

                if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
               - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) > 0)
                {
                    Option4MinimumDescription = "Your principal balance will decrease and you will be closer to paying off your loan. ";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) == 0)
                {
                    Option4MinimumDescription = "Your principal balance will stay the same and you will not be closer to paying off your loan.";
                }
                else if (Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData) < 0)
                {
                    Option4MinimumDescription = "Your principal balance will increase.You will be borrowing more money and losing equity in your home.";
                }
                else
                {
                    Option4MinimumDescription = Convert.ToString(Convert.ToDecimal(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt1_PackedData)
                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:  To Get Option4 Minimum Description");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return Option4MinimumDescription;
        }

        public string GetPOBoxAddress(AccountsModel accountsModel)
        {
            //Getting the mailing state from the address line for comparision
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());

            try
            {
                //Logger.Trace("STARTED:  Execute to Get PO Box Address");

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
                //Logger.Trace("ENDED:  To Get PO Box Address");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return POBoxAddress;
        }
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
        public string GetAmount(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Amount");
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
        public string GetBuydownBalance(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Buy down Balance");

                if (Convert.ToDecimal(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                {
                    BuydownBalance = "N/A";
                }
                else
                {
                    BuydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                }
                //Logger.Trace("ENDED:  To Get Buy down Balance");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return BuydownBalance;
        }
        public string GetPartialClaim(AccountsModel accountsModel)
        {

            try
            {

                //Logger.Trace("STARTED:  Execute to Get Partial Claim");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    PartialClaim = "N/A";
                }
                else
                {
                    PartialClaim = accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                }
                //Logger.Trace("ENDED:  To Get Partial Claim");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PartialClaim;
        }


        public string GetInterestRateUntil(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get interest rate unit.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    InterestRateUntil = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date);
                }
                else
                {
                    InterestRateUntil = null;
                }
                //Logger.Trace("ENDED: Get get interest rate unit.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterestRateUnit" + ExMessage);

            }

            return InterestRateUntil;
        }

        public string GetPrepaymentPenalty(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Prepayment Penalty");

                PrepaymentPenalty = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0 ? "Yes" : "No";
                //Logger.Trace("ENDED:  To Get Prepayment Penalty");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PrepaymentPenalty;
        }
        public string GetAccountHistoryInformationbox(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Account History Information box");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30
               && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 30)
                {
                    AccountHistoryInformationbox = "DelinquencyNotice_MessageFlag";
                }
                else
                {
                    AccountHistoryInformationbox = string.Empty;
                }
                //Logger.Trace("ENDED:  To Get Account History Information box");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AccountHistoryInformationbox;
        }
        public string GetRecentPayment6(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment6");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_5;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                    && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                    && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; ;
                }
                //Logger.Trace("ENDED:  To Get Recent Payment6");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment6;
        }

        public string GetRecentPayment5(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment5");

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
                //Logger.Trace("ENDED:  To Get Recent Payment5");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return RecentPayment5;
        }

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
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return RecentPayment4;
        }

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
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment3;
        }

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
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment2;
        }

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
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment1;
        }


        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Lender Placed Insurance Message");
                if ((accountsModel.EscrowRecordModel.Any(r => r.rssi_esc_type == "20")
                   || accountsModel.EscrowRecordModel.Any(r => r.rssi_esc_type == "21")
                   && accountsModel.EscrowRecordModel.Any(r => r.Rssi_Ins_Co == "2450")
                  && (accountsModel.EscrowRecordModel.Any(er => er.Rssi_Ins_Ag == "29000")
                   || accountsModel.EscrowRecordModel.Any(eri => eri.Rssi_Ins_Ag == "29005")
                  || accountsModel.EscrowRecordModel.Any(ins => ins.Rssi_Ins_Ag == "43000")
                    || accountsModel.EscrowRecordModel.Any(insg => insg.Rssi_Ins_Ag == "43001"))))
                {
                    LenderPlacedInsuranceMessage = "LenderPlacedInsurance_MessageFlag";
                }
                //Logger.Trace("ENDED:  To Get Lender Placed Insurance Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
            }
            return LenderPlacedInsuranceMessage;
        }
        public string GetStateNSF(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get State NSF");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16
                || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18
                || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42
                )
                {
                    StateNSF = "StateNSF_MessageFlag";
                }
                //Logger.Trace("ENDED:  To Get State NSF");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return StateNSF;
        }
        public string GetAutodraftMessage(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Autodraft Message");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0
                && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft_MessageFlag";
                }
                //Logger.Trace("STARTED:  To Get Autodraft Message");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return AutodraftMessage;
        }
        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get CMS Partial Claim");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
               && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                {
                    CMSPartialClaim = "CMSPartialClaim_MessageFlag.";
                }
                //Logger.Trace("ENDED:  To Get CMS Partial Claim");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return CMSPartialClaim;
        }
        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get HUD Partial Claim");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
            && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                {
                    HUDPartialClaim = "HUDPartialClaim_MessageFlag.";
                }
                //Logger.Trace("ENDED:  To Get HUD Partial Claim");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return HUDPartialClaim;
        }


        public string GetStateDisclosures(AccountsModel accountsModel)
        {
            //Getting the mailing state from the address line for comparision
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());

            try
            {
                //Logger.Trace("STARTED:  Execute to Get State Disclosures");

                if (mailingState.Any(m => m == "4")
                   || mailingState.Any(m => m == "6")
                   || mailingState.Any(m => m == "12")
                   || mailingState.Any(m => m == "22")
                   || mailingState.Any(m => m == "24")
                   || mailingState.Any(m => m == "33")
                   || mailingState.Any(m => m == "34")
                   || mailingState.Any(m => m == "38")
                   || mailingState.Any(m => m == "43")
                   || mailingState.Any(m => m == "44")
                   || mailingState.Any(m => m == "AR")
                   || mailingState.Any(m => m == "CO")
                   || mailingState.Any(m => m == "HI")
                   || mailingState.Any(m => m == "MA")
                   || mailingState.Any(m => m == "MN")
                   || mailingState.Any(m => m == "NC")
                   || mailingState.Any(m => m == "NY")
                   || mailingState.Any(m => m == "OR")
                   || mailingState.Any(m => m == "TN")
                   || mailingState.Any(m => m == "TX"))
                {
                    StateDisclosures = "StateDisclosures_" + mailingAddress + "_MessageFlag";
                }
                //Logger.Trace("ENDED:  To Get State Disclosures");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return StateDisclosures;
        }


        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
            //Getting the mailing state from the address line for comparision
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
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentInformationMessage;
        }
    }
}
