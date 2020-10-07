using HelocService.Models.InputCopyBookModels;
using System.Text;

namespace HelocService.BillingStatements
{
    public interface IChapterThirteenBillingStatement
    {
        string Amount { get; set; }
        string AutodraftMessage { get; set; }
        string BorrowerAttorneyMailingCityStateZip { get; set; }
        string BuydownBalance { get; set; }
        string CarringtonCharitableFoundation { get; set; }
        string CarringtonFoundationDonationPaidLastMonth { get; set; }
        string CarringtonFoundationDonationPaidYearToDate { get; set; }
        string CMSPartialClaim { get; set; }
        string Date { get; set; }
        string DeferredBalance { get; set; }
        string EscrowTaxesandInsurance { get; set; }
        string ExMessage { get; set; }
        string FeesAndChargesPaidLastMonth { get; set; }
        string FeesAndChargesPaidYeartoDate { get; set; }
        string HUDPartialClaim { get; set; }
        string Interest { get; set; }
        string InterestRateUntil { get; set; }
        string LenderPlacedInsuranceMessage { get; set; }
        string MailingBKAttorneyAddressLine1 { get; set; }
        string MailingBKAttorneyAddressLine2 { get; set; }
        string MailingCountry { get; set; }
        string Miscellaneous { get; set; }
        string PartialClaim { get; set; }
        string PastUnpaidAmount { get; set; }
        string PaymentAmount { get; set; }
        string PaymentInformationMessage { get; set; }
        string POBoxAddress { get; set; }
        string PostPetitonPastDueMessage { get; set; }
        string PrepaymentPenalty { get; set; }
        string PrimaryBorrowerBKAttorney { get; set; }
        string Principal { get; set; }
        string PrintStatement { get; set; }
        string RegularMonthlyPayment { get; set; }
        string SecondaryBorrower { get; set; }
        string StateDisclosures { get; set; }
        string StateNSF { get; set; }
        string Suspense { get; set; }
        decimal TotalFeesPaid { get; set; }
        string TotalPaidLastMonth { get; set; }
        string TotalPaidYearToDate { get; set; }
        string TotalPaymentAmount { get; set; }
        string UnappliedFundsPaidLastMonth { get; set; }
        string UnappliedFundsPaidYearToDate { get; set; }

        string GetAutodraftMessage(AccountsModel accountModel);
        string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetBuydownBalance(AccountsModel accountModel);
        string GetCarringtonCharitableFoundation(AccountsModel accountModel);
        string GetCarringtonFoundationDonationPaidLastMonth(AccountsModel accountModel);
        string GetCarringtonFoundationDonationPaidYearToDate(AccountsModel accountModel);
        string GetCMSPartialClaim(AccountsModel accountModel);
        string GetDeferredBalance(AccountsModel accountsModel);
        string GetEscrowTaxesandInsurance(AccountsModel accountModel);
        string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel);
        string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel);
        StringBuilder GetFinalChapterThirteenBillingStatement(AccountsModel accountModel, bool isCoBorrower = false);
        string GetHUDPartialClaim(AccountsModel accountModel);
        string GetInterest(AccountsModel accountModel);
        string GetInterestRateUntil(AccountsModel accountModel);
        string GetLenderPlacedInsuranceMessage(AccountsModel accountModel);
        string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel, bool isCoborrower = false);
        string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel, bool isCoborrower = false);
        string GetMailingCountry(AccountsModel accountsModel, bool isCoBorrower = false);
        string GetMiscellaneous(AccountsModel accountModel);
        string GetPartialClaim(AccountsModel accountModel);
        string GetPastUnpaidAmount(AccountsModel accountsModel);
        string GetPaymentAmount(AccountsModel accountsModel);
        string GetPaymentInformationMessage(AccountsModel accountsModel);
        string GetPOBoxAddress(AccountsModel accountModel);
        string GetPostPetitonPastDueMessage(AccountsModel accountModel);
        string GetPrepaymentPenalty(AccountsModel accountModel);
        string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel, bool isCoborrower = false);
        string GetPrincipal(AccountsModel accountsModel);
        string GetPrintStatement(AccountsModel accountModel);
        string GetRegularMonthlyPayment(AccountsModel accountModel);
        string GetSecondaryBorrower(AccountsModel accountModel);
        string GetStateDisclosures(AccountsModel accountModel);
        string GetStateNSF(AccountsModel accountModel);
        string GetSuspense(AccountsModel accountModel);
        decimal GetTotalFeesPaid(AccountsModel accountsModel);
        string GetTotalPaidLastMonth(AccountsModel accountsModel);
        string GetTotalPaidYearToDate(AccountsModel accountModel);
        string GetTotalPaymentAmount(AccountsModel accountsModel);
        string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel);
        string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel);
    }
}