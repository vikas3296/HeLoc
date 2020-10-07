using HelocService.Helpers;
using HelocService.Models.InputCopyBookModels;
using HelocService.BusinessExpert;
using HelocService.Helpers;
using System;
using System.Linq;
using System.Text;

namespace HelocService.BillingStatements
{
    public class StandardBillingStatement : IStandardBillingStatement
    {
        public string RecentPayment6 { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }
        public string AmountDue { get; set; }
        public string Principal { get; set; }
        public string AssistanceAmount { get; set; }
        public string ReplacementReserveAmount { get; set; }
        public string OverduePayment { get; set; }
        public string TotalFeesAndCharges { get; set; }
        public string TotalFeesPaid { get; set; }
        public string TotalAmountDue { get; set; }
        public string PastDueBalance { get; set; }
        public string DeferredBalance { get; set; }
        public string UnappliedFunds { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYearToDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string LatePaymentAmount { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string TotalDue { get; set; }
        public string DueBalance { get; set; }
        public string Hold { get; set; }
        public string Attention { get; set; }
        public string PrimaryBorrower { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public string MailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string DueDate { get; set; }
        public string IfPaymentisReceivedAfter { get; set; }
        public string LateFee { get; set; }
        public string AutodraftMessage { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string MaturityDate { get; set; }
        public string ModificationDate { get; set; }
        public string ChargeOffNoticeDelinquencyNoticeRefinanceMessage { get; set; }
        public string Interest { get; set; }
        public string EscrowTaxesandorInsurance { get; set; }
        public string RegularMonthlyPayment { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string NegativeAmortization { get; set; }
        public string CarringtonCharitableFoundationDonationPaidLastMonh { get; set; }
        public string CarringtonCharitableFoundationDonationPaidYeartoDate { get; set; }
        public string LockboxAddress { get; set; }
        public string IfReceivedAfter { get; set; }
        public string LateCharge { get; set; }
        public string CarringtonCharitableFoundationDonationbox { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string DelinquencyInformationbox { get; set; }
        public string LossMitigtationNotice { get; set; }
        public string ForeclosureNotice { get; set; }
        public string PreForeclosureNY90DayNotice { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string BankruptcyMessage { get; set; }
        public string RepaymentPlanMessage { get; set; }
        public string StateNSF { get; set; }
        public string ACHMessage { get; set; }
        public string ChargeOffNotice { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string StateDisclosures { get; set; }
        public string CarringtonCharitableFoundation { get; set; }
        public string PaymentInformationMessage { get; set; }
        public string ExMessage { get; set; }
        public ILogger Logger;

        public StandardBillingStatement(ILogger logger)
        {
            Logger = logger;
        }

        public StringBuilder finalLine;
        public StringBuilder GetFinalStringStandardBilling(AccountsModel accountModel, bool isCoBorrower = false)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();

            finalLine.Append(GetAmountDue(accountModel) + "|");
            finalLine.Append(GetPrincipal(accountModel) + "|");
            finalLine.Append(GetAssistanceAmount(accountModel) + "|");
            finalLine.Append(GetReplacementReserveAmount(accountModel) + "|");
            finalLine.Append(GetOverduePayment(accountModel) + "|");
            finalLine.Append(GetTotalFeesAndCharges(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaid(accountModel) + "|");
            finalLine.Append(GetTotalAmountDue(accountModel) + "|");
            finalLine.Append(GetPastDueBalance(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetUnappliedFunds(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetTotalPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetLatePaymentAmount(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            finalLine.Append(GetTotalDue(accountModel) + "|");
            finalLine.Append(GetHold(accountModel) + "|");
            finalLine.Append(GetAttention(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetPrimaryBorrower(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingAddressLine1(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingAddressLine2(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingCityStateZip(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingCountry(accountModel) + "|");
            finalLine.Append(GetPaymentReceivedAfter(accountModel) + "|");
            finalLine.Append(GetLateFee(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetInterestRateUnit(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetMaturityDate(accountModel) + "|");
            finalLine.Append(GetmodificationDate(accountModel) + "|");
            finalLine.Append(GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(accountModel) + "|");
            finalLine.Append(GetInterest(accountModel) + "|");
            finalLine.Append(GetEscrowTaxesInsurance(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetNegativeAmortization(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundationMonth(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitablePaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetLockboxAddress(accountModel) + "|");
            finalLine.Append(GetReceivedAfter(accountModel) + "|");
            finalLine.Append(GetLateCharge(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableDonationbox(accountModel) + "|");
            finalLine.Append(GetEffectiveDate(accountModel) + "|");
            finalLine.Append(GetTotalAmount(accountModel) + "|");
            finalLine.Append(GetDelinquencyInformationbox(accountModel) + "|");
            finalLine.Append(GetRecentPayment6(accountModel) + "|");
            finalLine.Append(GetRecentPayment5(accountModel) + "|");
            finalLine.Append(GetRecentPayment4(accountModel) + "|");
            finalLine.Append(GetRecentPayment3(accountModel) + "|");
            finalLine.Append(GetRecentPayment2(accountModel) + "|");
            finalLine.Append(GetRecentPayment1(accountModel) + "|");
            finalLine.Append(GetLossMitigatationNotice(accountModel) + "|");
            finalLine.Append(GetForeclosureNotice(accountModel) + "|");
            finalLine.Append(GetPreForeclosureNotice(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetBankruptcyMessage(accountModel) + "|");
            finalLine.Append(GetRepaymentPlanMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetACHMessage(accountModel) + "|");
            finalLine.Append(GetChargeOffNotice(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");
            return finalLine;
        }
        /* While Calculating Conditions must be applied*/
        public string GetAmountDue(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get amount due.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDue = "0.00";
                }
                else
                {
                    AmountDue = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get  amount due.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return AmountDue;
        }
        public string GetPrincipal(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get principal.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    Principal = "0.00";
                }

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    Principal = "0.00";
                }
                else
                {
                    Principal = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData)
                                     - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED: Get  principal.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return Principal;
        }
        public string GetAssistanceAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get assistance amount.");
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
                //Logger.Trace("ENDED: Get  assistance amount.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return AssistanceAmount;
        }
        public string GetReplacementReserveAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to replacement reserve amount.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData)
                       - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData)
                        - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                       + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    ReplacementReserveAmount = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveAmount = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveAmount = "0.00";
                else
                {
                    ReplacementReserveAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));


                }
                //Logger.Trace("ENDED: Get  replacement reserve amount.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return ReplacementReserveAmount;
        }
        public string GetOverduePayment(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to overdue payment.");
                OverduePayment = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) 
                                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
                                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                      - Convert.ToDecimal(GetTotalFeesPaid(accountsModel)));
                //Logger.Trace("ENDED: Get  overdue payment.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }

            return OverduePayment;
        }
        public string GetTotalFeesAndCharges(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get total fees and charges.");
                var Total = (accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData != null ?
                    Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) : 0)
                   + accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData != null ?
                   Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) : 0;

                var res = (from s in accountsModel.TransactionRecordModelList
                          where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                          && (s.Rssi_Tr_Fee_Code == "198" || s.Rssi_Tr_Fee_Code == "67")
                          select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();


                TotalFeesAndCharges = Convert.ToString(Total - Convert.ToDecimal(res));

                //Logger.Trace("ENDED: Get  total fees and charges.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }

            return TotalFeesAndCharges;
        }
        public string GetTotalFeesPaid(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total fees paid.");
                if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                             + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                              Convert.ToDecimal(GetTotalFeesAndCharges(accountsModel)))
                {
                    TotalFeesPaid = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesAndCharges(accountsModel)));
                }
                else
                    TotalFeesPaid = "0.00";

                //Logger.Trace("ENDED: Get  total fees paid.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }

            return TotalFeesPaid;
        }
        public string GetTotalAmountDue(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total amount due.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDue = "0.00";
                else
                    TotalAmountDue = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                //Logger.Trace("ENDED: Get  total amount due.");


            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return TotalAmountDue;
        }

        public string GetPastDueBalance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get past due balance.");
                DueBalance = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                  Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                  Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
                //Logger.Trace("ENDED: Get get past due balance.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }

            return DueBalance;
        }
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) -
                Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) -
                   Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                //Logger.Trace("ENDED:    To Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
        }
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get unapplied funds.");
                UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
                //Logger.Trace("ENDED: Get get unapplied funds.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return UnappliedFunds;
        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get fees and charges paid last month.");

                var value = (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
                  + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));

                var result = (from s in accountsModel.TransactionRecordModelList
                             where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                             && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                             select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                if (result != null)
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString(value
                    - Convert.ToDecimal(result));
                }
                else
                    FeesAndChargesPaidLastMonth = Convert.ToString(value);


                //Logger.Trace("ENDED: Get get fees and charges paid last month.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                decimal total = 0;
                foreach (var item in accountsModel.TransactionRecordModelList)
                {
                    // total += tra.Rssi_Tr_Amt_To_Evar_PackedData == null ? 0 : Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Evar_PackedData)
                    //+ tra.Rssi_Tr_Amt_To_Evar_2 == null ? 0 : CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_2)
                    //+ tra.Rssi_Tr_Amt_To_Evar_3 == null ? 0 : CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_3)
                    //+ tra.Rssi_Tr_Amt_To_Evar_4 == null ? 0 : CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_4)
                    //+ tra.Rssi_Tr_Amt_To_Evar_5 == null ? 0 : CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_5);
                    total += Convert.ToDecimal(item.Rssi_Tr_Amt_To_Evar_PackedData) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_2) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_3) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_4) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_5);
                }
               
                UnappliedFundsPaidLastMonth = Convert.ToString(total);

                return UnappliedFundsPaidLastMonth;
                //Logger.Trace("ENDED: Get get unapplied funds paid last month.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
           
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total paid last month");

                var result = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData);              

                var res = (from s in accountsModel.TransactionRecordModelList
                          where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                          && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                          select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();


                result -= Convert.ToDecimal(res);
                result += Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt);

                TotalPaidLastMonth = Convert.ToString(result);

                //Logger.Trace("ENDED: Get get total paid last month.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }

            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get fees and charges paid yeartodate.");
                var result = (from s in accountsModel.TransactionRecordModelList
                             where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                             && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                             select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();
                FeesAndChargesPaidYearToDate = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                  + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                  - Convert.ToDecimal(result));

                //Logger.Trace("ENDED: Get get fees and charges paid yeartodate.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }
            return FeesAndChargesPaidYearToDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get unapplied funds paid yeartodate.");
                UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
                //Logger.Trace("ENDED: Get get unapplied funds paid yeartodate.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total paid yeartodate.");
                var result = (from s in accountsModel.TransactionRecordModelList
                             where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                             && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                             select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                var rssiUnapFund = (accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);

                TotalPaidYearToDate = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                                       + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                                       + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                                       + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                                       + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                                       + rssiUnapFund)
                                       + Convert.ToDecimal(accountsModel.SupplementalCCFModel.YTDAmnt)
                                       - Convert.ToDecimal(result));

                //Logger.Trace("ENDED: Get get total paid yeartodate.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return TotalPaidYearToDate;
        }
        public string GetLatePaymentAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get late payment amount.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    LatePaymentAmount = "N/A";
                }
                else
                {
                    LatePaymentAmount = Convert.ToString((accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) : 0)
                        + (accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) : 0)
                        + (accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData) : 0));
                }
                //Logger.Trace("ENDED: Get get late payment amount.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }
            return LatePaymentAmount;
        }
        public string GetSuspense(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get suspense.");
                decimal total = 0;
                foreach (var tra in accountsModel.TransactionRecordModelList)
                {
                    total +=
                     Convert.ToDecimal(tra.Rssi_Tr_Amt_To_Evar_PackedData) +
                    CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_2) +
                    CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_3) +
                    CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_4) +
                    CommonHelper.ConvertEBCDICtoDecimal(tra.Rssi_Tr_Amt_To_Evar_5);
                }


                return Suspense = Convert.ToString(total); ;
                //Logger.Trace("ENDED: Get get suspense.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }
        }
        public string GetMiscellaneous(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get miscellaneous.");
                decimal total = 0;
                foreach (var tra in accountsModel.TransactionRecordModelList)
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
                


                return Miscellaneous = Convert.ToString(total);
                //Logger.Trace("ENDED: Get get miscellaneous.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }

        }
        public string GetTotalDue(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total due.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalDue = "0.00";
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get get total due.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }
            return TotalDue;
        }
        public string GetHold(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get print statement.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    Hold = "Create image but do not mail";
                }
                else
                {
                    Hold = string.Empty;
                }
                //Logger.Trace("ENDED: Get get print statement.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalDue" + ExMessage);
            }

            return Hold;
        }

        public string GetAttention(AccountsModel accountsModel, bool isCoBorrower = false)
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


        public string GetPrimaryBorrower(AccountsModel accountsModel, bool isCoBorrower = false)
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


        public string GetSecondaryBorrower(AccountsModel accountsModel, bool isCoBorrower = false)
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
                //Logger.Trace("ENDED: Get get secondary borrower.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetSecondaryBorrower" + ExMessage);

            }
            return SecondaryBorrower;
        }

        public string GetMailingAddressLine1(AccountsModel accountsModel, bool isCoBorrower = false)
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

        public string GetMailingAddressLine2(AccountsModel accountsModel, bool isCoBorrower = false)
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

        public string GetMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false)
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
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
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
                //Logger.Trace("ENDED: Get get mailing mailing country.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingCountry" + ExMessage);

            }

            return MailingCountry;
        }

        public string GetPaymentReceivedAfter(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get payment received after.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    IfPaymentisReceivedAfter = string.Empty;
                }
                else
                {
                    IfPaymentisReceivedAfter = Convert.ToString(CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Dte))));
                }
                //Logger.Trace("ENDED: Get get payment received after.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPaymentReceivedAfter" + ExMessage);

            }
            return IfPaymentisReceivedAfter;
        }

        public string GetLateFee(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get late fee.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    LateFee = string.Empty;
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

        public string GetAutodraftMessage(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get auto draft message.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 &&
                     Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft_MessageFlag";
                }
                //Logger.Trace("ENDED: Get get auto draft message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAutodraftMessage" + ExMessage);
            }

            return AutodraftMessage;
        }

        public string GetInterestRateUnit(AccountsModel accountsModel)// visit again
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
                //Logger.Trace("STARTED:  Execute get prepayment penalty.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                {
                    PrepaymentPenalty = "Yes";
                }
                else
                {
                    PrepaymentPenalty = "No";
                }
                //Logger.Trace("ENDED: Get get prepayment penalty.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrepaymentPenalty" + ExMessage);
            }
            return PrepaymentPenalty;
        }

        public string GetMaturityDate(AccountsModel accountsModel)// visit again
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get maturity date.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    MaturityDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date);
                }
                else
                {
                    MaturityDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Mat_Date);
                }
                //Logger.Trace("ENDED: Get get maturity date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMaturityDate" + ExMessage);

            }
            return MaturityDate;
        }

        public string GetmodificationDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get modification date.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Modify_Date).IncludeCenturyDate(true)) > 19000000)
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

        public string GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get charge off notice delinquency notice refinance message.");
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                {
                    ChargeOffNoticeDelinquencyNoticeRefinanceMessage = "ChargeNotice_MessageFlag";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30
                    && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    ChargeOffNoticeDelinquencyNoticeRefinanceMessage = "DelinquencyNotice_MessageFlag";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30 
                    && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    ChargeOffNoticeDelinquencyNoticeRefinanceMessage = "ReFinance_MessageFlag";
                }

                //Logger.Trace("ENDED: Get get charge off notice delinquency notice refinance message.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetChargeOffNoticeDelinquencyNoticeRefinanceMessage" + ExMessage);

            }

            return ChargeOffNoticeDelinquencyNoticeRefinanceMessage;
        }

        public string GetInterest(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get interest.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0
                     || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    Interest = "0.00";
                }
                else
                {
                    Interest = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                //Logger.Trace("ENDED: Get get interest.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterest" + ExMessage);

            }

            return Interest;
        }

        public string GetEscrowTaxesInsurance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get escrow taxes insurance.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0
                    || Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowTaxesandorInsurance = "0.00";
                }
                else
                {
                    EscrowTaxesandorInsurance = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;
                }
                //Logger.Trace("ENDED: Get get escrow taxes insurance.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetEscrowTaxesInsurance" + ExMessage);

            }

            return EscrowTaxesandorInsurance;
        }

        public string GetRegularMonthlyPayment(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get regular monthly payment.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPayment = "0.00";
                }
                else
                {
                    RegularMonthlyPayment = accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get regular monthly payment.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRegularMonthlyPayment" + ExMessage);

            }
            return RegularMonthlyPayment;
        }

        public string GetBuydownBalance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get buy down balance.");
                if (Convert.ToDecimal(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                {
                    BuydownBalance = "N/A";
                }
                else
                {
                    BuydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                }
                //Logger.Trace("ENDED: Get get buy down balance.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetBuydownBalance" + ExMessage);

            }
            return BuydownBalance;
        }

        public string GetPartialClaim(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    PartialClaim = "N/A";
                }
                else
                {
                    PartialClaim = accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPartialClaim" + ExMessage);
            }
            //Logger.Trace("ENDED: Get get partial claim.");
            return PartialClaim;
        }

        public string GetNegativeAmortization(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get negative amortization.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
                {
                    NegativeAmortization = "N/A";
                }
                else
                {
                    NegativeAmortization = accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData;
                }
                //Logger.Trace("ENDED: Get get negative amortization.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetNegativeAmortization" + ExMessage);

            }
            return NegativeAmortization;
        }

        public string GetCarringtonCharitableFoundationMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable foundation.");
                if (Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt) > 0
                    || Convert.ToDecimal(accountsModel.SupplementalCCFModel.YTDAmnt) > 0)
                {
                    CarringtonCharitableFoundation = "CharitableFoundation_MessageFlag";
                }
                //Logger.Trace("ENDED: Get get carrington charitable foundation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCarringtonCharitableFoundationMonth" + ExMessage);

            }

            return CarringtonCharitableFoundation;
        }

        public string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable paid yeartodate.");
                if (Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt) > 0
                    || Convert.ToDecimal(accountsModel.SupplementalCCFModel.YTDAmnt) > 0)
                {
                    CarringtonCharitableFoundationDonationPaidYeartoDate = "CharitableFoundation_MessageFlag";
                }
                //Logger.Trace("ENDED: Get get carrington charitable paid yeartodate.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCarringtonCharitablePaidYeartoDate" + ExMessage);

            }

            return CarringtonCharitableFoundationDonationPaidYeartoDate;
        }

        public string GetLockboxAddress(AccountsModel accountsModel)
        {

            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());

            try
            {
                //Logger.Trace("STARTED:  Execute get lockbox address.");
                if (mailingState.Any(m => m == "KS")
                    || mailingState.Any(m => m == "LA")
                    || mailingState.Any(m => m == "NM")
                    || mailingState.Any(m => m == "OK")
                    || mailingState.Any(m => m == "TX"))
                {
                    LockboxAddress = "PO Box 660586 Dallas, " + mailingAddress + " 75266-0586";
                }
                else
                {
                    LockboxAddress = "PO Box 7006 Pasadena, " + mailingAddress + " 91109-9998";
                }

                //Logger.Trace("ENDED: Get get lockbox address.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetLockboxAddress" + ExMessage);
            }
            return LockboxAddress;
        }

        public string GetReceivedAfter(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get received after.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    IfPaymentisReceivedAfter = "LateCharge_MessageFlag";
                }
                else
                {
                    IfPaymentisReceivedAfter = Convert.ToString(CommonHelper.GetDateTime(Convert.ToString(CommonHelper.ConvertEBCDICtoInt(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Dte))));
                }
                //Logger.Trace("ENDED: Get get received after.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetReceivedAfter" + ExMessage);
            }
            return IfPaymentisReceivedAfter;
        }

        public string GetLateCharge(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get late charge.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    LateCharge = "LateCharge_MessageFlag";
                }
                else
                {
                    LateCharge = accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get late charge.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetLateCharge" + ExMessage);

            }


            return LateCharge;
        }

        public string GetCarringtonCharitableDonationbox(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable donationbox.");
                if (accountsModel.SupplementalCCFModel.Eligible == "Yes")
                {
                    CarringtonCharitableFoundationDonationbox = "CharitableFoundation_MessageFlag";
                }
                else
                {
                    CarringtonCharitableFoundationDonationbox = string.Empty;
                }
                //Logger.Trace("ENDED: Get get carrington charitable donationbox.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCarringtonCharitableDonationbox" + ExMessage);

            }

            return CarringtonCharitableFoundationDonationbox;
        }

        public string GetEffectiveDate(AccountsModel accountModel)
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

            var effectivedate = Date != null ? Convert.ToString(CommonHelper.GetDateTime(Date)) : string.Empty;
            return effectivedate;
        }

        public string GetTotalAmount(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total amount.");

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
                Logger.Error(ex, "Method name : GetTotalAmount" + ExMessage);
            }

            return Amount;
        }

        public string GetDelinquencyInformationbox(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get delinquency informationbox.");
                decimal val = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq);
                if (val >= 30 && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    DelinquencyInformationbox = "DelinquencyNotice_MessageFlag";
                }
                else
                {
                    DelinquencyInformationbox = string.Empty;
                }
                //Logger.Trace("ENDED: Get get delinquency informationbox.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetDelinquencyInformationbox" + ExMessage);

            }

            return DelinquencyInformationbox;
        }

        public string GetRecentPayment6(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get recent payment6.");
                var rssi_Past_Date = WorkFlowExpert.Rssi_Past_Date_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();
                var rssi_Reg_Amt_PackedData = WorkFlowExpert.Rssi_Reg_Amt_PackedData_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment6 = "Payment Due "+ CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_5);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment6 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment6 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment6 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                {
                    RecentPayment6 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion1) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion1) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment6 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;
                }
                //Logger.Trace("ENDED: Get  recent payment6.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetRecentPayment6" + ExMessage);
            }

            return RecentPayment6;
        }

        public string GetRecentPayment5(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment5");

                var rssi_Past_Date = WorkFlowExpert.Rssi_Past_Date_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();
                var rssi_Reg_Amt_PackedData = WorkFlowExpert.Rssi_Reg_Amt_PackedData_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment5 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment5 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment5 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment5 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment5 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion2) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion2) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment5 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;
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

                var rssi_Past_Date = WorkFlowExpert.Rssi_Past_Date_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();
                var rssi_Reg_Amt_PackedData = WorkFlowExpert.Rssi_Reg_Amt_PackedData_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment4 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment4 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment4 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4
                    && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment4 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment4 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion3) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion3) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment4 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion3;
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

                var rssi_Past_Date = WorkFlowExpert.Rssi_Past_Date_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();
                var rssi_Reg_Amt_PackedData = WorkFlowExpert.Rssi_Reg_Amt_PackedData_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment3 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment3 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3
                    && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment3 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment3 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion3) > 0)
                {
                    RecentPayment3 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion3;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion4) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion4) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment3 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion4) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion4;
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

                var rssi_Past_Date = WorkFlowExpert.Rssi_Past_Date_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();
                var rssi_Reg_Amt_PackedData = WorkFlowExpert.Rssi_Reg_Amt_PackedData_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();


                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment2 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1);
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2
                   && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment2 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment2 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4
                    && int.Parse(rssi_Past_Date.Postion3) > 0)
                {
                    RecentPayment2 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion3;

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion4) > 0)
                {
                    RecentPayment2 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion4) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion4;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion5) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion5) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment2 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion5) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion5;
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

                var rssi_Past_Date = WorkFlowExpert.Rssi_Past_Date_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();
                var rssi_Reg_Amt_PackedData = WorkFlowExpert.Rssi_Reg_Amt_PackedData_Model.Where(m => m.AccountNo == accountModel.MasterFileDataPart_1Model.Rssi_Acct_No).Select(m => m).FirstOrDefault();

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1
                    && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment1 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                    rssi_Reg_Amt_PackedData.Postion1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment1 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3
                    && int.Parse(rssi_Past_Date.Postion3) > 0)
                {
                    RecentPayment1 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4
                    && int.Parse(rssi_Past_Date.Postion4) > 0)
                {
                    RecentPayment1 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion4) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion4;

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion5) > 0)
                {
                    RecentPayment1 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion5) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion5;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion6) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion6) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment1 = "Payment Due " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion6) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion6;
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



        public string GetLossMitigatationNotice(AccountsModel accountsModel)
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
                //Logger.Trace("ENDED: Get get loss mitigtation notice.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetLossMitigtationNotice" + ExMessage);

            }

            return LossMitigtationNotice;
        }


        public string GetForeclosureNotice(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get foreclosure notice.");
                if (accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date != null && accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date != "")
                {
                    //if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date).IncludeCenturyDate(true)) > 0)
                    if(int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date) > 0)
                    {
                        ForeclosureNotice = "PLEASE TAKE NOTICE that Carrington Mortgage Services, LLC has made the first notice or filing required to start a foreclosure.";
                    }
                }
                //Logger.Trace("ENDED: Get get foreclosure notice.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetForeclosureNotice" + ExMessage);

            }

            return ForeclosureNotice;
        }

        public string GetPreForeclosureNotice(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get preforeclosure notice.");
                if (accountsModel.SupplementalCCFModel.SentNO631 != null)
                {

                    if (int.Parse(accountsModel.SupplementalCCFModel.SentNO631) == 1)
                    {
                        PreForeclosureNY90DayNotice = "LEASE TAKE NOTICE that Carrington Mortgage Services, LLC has fulfilled, the pre - foreclosure notice requirements of Real Property Actions and Proceedings Law §1304 or Uniform Commercial Code § 9‐611(f), if applicable.";
                    }
                    if (int.Parse(accountsModel.SupplementalCCFModel.SentNO631) == 0)
                    {
                        PreForeclosureNY90DayNotice = string.Empty;
                    }
                }
                //Logger.Trace("ENDED: Get get  preforeclosure notice.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPreForeclosureNotice" + ExMessage);

            }
            return PreForeclosureNY90DayNotice;
        }

        public string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get lender placed insurance message.");
                if (accountModel.EscrowRecordModel.Any(r => r.rssi_esc_type == "20")
                || accountModel.EscrowRecordModel.Any(r => r.rssi_esc_type == "21")
                && accountModel.EscrowRecordModel.Any(r => r.Rssi_Ins_Co == "2450")
                && (accountModel.EscrowRecordModel.Any(er => er.Rssi_Ins_Ag == "29000")
                || accountModel.EscrowRecordModel.Any(eri => eri.Rssi_Ins_Ag == "29005")
                || accountModel.EscrowRecordModel.Any(ins => ins.Rssi_Ins_Ag == "43000")
                || accountModel.EscrowRecordModel.Any(insg => insg.Rssi_Ins_Ag == "43001")))
                {
                    LenderPlacedInsuranceMessage = "LenderPlacedInsurance_MessageFlag";
                }

                //Logger.Trace("ENDED: Get get  lender placed insurance message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetLenderPlacedInsuranceMessage" + ExMessage);
            }

            return LenderPlacedInsuranceMessage;
        }

        public string GetBankruptcyMessage(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get bankruptcy message.");
                var result = (from s in accountsModel.ArchivedBankruptcyDetailRecordModel
                              where int.Parse(s.Rssi_K_B_Dschg_Dt_PackedData) > 0
                                               && int.Parse(s.Rssi_K_B_Reaffirm_Dt_PackedData) == 0
                              select (s)).FirstOrDefault();

                if (result != null)
                    BankruptcyMessage = "Bankruptcy_MessageFlag";

                //Logger.Trace("ENDED: Get get bankruptcy message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetBankruptcyMessage" + ExMessage);
            }
            return BankruptcyMessage;
        }

        public string GetRepaymentPlanMessage(AccountsModel accountsModel)
        {
            String repaymentPlanMessage = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get repayment plan message.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Repy_Remain_Bal_PackedData != "00000C")
                {
                    repaymentPlanMessage = "RepaymentPlan_MessageFlag";
                }
                //Logger.Trace("ENDED: Get get  repayment plan message.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRepaymentPlanMessage" + ExMessage);

            }
            return repaymentPlanMessage;
        }


        public string GetStateNSF(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get stateNSF.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6")
                {
                    StateNSF = "StateNSF6_MessageFlag"; 
                }
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16")
                {
                    StateNSF = "StateNSF16_MessageFlag";
                }
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18")
                {
                    StateNSF = "StateNSF18_MessageFlag";
                }
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "42")
                {
                    StateNSF = "StateNSF42_MessageFlag";
                }
                //Logger.Trace("ENDED: Get get stateNSF.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetStateNSF" + ExMessage);

            }

            return StateNSF;
        }

        public string GetACHMessage(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get ACH message.");
                //if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData).IncludeCenturyDate(true)) == 0 
                if(int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) == 0
                    && Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) == 0)
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

        public string GetChargeOffNotice(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get charge off notice.");
                //if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData).IncludeCenturyDate(true)) > 0)

                if(int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                {
                    ChargeOffNotice = "ChargeOff_MessageFlag";
                }
                //Logger.Trace("ENDED: Get charge off notice.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetChargeOffNotice" + ExMessage);

            }
            return ChargeOffNotice;
        }

        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get CMS partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                    && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                {
                    CMSPartialClaim = "CMSPartialClaim_MessageFlag"; 
                }
                //Logger.Trace("ENDED: Get CMS partial claim.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCMSPartialClaim" + ExMessage);
            }

            return CMSPartialClaim;
        }

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
                Logger.Error(ex, "Method name : GetHUDPartialClaim" + ExMessage);
            }


            return HUDPartialClaim;
        }

        public string GetStateDisclosures(AccountsModel accountsModel)
        {
            try
            {
                string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
                var mailingState = mailingAddress.Split(" ".ToCharArray());

                //Logger.Trace("STARTED:  Execute get state disclosures.");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 4
                    && mailingState.Any(m => m == "AR"))
                {
                    StateDisclosures = "StateDisclosures4AR_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6
                     && mailingState.Any(m => m == "CO"))
                {
                    StateDisclosures = "StateDisclosures6CO_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 12
                    && mailingState.Any(m => m == "HI"))
                {
                    StateDisclosures = "StateDisclosures12HI_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 22
                    && mailingState.Any(m => m == "MA"))
                {
                    StateDisclosures = "StateDisclosures4AR_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 24
                     && mailingState.Any(m => m == "MN"))
                {
                    StateDisclosures = "StateDisclosures24MN_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && mailingState.Any(m => m == "NY"))
                {
                    StateDisclosures = "StateDisclosures33NY_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 34
                     && mailingState.Any(m => m == "NC"))
                {
                    StateDisclosures = "StateDisclosures34NC_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 43
                   && mailingState.Any(m => m == "TN"))
                {
                    StateDisclosures = "StateDisclosures43TN_MessageFlag";
                }
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 44
                   && mailingState.Any(m => m == "TX"))
                {
                    StateDisclosures = "StateDisclosures44TX_MessageFlag";
                }
                //Logger.Trace("ENDED: Get state disclosures.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetStateDisclosures" + ExMessage);
            }

            return StateDisclosures;
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable foundation.");
                if (accountsModel.SupplementalCCFModel.Eligible != null
                    && accountsModel.SupplementalCCFModel.PriorMoAmnt != null
                    && accountsModel.SupplementalCCFModel.YTDAmnt != null)
                {
                    if (accountsModel.SupplementalCCFModel.Eligible == "Yes"
                        || Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt) > 0
                        || Convert.ToDecimal(accountsModel.SupplementalCCFModel.YTDAmnt) > 0)
                    {
                        CarringtonCharitableFoundation = "CharitableFoundation_MessageFlag"; 
                    }
                }
                //Logger.Trace("ENDED: Get carrington charitable foundation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCarringtonCharitableFoundation" + ExMessage);
            }


            return CarringtonCharitableFoundation;
        }

        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
     
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());

            try
            {
                //Logger.Trace("STARTED:  Execute get payment information message.");
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
                //Logger.Trace("ENDED:  To Get PO Box Address");

                //Logger.Trace("ENDED: Get payment information message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentInformationMessage" + ex.TargetSite.Name);

                return "";
            }
            return PaymentInformationMessage;
        }

    }
}
