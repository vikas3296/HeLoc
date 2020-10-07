using HelocService.Models.InputCopyBookModels;
using System.Text;

namespace HelocService.BillingStatements
{
    public interface IChapterSevenOptionARMStatement
    {
        string AccountHistoryInformationbox { get; set; }
        string Amount { get; set; }
        string AmountDueOption1 { get; set; }
        string AmountDueOption2 { get; set; }
        string AmountDueOption3 { get; set; }
        string AmountDueOption4 { get; set; }
        string AssistanceAmount { get; set; }
        string AssistanceAmountOption2 { get; set; }
        string AssistanceAmountOption3 { get; set; }
        string AssistanceAmountOption4 { get; set; }
        string AutodraftMessage { get; set; }
        string BorrowerAttorneyMailingCityStateZip { get; set; }
        string BuydownBalance { get; set; }
        string CMSPartialClaim { get; set; }
        string Date { get; set; }
        string DeferredBalance { get; set; }
        string EscrowOption1 { get; set; }
        string EscrowOption2 { get; set; }
        string EscrowOption3 { get; set; }
        string EscrowOption4 { get; set; }
        string ExMessage { get; set; }
        string FeesandChargesPaidLastMonth { get; set; }
        string FeesandChargesPaidYeartoDate { get; set; }
        string Hold { get; set; }
        string HUDPartialClaim { get; set; }
        string InterestOption1 { get; set; }
        string InterestOption2 { get; set; }
        string InterestOption3 { get; set; }
        string InterestOption4 { get; set; }
        string InterestRateUntil { get; set; }
        string LenderPlacedInsuranceMessage { get; set; }
        string MailingBKAttorneyAddressLine1 { get; set; }
        string MailingBKAttorneyAddressLine2 { get; set; }
        string MailingCountry { get; set; }
        string Miscellaneous { get; set; }
        string Option4MinimumDescription { get; set; }
        string OverduePaymentsOption1 { get; set; }
        string OverduePaymentsOption2 { get; set; }
        string OverduePaymentsOption3 { get; set; }
        string OverduePaymentsOption4 { get; set; }
        string PartialClaim { get; set; }
        string PaymentAmountOption1 { get; set; }
        string PaymentAmountOption2 { get; set; }
        string PaymentAmountOption3 { get; set; }
        string PaymentAmountOption4 { get; set; }
        string PaymentDate { get; set; }
        string PaymentInformationMessage { get; set; }
        string POBoxAddress { get; set; }
        string PrepaymentPenalty { get; set; }
        string PrimaryBorrowerBKAttorney { get; set; }
        string PrincipalOption1 { get; set; }
        string PrincipalOption2 { get; set; }
        string PrincipalOption3 { get; set; }
        string PrincipalOption4 { get; set; }
        string RecentPayment1 { get; set; }
        string RecentPayment2 { get; set; }
        string RecentPayment3 { get; set; }
        string RecentPayment4 { get; set; }
        string RecentPayment5 { get; set; }
        string RecentPayment6 { get; set; }
        string RegularMonthlyPaymentOption1 { get; set; }
        string RegularMonthlyPaymentOption2 { get; set; }
        string RegularMonthlyPaymentOption3 { get; set; }
        string RegularMonthlyPaymentOption4 { get; set; }
        string ReplacementReserve { get; set; }
        string ReplacementReserveOption2 { get; set; }
        string ReplacementReserveOption3 { get; set; }
        string ReplacementReserveOption4 { get; set; }
        string SecondaryBorrower { get; set; }
        string StateDisclosures { get; set; }
        string StateNSF { get; set; }
        string Suspense { get; set; }
        string TotalAmountDueOption1 { get; set; }
        string TotalAmountDueOption2 { get; set; }
        string TotalAmountDueOption3 { get; set; }
        string TotalAmountDueOption4 { get; set; }
        string TotalDue { get; set; }
        string TotalFeesChargedOption1 { get; set; }
        string TotalFeesChargedOption2 { get; set; }
        string TotalFeesChargedOption3 { get; set; }
        string TotalFeesChargedOption4 { get; set; }
        string TotalFeesPaidOption1 { get; set; }
        string TotalFeesPaidOption2 { get; set; }
        string TotalFeesPaidOption3 { get; set; }
        string TotalFeesPaidOption4 { get; set; }
        string UnappliedFundsPaidLastMonth { get; set; }
        string UnappliedFundsPaidYearToDate { get; set; }

        string GetAccountHistoryInformationbox(AccountsModel accountsModel);
        string GetAmount(AccountsModel accountsModel);
        string GetAmountDueOption1(AccountsModel accountsModel);
        string GetAmountDueOption2(AccountsModel accountsModel);
        string GetAmountDueOption3(AccountsModel accountsModel);
        string GetAmountDueOption4(AccountsModel accountsModel);
        string GetAssistanceAmount(AccountsModel accountsModel);
        string GetAssistanceAmountOption2(AccountsModel accountsModel);
        string GetAssistanceAmountOption3(AccountsModel accountsModel);
        string GetAssistanceAmountOption4(AccountsModel accountsModel);
        string GetAutodraftMessage(AccountsModel accountsModel);
        string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel, bool isCoborrower = false);
        string GetBuydownBalance(AccountsModel accountsModel);
        string GetCMSPartialClaim(AccountsModel accountsModel);
        string GetDate(AccountsModel accountsModel);
        string GetDeferredBalance(AccountsModel accountsModel);
        string GetEscrowOption1(AccountsModel accountsModel);
        string GetEscrowOption2(AccountsModel accountsModel);
        string GetEscrowOption3(AccountsModel accountsModel);
        string GetEscrowOption4(AccountsModel accountsModel);
        string GetFeesandChargesPaidLastMonth(AccountsModel accountsModel);
        string GetFeesandChargesPaidYeartoDate(AccountsModel accountsModel);
        StringBuilder GetFinalChapterSevenOptionARMStatement(AccountsModel accountModel, bool isCoborrower = false);
        string GetHold(AccountsModel accountsModel);
        string GetHUDPartialClaim(AccountsModel accountsModel);
        string GetInterestOption1(AccountsModel accountsModel);
        string GetInterestOption2(AccountsModel accountsModel);
        string GetInterestOption3(AccountsModel accountsModel);
        string GetInterestOption4(AccountsModel accountsModel);
        string GetInterestRateUntil(AccountsModel accountsModel);
        string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel);
        string GetMailingBKAttorneyAddressLine1(AccountsModel accountsModel, bool isCoborrower = false);
        string GetMailingBKAttorneyAddressLine2(AccountsModel accountsModel, bool isCoborrower = false);
        string GetMailingCountry(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMiscellaneous(AccountsModel accountsModel);
        string GetOption4MinimumDescription(AccountsModel accountsModel);
        string GetOverduePaymentsOption1(AccountsModel accountsModel);
        string GetOverduePaymentsOption2(AccountsModel accountsModel);
        string GetOverduePaymentsOption3(AccountsModel accountsModel);
        string GetOverduePaymentsOption4(AccountsModel accountsModel);
        string GetPartialClaim(AccountsModel accountsModel);
        string GetPaymentAmountOption1(AccountsModel accountsModel);
        string GetPaymentAmountOption2(AccountsModel accountsModel);
        string GetPaymentAmountOption3(AccountsModel accountsModel);
        string GetPaymentAmountOption4(AccountsModel accountsModel);
        string GetPaymentDate(AccountsModel accountsModel);
        string GetPaymentInformationMessage(AccountsModel accountsModel);
        string GetPOBoxAddress(AccountsModel accountsModel);
        string GetPrepaymentPenalty(AccountsModel accountsModel);
        string GetPrimaryBorrowerBKAttorney(AccountsModel accountsModel, bool isCoborrower = false);
        string GetPrincipalOption1(AccountsModel accountsModel);
        string GetPrincipalOption2(AccountsModel accountsModel);
        string GetPrincipalOption3(AccountsModel accountsModel);
        string GetPrincipalOption4(AccountsModel accountsModel);
        string GetRecentPayment1(AccountsModel accountModel);
        string GetRecentPayment2(AccountsModel accountModel);
        string GetRecentPayment3(AccountsModel accountModel);
        string GetRecentPayment4(AccountsModel accountModel);
        string GetRecentPayment5(AccountsModel accountModel);
        string GetRecentPayment6(AccountsModel accountModel);
        string GetRegularMonthlyPaymentOption1(AccountsModel accountsModel);
        string GetRegularMonthlyPaymentOption2(AccountsModel accountsModel);
        string GetRegularMonthlyPaymentOption3(AccountsModel accountsModel);
        string GetRegularMonthlyPaymentOption4(AccountsModel accountsModel);
        string GetReplacementReserve(AccountsModel accountsModel);
        string GetReplacementReserveOption2(AccountsModel accountsModel);
        string GetReplacementReserveOption3(AccountsModel accountsModel);
        string GetReplacementReserveOption4(AccountsModel accountsModel);
        string GetSecondaryBorrower(AccountsModel accountsModel);
        string GetStateDisclosures(AccountsModel accountsModel);
        string GetStateNSF(AccountsModel accountsModel);
        string GetSuspense(AccountsModel accountsModel);
        string GetTotalAmountDueOption1(AccountsModel accountsModel);
        string GetTotalAmountDueOption2(AccountsModel accountsModel);
        string GetTotalAmountDueOption3(AccountsModel accountsModel);
        string GetTotalAmountDueOption4(AccountsModel accountsModel);
        string GetTotalDue(AccountsModel accountsModel);
        string GetTotalFeesChargedOption1(AccountsModel accountsModel);
        string GetTotalFeesChargedOption2(AccountsModel accountsModel);
        string GetTotalFeesChargedOption3(AccountsModel accountsModel);
        string GetTotalFeesChargedOption4(AccountsModel accountsModel);
        string GetTotalFeesPaidOption1(AccountsModel accountsModel);
        string GetTotalFeesPaidOption2(AccountsModel accountsModel);
        string GetTotalFeesPaidOption3(AccountsModel accountsModel);
        string GetTotalFeesPaidOption4(AccountsModel accountsModel);
        string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel);
        string GeUnappliedFundsPaidLastMonth(AccountsModel accountsModel);
    }
}