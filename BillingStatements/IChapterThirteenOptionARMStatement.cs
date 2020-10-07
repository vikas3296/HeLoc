using HelocService.Models.InputCopyBookModels;
using System.Text;

namespace HelocService.BillingStatements
{
    public interface IChapterThirteenOptionARMStatement
    {
        string Amount { get; set; }
        string AmountDueOption1 { get; set; }
        string AmountDueOption2 { get; set; }
        string AmountDueOption3 { get; set; }
        string AmountDueOption4 { get; set; }
        string AssistanceAmountOption1 { get; set; }
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
        string PaymentDate { get; set; }
        string PaymentDate1 { get; set; }
        string PaymentInformationMessage { get; set; }
        string POBoxAddress { get; set; }
        string PostPetitonpastduemessage { get; set; }
        string PrepaymentPenalty { get; set; }
        string PrimaryBorrowerBKAttorney { get; set; }
        string PrincipalOption1 { get; set; }
        string PrincipalOption2 { get; set; }
        string PrincipalOption3 { get; set; }
        string PrincipalOption4 { get; set; }
        string RegularMonthlyPaymentOption1 { get; set; }
        string RegularMonthlyPaymentOption2 { get; set; }
        string RegularMonthlyPaymentOption3 { get; set; }
        string RegularMonthlyPaymentOption4 { get; set; }
        string ReplacementReserveOption1 { get; set; }
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
        string TotalFeesChargedOption1 { get; set; }
        string TotalFeesChargedOption2 { get; set; }
        string TotalFeesChargedOption3 { get; set; }
        string TotalFeesChargedOption4 { get; set; }
        string TotalFeesPaidOption1 { get; set; }
        string TotalFeesPaidOption2 { get; set; }
        string TotalFeesPaidOption3 { get; set; }
        string TotalFeesPaidOption4 { get; set; }
        string TotalPaidYearToDate { get; set; }
        string UnappliedFundsPaidLastMonth { get; set; }
        string UnappliedFundsPaidYearToDate { get; set; }

        string GetAmount(AccountsModel accountsModel);
        string GetAmountDueOption1(AccountsModel model);
        string GetAmountDueOption2(AccountsModel model);
        string GetAmountDueOption3(AccountsModel model);
        string GetAmountDueOption4(AccountsModel model);
        string GetAssistanceAmountOption1(AccountsModel model);
        string GetAssistanceAmountOption2(AccountsModel model);
        string GetAssistanceAmountOption3(AccountsModel model);
        string GetAssistanceAmountOption4(AccountsModel model);
        string GetAutodraftMessage(AccountsModel accountsModel);
        string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetBuydownBalance(AccountsModel accountsModel);
        string GetCMSPartialClaim(AccountsModel accountsModel);
        string GetDate(AccountsModel accountsModel);
        string GetDeferredBalance(AccountsModel model);
        string GetEscrowOption1(AccountsModel accountsModel);
        string GetEscrowOption2(AccountsModel accountsModel);
        string GetEscrowOption3(AccountsModel accountsModel);
        string GetEscrowOption4(AccountsModel accountsModel);
        string GetFeesandChargesPaidLastMonth(AccountsModel model);
        string GetFeesandChargesPaidYearToDate(AccountsModel model);
        StringBuilder GetFinalChapterThirteenOptionARMStatement(AccountsModel accountModel, bool isCoBorrower = false);
        string GetHold(AccountsModel accountsModel);
        string GetHUDPartialClaim(AccountsModel accountsModel);
        string GetInterestOption1(AccountsModel accountsModel);
        string GetInterestOption2(AccountsModel accountsModel);
        string GetInterestOption3(AccountsModel accountsModel);
        string GetInterestOption4(AccountsModel accountsModel);
        string GetInterestRateUntil(AccountsModel accountsModel);
        string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel);
        string GetMailingBKAttorneyAddressLine1(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingBKAttorneyAddressLine2(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingCountry(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMiscellaneous(AccountsModel model);
        string GetOption4MinimumDescription(AccountsModel accountsModel);
        string GetOverduePaymentsOption1(AccountsModel model);
        string GetOverduePaymentsOption2(AccountsModel model);
        string GetOverduePaymentsOption3(AccountsModel model);
        string GetOverduePaymentsOption4(AccountsModel model);
        string GetPartialClaim(AccountsModel accountsModel);
        string GetPaymentDate(AccountsModel accountsModel);
        string GetPaymentInformationMessage(AccountsModel accountsModel);
        string GetPOBoxAddress(AccountsModel accountsModel);
        string GetPostPetitonpastduemessage(AccountsModel accountsModel);
        string GetPrepaymentPenalty(AccountsModel accountsModel);
        string GetPrimaryBorrowerBKAttorney(AccountsModel accountsModel , bool isCoBorrower = false);
        string GetPrincipalOption1(AccountsModel model);
        string GetPrincipalOption2(AccountsModel model);
        string GetPrincipalOption3(AccountsModel model);
        string GetPrincipalOption4(AccountsModel model);
        string GetRegularMonthlyPaymentOption1(AccountsModel accountsModel);
        string GetRegularMonthlyPaymentOption2(AccountsModel accountsModel);
        string GetRegularMonthlyPaymentOption3(AccountsModel accountsModel);
        string GetRegularMonthlyPaymentOption4(AccountsModel accountsModel);
        string GetReplacementReserveOption1(AccountsModel model);
        string GetReplacementReserveOption2(AccountsModel model);
        string GetReplacementReserveOption3(AccountsModel model);
        string GetReplacementReserveOption4(AccountsModel model);
        string GetSecondaryBorrower(AccountsModel accountsModel);
        string GetStateDisclosures(AccountsModel accountsModel);
        string GetStateNSF(AccountsModel accountsModel);
        string GetSuspense(AccountsModel model);
        string GetTotalAmountDueOption1(AccountsModel model);
        string GetTotalAmountDueOption2(AccountsModel model);
        string GetTotalAmountDueOption3(AccountsModel model);
        string GetTotalAmountDueOption4(AccountsModel model);
        string GetTotalFeesChargedOption1(AccountsModel accountsModel);
        string GetTotalFeesChargedOption2(AccountsModel accountsModel);
        string GetTotalFeesChargedOption3(AccountsModel accountsModel);
        string GetTotalFeesChargedOption4(AccountsModel accountsModel);
        string GetTotalFeesPaidOption1(AccountsModel model);
        string GetTotalFeesPaidOption2(AccountsModel model);
        string GetTotalFeesPaidOption3(AccountsModel model);
        string GetTotalFeesPaidOption4(AccountsModel model);
        string GetTotalPaidYearToDate(AccountsModel model);
        string GetUnappliedFundsPaidLastMonth(AccountsModel model);
        string GetUnappliedFundsPaidYearToDate(AccountsModel model);
    }
}