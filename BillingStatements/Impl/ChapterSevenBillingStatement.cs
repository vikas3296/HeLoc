using System;
using System.Text;
using HelocService.Helpers;
using HelocService.Models.InputCopyBookModels;
using HelocService.Helpers;
using System.Linq;
using HelocService.BusinessExpert;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace HelocService.BillingStatements
{
    public class ChapterSevenBillingStatement : IChapterSevenBillingStatement
    {

        public string PrintStatement { get; set; }
        public string PaymentAmount { get; set; }
        public string DeferredBalance { get; set; }
        public string Principal { get; set; }
        public string PastUnpaidAmount { get; set; }
        public string TotalFeesandCharges { get; set; }
        public Decimal TotalFeesPaid { get; set; }
        public string TotalPaymentAmount { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string TotalDue { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string ExMessage { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }
        public string PrimaryBorrowerBkAttorney { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingBkAttorneyAddressLine1 { get; set; }
        public string MailingBkAttorneyAddressLine2 { get; set; }
        public string BorrowerAttorneyMailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string PaymentDate { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string Interest { get; set; }
        public string EscrowTaxesAndOrInsurance { get; set; }
        public string RegularMonthlyPayment { get; set; }
        public string CarringtonCharitableFoundationDonationPaidLastMonh { get; set; }
        public string CarringtonCharitableFoundationDonationPaidYearToDate { get; set; }
        //public string PaymentDate { get; set; }
        public string PoBoxAddress { get; set; }
        public string AccountHistoryInformationBox { get; set; }
        public string RecentPayment6 { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string StateNsf { get; set; }
        public string AutodraftMessage { get; set; }
        public string CmsPartialClaim { get; set; }
        public string HudPartialClaim { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string StateDisclosures { get; set; }
        public string CarringtonCharitableFoundation { get; set; }
        public string PaymentInformationMessage { get; set; }
        public string HUDPartialClaim { get; private set; }

        public StringBuilder finalLine;
        public ILogger Logger;
        public ChapterSevenBillingStatement(ILogger logger)
        {
            Logger = logger;
        }

        public StringBuilder GetFinalChapterSevenBillingStatement(AccountsModel accountModel, bool isCoborrower = false)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();

            finalLine.Append(GetPaymentAmount(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetPrincipal(accountModel) + "|");
            finalLine.Append(GetPastUnpaidAmount(accountModel) + "|");
            finalLine.Append(GetTotalFeesandCharges(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaid(accountModel) + "|");
            finalLine.Append(GetTotalPaymentAmount(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetTotalPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalDue(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");


            //Conditional Statement Methods
            finalLine.Append(GetPrintStatement(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel, isCoborrower) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel, isCoborrower) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel, isCoborrower) + "|");

            finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel, isCoborrower) + "|");
            finalLine.Append(GetMailingCountry(accountModel, isCoborrower) + "|");
            finalLine.Append(GetPaymentDate(accountModel) + "|");


            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetInterest(accountModel) + "|");
            finalLine.Append(GetEscrowTaxesandInsurance(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundationDonationPaidLastMonh(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundationDonationPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountModel) + "|");
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
            finalLine.Append(Geteffectivedate(accountModel) + "|");
            finalLine.Append(GetAmount(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");

            return finalLine;
        }

        /* While Calculating Conditions must be applied*/
        public string GetPaymentAmount(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get payment amount");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    PaymentAmount = Convert.ToString("0.00");
                }
                else
                {
                    PaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get payment amount");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentAmount" + ExMessage);

            }
            return PaymentAmount;
        }
        public string GetDeferredBalance(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get deferred bBalance");
                if ((Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                //Logger.Trace("ENDED: Get deferred Balance");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetDeferredBalance" + ExMessage);
            }
            return DeferredBalance;
        }
        public string GetPrincipal(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get principal");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0" || accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData == "0")
                {
                    Principal = "0.00";
                }
                else
                {
                    Principal = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) 
                        - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));

                }
                //Logger.Trace("ENDED: Get principal");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrincipal" + ExMessage);
            }
            return Principal;
        }

        public string GetPastUnpaidAmount(AccountsModel accountModel)
        {
            //Total Fees Paid was not there so used total fees due
            try
            {
                //Logger.Trace("STARTED:  Execute to Get past unpaid amount");
                PastUnpaidAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) 
                    - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) 
                    - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) 
                    - Convert.ToDecimal(GetTotalFeesPaid(accountModel)));
                //Logger.Trace("ENDED: Get past unpaid amount");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPastUnpaidAmount" + ExMessage);
            }
            return PastUnpaidAmount;
        }
        public string GetTotalFeesandCharges(AccountsModel accountModel)
        {
            //conditional statement is ther but not applying
            try
            {
                decimal result = 0;
                //Logger.Trace("STARTED:  Execute to Get total fees and charges");
                result = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

                var res = (from s in accountModel.TransactionRecordModelList
                           where s.Rssi_Log_Tran == "5605"
                           && s.Rssi_Tr_Fee_Code == "67"
                           select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                result -= Convert.ToDecimal(res);

                var rest = (from s in accountModel.TransactionRecordModelList
                            where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                            && s.Rssi_Tr_Fee_Code == "198"
                            select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                TotalFeesandCharges = Convert.ToString(result - Convert.ToDecimal(rest));

                //Logger.Trace("ENDED: Get total fees and charges");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalFeesandCharges" + ExMessage);
            }
            return TotalFeesandCharges;
        }
        public decimal GetTotalFeesPaid(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total fees paid");
                if ((Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData) +
                        Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                        Convert.ToDecimal(GetTotalFeesandCharges(accountModel)))

                {
                    TotalFeesPaid = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData) -
                     Convert.ToDecimal(GetTotalFeesandCharges(accountModel));
                }

                else
                {
                    TotalFeesPaid = Convert.ToInt64(0.00);
                }
                //Logger.Trace("ENDED: Get total fees paid");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalFeesPaid" + ExMessage);
            }

            return TotalFeesPaid;
        }
        public string GetTotalPaymentAmount(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total payment amount");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    TotalPaymentAmount = Convert.ToString("0.00");
                }
                else
                {
                    TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get total payment amount");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalPaymentAmount" + ExMessage);
            }
            return TotalPaymentAmount;

        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get fees and charges paid last month");
                var result = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                   Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData);

                var res = (from s in accountsModel.TransactionRecordModelList
                           where (s.Rssi_Log_Tran == "5605" || s.Rssi_Log_Tran == "5707")
                           && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                           select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();


                FeesAndChargesPaidLastMonth = Convert.ToString(result - Convert.ToDecimal(res));
                //Logger.Trace("ENDED: Get fees and charges paid last month");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetFeesAndChargesPaidLastMonth" + ExMessage);
            }

            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get unapplied funds paid last month");
                decimal result = 0;
                foreach (var item in accountModel.TransactionRecordModelList)
                {
                    result += Convert.ToDecimal(item.Rssi_Tr_Amt_To_Evar_PackedData) +
                    CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_3) +
                    CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_4) +
                    CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_2) +
                    CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_5);                  
                }   

                UnappliedFundsPaidLastMonth = Convert.ToString(result);

                //Logger.Trace("ENDED: Get  unapplied funds paid last month");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetUnappliedFundsPaidLastMonth" + ExMessage);
            }
            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                var result = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData);

                //Logger.Trace("STARTED:  Execute to Get total paid last month");

                var res = (from s in accountsModel.TransactionRecordModelList
                           where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                           && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                           select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();

                result -= Convert.ToDecimal(res);

                TotalPaidLastMonth = Convert.ToString(result + Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt));

                //Logger.Trace("ENDED: Get  total paid last month");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalPaidLastMonth" + ExMessage);
            }

            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get fees and charges paid year to date");
                var total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData);

                var res = (from s in accountModel.TransactionRecordModelList
                           where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                           && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                           select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();


                FeesAndChargesPaidYeartoDate = Convert.ToString(total - Convert.ToDecimal(res));
                //Logger.Trace("ENDED: Get fees and charges paid year to date");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetFeesAndChargesPaidYeartoDate" + ExMessage);
            }
            return FeesAndChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get unapplied funds paid year to date");
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) +
                    (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) +
                    (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) +
                    (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
                //Logger.Trace("ENDED: Get unapplied funds paid year to date");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetUnappliedFundsPaidYearToDate" + ExMessage);
            }
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total paid year to date");
                var result = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData) 
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) + (accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0) +
                    Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt);


                var res = (from s in accountModel.TransactionRecordModelList
                           where (s.Rssi_Log_Tran == "5705" || s.Rssi_Log_Tran == "5707")
                           && (s.Rssi_Tr_Fee_Code == "67" || s.Rssi_Tr_Fee_Code == "198")
                           select s.Rssi_Tr_Amt_PackedData).FirstOrDefault();



                TotalPaidYearToDate = Convert.ToString(result - Convert.ToDecimal(res));

                //Logger.Trace("ENDED: Get total paid year to date");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalPaidYearToDate" + ExMessage);
            }
            return TotalPaidYearToDate;
        }

        public string GetTotalDue(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total due");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    TotalDue = Convert.ToString("0.00");
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get total due");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalDue" + ExMessage);
            }
            return TotalDue;

        }
        public string GetSuspense(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get suspense");
                decimal result = 0;
                foreach (var item in accountModel.TransactionRecordModelList)
                {
                    result += Convert.ToDecimal(item.Rssi_Tr_Amt_To_Evar_PackedData) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_2) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_3) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_4) +
                     CommonHelper.ConvertEBCDICtoDecimal(item.Rssi_Tr_Amt_To_Evar_5);

                }

                Suspense = Convert.ToString(result);
                //Logger.Trace("ENDED: Get suspense");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetSuspense" + ExMessage);
            }
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Miscellaneous");
                decimal total = 0;
                foreach (var tra in accountModel.TransactionRecordModelList)
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

        public string GetPrintStatement(AccountsModel accountModel)
        {



            try
            {
                //Logger.Trace("STARTED:  Execute to Get print statement");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    PrintStatement = "Create image but do not mail";
                }
                else
                {
                    PrintStatement = string.Empty;
                }
                //Logger.Trace("ENDED: Get print statement");
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
                        MailingCountry = null;
                }
                else
                {
                    MailingCountry = null;
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



        public string GetBuydownBalance(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get buy down balance.");
                if (Convert.ToDecimal(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                { 
                    BuydownBalance = "N/A"; 
                }
                else 
                { 
                    BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData; 
                }
                //Logger.Trace("ENDED: Get buy down balance.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetBuydownBalance" + ExMessage);
            }

            return BuydownBalance;
        }

        public string GetPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get partial claim.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                { 
                    PartialClaim = "N/A"; 
                }
                else 
                { 
                    PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData; 
                }
                //Logger.Trace("ENDED: Get partial claim.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPartialClaim" + ExMessage);
            }

            return PartialClaim;
        }

        
        public string GetInterestRateUntil(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get interest rate until.");
                if (long.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
                {
                    InterestRateUntil = "Until " + CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date);
                }
                else 
                { 
                    InterestRateUntil = null; 
                }
                //Logger.Trace("ENDED: Get interest rate until.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetInterestRateUntil" + ExMessage);
            }

            return InterestRateUntil;
        }

        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get prepayment penalty.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                { 
                    PrepaymentPenalty = "Yes"; 
                }
                else 
                { 
                    PrepaymentPenalty = "No"; 
                }
                //Logger.Trace("ENDED: Get prepayment penalty.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPrepaymentPenalty" + ExMessage);
            }

            return PrepaymentPenalty;
        }
        public string GetInterest(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get interest.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { 
                    Interest = "0.00"; 
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) 
                { 
                    Interest = "0.00"; 
                }
                else
                {
                    Interest = accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                //Logger.Trace("ENDED: Get interest.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetInterest" + ExMessage);
            }
            return Interest;
        }

        public string GetEscrowTaxesandInsurance(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get escrow taxes and insurance.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { 
                    EscrowTaxesAndOrInsurance = "0.00"; 
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) 
                { 
                    EscrowTaxesAndOrInsurance = "0.00"; 
                }
                else
                {
                    EscrowTaxesAndOrInsurance = accountModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;
                }
                //Logger.Trace("ENDED: Get escrow taxes and insurance.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetEscrowTaxesandInsurance" + ExMessage);
            }
            return EscrowTaxesAndOrInsurance;
        }

        public string GetRegularMonthlyPayment(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get regular monthly payment.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { 
                    RegularMonthlyPayment = "0.00"; 
                }
                else
                {
                    RegularMonthlyPayment = accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get regular monthly payment.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetRegularMonthlyPayment" + ExMessage);
            }

            return RegularMonthlyPayment;
        }


        public string GetCarringtonCharitableFoundationDonationPaidLastMonh(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get carrington paid last month.");
                if (Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 
                    || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                { 
                    CarringtonCharitableFoundationDonationPaidLastMonh = "CharitableFoundationDonation_MessageFlag"; 
                }
                else
                {
                    CarringtonCharitableFoundationDonationPaidLastMonh = accountModel.SupplementalCCFModel.PriorMoAmnt;
                }
                //Logger.Trace("ENDED: Get regular monthly payment.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetCarringtonPaidLastMonh" + ExMessage);
            }

            return CarringtonCharitableFoundationDonationPaidLastMonh;
        }

        public string GetCarringtonCharitableFoundationDonationPaidYearToDate(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get carrington charitable paid yearto date.");
                if (Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 
                    || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                { 
                    CarringtonCharitableFoundationDonationPaidYearToDate = "CharitableFoundationDonation_MessageFlag"; 
                }
                else
                {
                    CarringtonCharitableFoundationDonationPaidYearToDate = accountModel.SupplementalCCFModel.YTDAmnt;
                }
                //Logger.Trace("ENDED: Get carrington charitable paid yearto date.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetCarringtonCharitablePaidYeartoDate" + ExMessage);
            }

            return CarringtonCharitableFoundationDonationPaidYearToDate;
        }


        public string GetPOBoxAddress(AccountsModel accountsModel)
        {
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
            var mailingState = mailingAddress.Split(" ".ToCharArray());

            try
            {
                //Logger.Trace("STARTED:  Execute to Get PO Box Address");

                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                      || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA"
                      || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM"
                      || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                      || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {
                    PoBoxAddress = "PO Box 660586 Dallas, " + mailingAddress + " 75266-0586";
                }
                else
                {
                    PoBoxAddress = "PO Box 7006 Pasadena, " + mailingAddress + " 91109-9998";
                }
                //Logger.Trace("ENDED:  To Get PO Box Address");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return PoBoxAddress;
        }



        public string GetAccountHistoryInformationbox(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get account history information box.");
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 &&
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { 
                    AccountHistoryInformationBox = "DelinquencyNoticeSection_MessageFlag"; 
                }
                else 
                { 
                    AccountHistoryInformationBox = string.Empty; 
                }
                //Logger.Trace("ENDED: Get  account history information box.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetAccountHistoryInformationbox" + ExMessage);
            }

            return AccountHistoryInformationBox;
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
                    RecentPayment6 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_5);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment6 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment6 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment6 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                {
                    RecentPayment6 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion1) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion1) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment6 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
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
                    RecentPayment5 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment5 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment5 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment5 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment5 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion2) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion2) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment5 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
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
                    RecentPayment4 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment4 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment4 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                      accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4
                    && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment4 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment4 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion3) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion3) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment4 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
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
                    RecentPayment3 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2) + ": Fully paid on " +
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2);
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment3 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " +
                       accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3
                    && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment3 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment3 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion3) > 0)
                {
                    RecentPayment3 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion3;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion4) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion4) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment3 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion4) + ": Unpaid balance of " +
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
                    RecentPayment2 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1) + ": Fully paid on " + 
                        CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1);
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2
                   && int.Parse(rssi_Past_Date.Postion1) > 0)
                {
                    RecentPayment2 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment2 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4
                    && int.Parse(rssi_Past_Date.Postion3) > 0)
                {
                    RecentPayment2 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion3;

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5
                    && int.Parse(rssi_Past_Date.Postion4) > 0)
                {
                    RecentPayment2 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion4) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion4;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion5) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion5) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment2 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion5) + ": Unpaid balance of " +
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
                    RecentPayment1 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion1) + ": Unpaid balance of " +
                    rssi_Reg_Amt_PackedData.Postion1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 
                    && int.Parse(rssi_Past_Date.Postion2) > 0)
                {
                    RecentPayment1 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion2) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 
                    && int.Parse(rssi_Past_Date.Postion3) > 0)
                {
                    RecentPayment1 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion3) + ": Unpaid balance of " +
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
                    RecentPayment1 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion5) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion5;
                }

                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && int.Parse(rssi_Past_Date.Postion6) > 0
                && Convert.ToDecimal(rssi_Reg_Amt_PackedData.Postion5) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment1 = CommonHelper.GetConvertDateYYMMDDToDDMMYYFormat(rssi_Past_Date.Postion5) + ": Unpaid balance of " +
                        rssi_Reg_Amt_PackedData.Postion5;
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


        public string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get lender placed insurance message.");
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
                //Logger.Trace("ENDED: Get  lender placed insurance message.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetLenderPlacedInsuranceMessage" + ExMessage);
            }
            return LenderPlacedInsuranceMessage;
        }


        public string GetStateNSF(AccountsModel accountModel)
        {

            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6")
                {
                    StateNsf = "StateNSF6_MessageFlag";
                }
                if (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16")
                {
                    StateNsf = "StateNSF16_MessageFlag";
                }
                if (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18")
                {
                    StateNsf = "StateNSF18_MessageFlag";
                }
                if (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "42")
                {
                    StateNsf = "StateNSF42_MessageFlag";
                }

                return StateNsf;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateNSFMessage" + ex.TargetSite.Name);
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
                //Logger.Trace("ENDED:    To Auto draft Message operation.");
                return AutodraftMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAutodraftMessage " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetCMSPartialClaim(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get CMS partial claim.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                    && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                {
                    CmsPartialClaim = "CMSPartialClaim_MessageFlag";
                }
                //Logger.Trace("ENDED: Get CMS partial claim.");
                return CmsPartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCMSPartialClaim" + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetHUDPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get hud partial claim.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0
                    && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                {
                    HUDPartialClaim = "HUDPartialClaim_MessageFlag";
                }
                //Logger.Trace("ENDED: Get hud partial claim.");
            }
            //Logger.Trace("ENDED: Get hud partial claim.");
            catch (Exception ex)
            {
                Logger.Error(ex, "GetHUDPartialClaim" + ex.TargetSite.Name);
                return "";
            }
            return HUDPartialClaim;
        }

        public string Geteffectivedate(AccountsModel accountModel)
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
           
            return Date!=null?Convert.ToString(CommonHelper.GetDateTime(Date)):string.Empty;
        }

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


        public string GetStateDisclosures(AccountsModel accountModel)
        {
            try
            {
                string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
                var mailingState = mailingAddress.Split(" ".ToCharArray());

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
                      && mailingState.Any(m => m == "NY"))
                {
                    StateDisclosures = "StateDisclosures33NY_MessageFlag";
                }
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 34
                      && mailingState.Any(m => m == "NC"))
                {
                    StateDisclosures = "StateDisclosures34NC_MessageFlag";
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
                Logger.Error(ex, "GetStateDisclosures" + ex.TargetSite.Name);

                return "";
            }
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Carrington Charitable Foundation operation.");
                if (Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0
                   || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                {

                    CarringtonCharitableFoundation = "CharitableFoundation_MessageFlag";

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

        public string GetPaymentInformationMessage(AccountsModel accountModel)
        {
            string mailingAddress = System.Text.RegularExpressions.Regex.Replace(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3, @"\s+", " ");
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