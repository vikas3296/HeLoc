using HelocService.Models.InputCopyBookModels;
using System.Text;

namespace HelocService.BillingStatements
{
    public interface IOptionARMBillingStatement
    {
        string ACHMessage { get; set; }
        string Amount { get; set; }
        string AmountDueOption1 { get; set; }
        string AmountDueOption2 { get; set; }
        string AmountDueOption3 { get; set; }
        string AmountDueOption4 { get; set; }
        string AssistanceAmountOption1 { get; set; }
        string AssistanceAmountOption2 { get; set; }
        string AssistanceAmountOption3 { get; set; }
        string AssistanceAmountOption4 { get; set; }
        string BankruptcyMessage { get; set; }
        string BuydownBalance { get; set; }
        string ChargeOffNotice { get; set; }
        string ChargeOffNoticeNoticeMessage { get; set; }
        string CMSPartialClaim { get; set; }
        string Date { get; set; }
        string DeferredBalance { get; set; }
        string DelinquencyNoticebox { get; set; }
        string DueDate { get; set; }
        string EscrowOption1 { get; set; }
        string EscrowOption2 { get; set; }
        string EscrowOption3 { get; set; }
        string EscrowOption4 { get; set; }
        string ExMessage { get; set; }
        string FeesAndChargesPaidLastMonth { get; set; }
        string FeesandChargesPaidYeartoDate { get; set; }
        string ForeclosureNotice { get; set; }
        string Hold { get; set; }
        string HUDPartialClaim { get; set; }
        string IfReceivedAfterDate { get; set; }
        string InterestOption1 { get; set; }
        string InterestOption2 { get; set; }
        string InterestOption3 { get; set; }
        string InterestOption4 { get; set; }
        string InterestRateUntil { get; set; }
        string LateChargeAmount { get; set; }
        string LateFee { get; set; }
        string LenderPlacedInsuranceMessage { get; set; }
        string LossMitigtationNotice { get; set; }
        string MailingCountry { get; set; }
        string MaturityDate { get; set; }
        string MinimumLatePaymentAmount { get; set; }
        string Miscellaneous { get; set; }
        string ModificationDate { get; set; }
        string NegativeAmortization { get; set; }
        string Option4MinimumDescription { get; set; }
        string OverduePaymentsOption1 { get; set; }
        string OverduePaymentsOption2 { get; set; }
        string OverduePaymentsOption3 { get; set; }
        string OverduePaymentsOption4 { get; set; }
        string PartialClaim { get; set; }
        string PastDueBalance { get; set; }
        string PaymentInformationMessage { get; set; }
        string PaymentIsReceivedAfter { get; set; }
        string POBoxAddress { get; set; }
        string PrepaymentPenalty { get; set; }
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
        string RepaymentPlanMessage { get; set; }
        string ReplacementReserveOption1 { get; set; }
        string ReplacementReserveOption2 { get; set; }
        string ReplacementReserveOption3 { get; set; }
        string ReplacementReserveOption4 { get; set; }
        string StateDisclosures { get; set; }
        string StateNSFMessage { get; set; }
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
        string TotalPaidYearToDate { get; set; }
        string UnappliedFunds { get; set; }
        string UnappliedFundsPaidLastMonth { get; set; }
        string UnappliedFundsPaidYearToDate { get; set; }

        string GeSuspense(AccountsModel model);
        string GetACHMessage(AccountsModel accountsModel);
        string GetAmountDueOption1(AccountsModel model);
        string GetAmountDueOption2(AccountsModel model);
        string GetAmountDueOption3(AccountsModel model);
        string GetAmountDueOption4(AccountsModel model);
        string GetAssistanceAmountOption1(AccountsModel model);
        string GetAssistanceAmountOption2(AccountsModel model);
        string GetAssistanceAmountOption3(AccountsModel model);
        string GetAssistanceAmountOption4(AccountsModel model);
        string GetAttention(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetBankruptcyMessage(AccountsModel accountsModel);
        string GetBuydownBalance(AccountsModel accountModel);
        string GetChargeOffNotice(AccountsModel accountsModel);
        string GetChargeOffNoticeNoticeMessage(AccountsModel accountModel);
        string GetCMSPartialClaim(AccountsModel accountsModel);
        string GetDeferredBalance(AccountsModel model);
        string GetDelinquencyNoticebox(AccountsModel accountModel);
        string GetEscrowOption1(AccountsModel accountModel);
        string GetEscrowOption2(AccountsModel accountModel);
        string GetEscrowOption3(AccountsModel accountModel);
        string GetEscrowOption4(AccountsModel accountModel);
        string GetFeesAndChargesPaidLastMonth(AccountsModel model);
        string GetFeesandChargesPaidYeartoDate(AccountsModel model);
        StringBuilder GetFinalOptionARMBillingStatement(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetForeclosureNotice(AccountsModel accountsModel);
        string GetHold(AccountsModel accountModel);
        string GetHUDPartialClaim(AccountsModel accountsModel);
        string GetInterestOption1(AccountsModel accountModel);
        string GetInterestOption2(AccountsModel accountModel);
        string GetInterestOption3(AccountsModel accountModel);
        string GetInterestOption4(AccountsModel accountModel);
        string GetInterestRateUntil(AccountsModel accountModel);
        string GetLateChargeAmount(AccountsModel accountModel);
        string GetLateFee(AccountsModel accountModel);
        string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel);
        string GetLossMitigtationNotice(AccountsModel accountsModel);
        string GetMailingAddressLine1(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingAddressLine2(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingCountry(AccountsModel accountModel);
        string GetMaturityDate(AccountsModel accountModel);
        string GetMinimumLatePaymentAmount(AccountsModel model);
        string GetMiscellaneous(AccountsModel model);
        string GetModificationDate(AccountsModel accountModel);
        string GetNegativeAmortization(AccountsModel accountModel);
        string GetOption4MinimumDescription(AccountsModel accountModel);
        string GetOverduePaymentsOption1(AccountsModel model);
        string GetOverduePaymentsOption2(AccountsModel model);
        string GetOverduePaymentsOption3(AccountsModel accountsModel);
        string GetOverduePaymentsOption4(AccountsModel model);
        string GetPartialClaim(AccountsModel accountModel);
        string GetPastDueBalance(AccountsModel model);
        string GetPaymentInformationMessage(AccountsModel accountsModel);
        string GetPaymentIsReceivedAfter(AccountsModel accountModel);
        string GetPOBoxAddress(AccountsModel accountModel);
        string GetPrepaymentPenalty(AccountsModel accountModel);
        string GetPrimaryBorrower(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetPrincipalOption1(AccountsModel model);
        string GetPrincipalOption2(AccountsModel model);
        string GetPrincipalOption3(AccountsModel model);
        string GetPrincipalOption4(AccountsModel model);
        string GetReceivedAfterDate(AccountsModel accountModel);
        string GetRecentPayment1(AccountsModel accountModel);
        string GetRecentPayment2(AccountsModel accountModel);
        string GetRecentPayment3(AccountsModel accountModel);
        string GetRecentPayment4(AccountsModel accountModel);
        string GetRecentPayment5(AccountsModel accountModel);
        string GetRecentPayment6(AccountsModel accountModel);
        string GetRegularMonthlyPaymentOption1(AccountsModel accountModel);
        string GetRegularMonthlyPaymentOption2(AccountsModel accountModel);
        string GetRegularMonthlyPaymentOption3(AccountsModel accountModel);
        string GetRegularMonthlyPaymentOption4(AccountsModel accountModel);
        string GetRepaymentPlanMessage(AccountsModel accountsModel);
        string GetReplacementReserveOption1(AccountsModel model);
        string GetReplacementReserveOption2(AccountsModel model);
        string GetReplacementReserveOption3(AccountsModel model);
        string GetReplacementReserveOption4(AccountsModel model);
        string GetSecondaryBorrower(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetStateDisclosures(AccountsModel accountsModel);
        string GetStateNSFMessage(AccountsModel accountsModel);
        string GetTotalAmountDueOption1(AccountsModel model);
        string GetTotalAmountDueOption2(AccountsModel model);
        string GetTotalAmountDueOption3(AccountsModel model);
        string GetTotalAmountDueOption4(AccountsModel model);
        string GetTotalDue(AccountsModel model);
        string GetTotalFeesChargedOption1(AccountsModel accountsModel);
        string GetTotalFeesChargedOption2(AccountsModel accountsModel);
        string GetTotalFeesChargedOption3(AccountsModel accountsModel);
        string GetTotalFeesChargedOption4(AccountsModel accountsModel);
        string GetTotalFeesPaidOption1(AccountsModel model);
        string GetTotalFeesPaidOption2(AccountsModel model);
        string GetTotalFeesPaidOption3(AccountsModel accountsModel);
        string GetTotalFeesPaidOption4(AccountsModel model);
        string GetTotalPaidYearToDate(AccountsModel accountsModel);
        string GetUnappliedFunds(AccountsModel accountsModel);
        string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel);
        string GeUnappliedFundsPaidLastMonth(AccountsModel model);
    }
}