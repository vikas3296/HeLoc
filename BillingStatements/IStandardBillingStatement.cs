using HelocService.Models.InputCopyBookModels;
using System.Text;

namespace HelocService.BillingStatements
{
    public interface IStandardBillingStatement
    {
        string ACHMessage { get; set; }
        string Amount { get; set; }
        string AmountDue { get; set; }
        string AssistanceAmount { get; set; }
        string Attention { get; set; }
        string AutodraftMessage { get; set; }
        string BankruptcyMessage { get; set; }
        string BuydownBalance { get; set; }
        string CarringtonCharitableFoundation { get; set; }
        string CarringtonCharitableFoundationDonationbox { get; set; }
        string CarringtonCharitableFoundationDonationPaidLastMonh { get; set; }
        string CarringtonCharitableFoundationDonationPaidYeartoDate { get; set; }
        string ChargeOffNotice { get; set; }
        string ChargeOffNoticeDelinquencyNoticeRefinanceMessage { get; set; }
        string CMSPartialClaim { get; set; }
        string Date { get; set; }
        string DeferredBalance { get; set; }
        string DelinquencyInformationbox { get; set; }
        string DueBalance { get; set; }
        string DueDate { get; set; }
        string EscrowTaxesandorInsurance { get; set; }
        string ExMessage { get; set; }
        string FeesAndChargesPaidLastMonth { get; set; }
        string FeesAndChargesPaidYearToDate { get; set; }
        string ForeclosureNotice { get; set; }
        string Hold { get; set; }
        string HUDPartialClaim { get; set; }
        string IfPaymentisReceivedAfter { get; set; }
        string IfReceivedAfter { get; set; }
        string Interest { get; set; }
        string InterestRateUntil { get; set; }
        string LateCharge { get; set; }
        string LateFee { get; set; }
        string LatePaymentAmount { get; set; }
        string LenderPlacedInsuranceMessage { get; set; }
        string LockboxAddress { get; set; }
        string LossMitigtationNotice { get; set; }
        string MailingAddressLine1 { get; set; }
        string MailingAddressLine2 { get; set; }
        string MailingCityStateZip { get; set; }
        string MailingCountry { get; set; }
        string MaturityDate { get; set; }
        string Miscellaneous { get; set; }
        string ModificationDate { get; set; }
        string NegativeAmortization { get; set; }
        string OverduePayment { get; set; }
        string PartialClaim { get; set; }
        string PastDueBalance { get; set; }
        string PaymentInformationMessage { get; set; }
        string PreForeclosureNY90DayNotice { get; set; }
        string PrepaymentPenalty { get; set; }
        string PrimaryBorrower { get; set; }
        string Principal { get; set; }
        string RecentPayment1 { get; set; }
        string RecentPayment2 { get; set; }
        string RecentPayment3 { get; set; }
        string RecentPayment4 { get; set; }
        string RecentPayment5 { get; set; }
        string RecentPayment6 { get; set; }
        string RegularMonthlyPayment { get; set; }
        string RepaymentPlanMessage { get; set; }
        string ReplacementReserveAmount { get; set; }
        string SecondaryBorrower { get; set; }
        string StateDisclosures { get; set; }
        string StateNSF { get; set; }
        string Suspense { get; set; }
        string TotalAmountDue { get; set; }
        string TotalDue { get; set; }
        string TotalFeesAndCharges { get; set; }
        string TotalFeesPaid { get; set; }
        string TotalPaidLastMonth { get; set; }
        string TotalPaidYearToDate { get; set; }
        string UnappliedFunds { get; set; }
        string UnappliedFundsPaidLastMonth { get; set; }
        string UnappliedFundsPaidYearToDate { get; set; }

        string GetACHMessage(AccountsModel accountsModel);
        string GetAmountDue(AccountsModel accountsModel);
        string GetAssistanceAmount(AccountsModel accountsModel);
        string GetAttention(AccountsModel accountsModel, bool isCoBorrower);
        string GetAutodraftMessage(AccountsModel accountsModel);
        string GetBankruptcyMessage(AccountsModel accountsModel);
        string GetBuydownBalance(AccountsModel accountsModel);
        string GetCarringtonCharitableDonationbox(AccountsModel accountsModel);
        string GetCarringtonCharitableFoundation(AccountsModel accountsModel);
        string GetCarringtonCharitableFoundationMonth(AccountsModel accountsModel);
        string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountsModel);
        string GetChargeOffNotice(AccountsModel accountsModel);
        string GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(AccountsModel accountsModel);
        string GetCMSPartialClaim(AccountsModel accountsModel);
        string GetDeferredBalance(AccountsModel accountsModel);
        string GetDelinquencyInformationbox(AccountsModel accountsModel);
        string GetEffectiveDate(AccountsModel accountsModel);
        string GetEscrowTaxesInsurance(AccountsModel accountsModel);
        string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel);
        string GetFeesAndChargesPaidYearToDate(AccountsModel accountsModel);
        StringBuilder GetFinalStringStandardBilling(AccountsModel accountModel, bool isCoBorrower = false);
        string GetForeclosureNotice(AccountsModel accountsModel);
        string GetHold(AccountsModel accountsModel);
        string GetHUDPartialClaim(AccountsModel accountsModel);
        string GetInterest(AccountsModel accountsModel);
        string GetInterestRateUnit(AccountsModel accountsModel);
        string GetLateCharge(AccountsModel accountsModel);
        string GetLateFee(AccountsModel accountsModel);
        string GetLatePaymentAmount(AccountsModel accountsModel);
        string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel);
        string GetLockboxAddress(AccountsModel accountsModel);
        string GetLossMitigatationNotice(AccountsModel accountsModel);
        string GetMailingAddressLine1(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingAddressLine2(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMailingCountry(AccountsModel accountsModel);
        string GetMaturityDate(AccountsModel accountsModel);
        string GetMiscellaneous(AccountsModel accountsModel);
        string GetmodificationDate(AccountsModel accountsModel);
        string GetNegativeAmortization(AccountsModel accountsModel);
        string GetOverduePayment(AccountsModel accountsModel);
        string GetPartialClaim(AccountsModel accountsModel);
        string GetPastDueBalance(AccountsModel accountsModel);
        string GetPaymentInformationMessage(AccountsModel accountsModel);
        string GetPaymentReceivedAfter(AccountsModel accountsModel);
        string GetPreForeclosureNotice(AccountsModel accountsModel);
        string GetPrepaymentPenalty(AccountsModel accountsModel);
        string GetPrimaryBorrower(AccountsModel accountsModel, bool isCoBorrower);
        string GetPrincipal(AccountsModel accountsModel);
        string GetReceivedAfter(AccountsModel accountsModel);
        string GetRecentPayment1(AccountsModel accountModel);
        string GetRecentPayment2(AccountsModel accountModel);
        string GetRecentPayment3(AccountsModel accountModel);
        string GetRecentPayment4(AccountsModel accountModel);
        string GetRecentPayment5(AccountsModel accountModel);
        string GetRecentPayment6(AccountsModel accountModel);
        string GetRegularMonthlyPayment(AccountsModel accountsModel);
        string GetRepaymentPlanMessage(AccountsModel accountsModel);
        string GetReplacementReserveAmount(AccountsModel accountsModel);
        string GetSecondaryBorrower(AccountsModel accountsModel, bool isCoBorrower);
        string GetStateDisclosures(AccountsModel accountsModel);
        string GetStateNSF(AccountsModel accountsModel);
        string GetSuspense(AccountsModel accountsModel);
        string GetTotalAmount(AccountsModel accountsModel);
        string GetTotalAmountDue(AccountsModel accountsModel);
        string GetTotalDue(AccountsModel accountsModel);
        string GetTotalFeesAndCharges(AccountsModel accountsModel);
        string GetTotalFeesPaid(AccountsModel accountsModel);
        string GetTotalPaidLastMonth(AccountsModel accountsModel);
        string GetTotalPaidYearToDate(AccountsModel accountsModel);
        string GetUnappliedFunds(AccountsModel accountsModel);
        string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel);
        string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel);
    }
}