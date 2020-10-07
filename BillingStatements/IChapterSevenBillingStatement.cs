using HelocService.Models.InputCopyBookModels;
using System.Text;

namespace HelocService.BillingStatements
{
    public interface IChapterSevenBillingStatement
    {
        string DeferredBalance { get; set; }
        string ExMessage { get; set; }
        string FeesAndChargesPaidLastMonth { get; set; }
        string FeesAndChargesPaidYeartoDate { get; set; }
        string Miscellaneous { get; set; }
        string PastUnpaidAmount { get; set; }
        string PaymentAmount { get; set; }
        string Principal { get; set; }
        string Suspense { get; set; }
        string TotalDue { get; set; }
        string TotalFeesandCharges { get; set; }
        decimal TotalFeesPaid { get; set; }
        string TotalPaidLastMonth { get; set; }
        string TotalPaidYearToDate { get; set; }
        string TotalPaymentAmount { get; set; }
        string UnappliedFundsPaidLastMonth { get; set; }
        string UnappliedFundsPaidYearToDate { get; set; }

        string GetAccountHistoryInformationbox(AccountsModel accountModel);
        string GetAmount(AccountsModel accountModel);
        string GetAutodraftMessage(AccountsModel accountModel);
        //string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountModel);
        string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower=false);
        string GetBuydownBalance(AccountsModel accountModel);
        string GetCarringtonCharitableFoundation(AccountsModel accountModel);
        //string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountModel);
        string GetCarringtonCharitableFoundationDonationPaidLastMonh(AccountsModel accountModel);
        string GetCarringtonCharitableFoundationDonationPaidYearToDate(AccountsModel accountModel);
        string GetCMSPartialClaim(AccountsModel accountModel);
        string GetDeferredBalance(AccountsModel accountModel);
        string Geteffectivedate(AccountsModel accountModel);
        string GetEscrowTaxesandInsurance(AccountsModel accountModel);
        string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel);
        string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel);
       // StringBuilder GetFinalChapterSevenBillingStatement(AccountsModel accountModel);
        StringBuilder GetFinalChapterSevenBillingStatement(AccountsModel accountModel, bool isCoborrower = false);
        string GetHUDPartialClaim(AccountsModel accountModel);
        string GetInterest(AccountsModel accountModel);
        string GetInterestRateUntil(AccountsModel accountModel);
        string GetLenderPlacedInsuranceMessage(AccountsModel accountModel);
        //string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel);
        string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel, bool isCoborrower = false);
        //string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel);
        string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel, bool isCoborrower = false);
        //string GetMailingCountry(AccountsModel accountModel);
        string GetMailingCountry(AccountsModel accountsModel, bool isCoBorrower=false);
        string GetMiscellaneous(AccountsModel accountModel);
        string GetPartialClaim(AccountsModel accountModel);
        string GetPastUnpaidAmount(AccountsModel accountModel);
        string GetPaymentAmount(AccountsModel accountModel);
        string GetPaymentDate(AccountsModel accountsModel);
        string GetPaymentInformationMessage(AccountsModel accountModel);
        string GetPOBoxAddress(AccountsModel accountModel);
        string GetPrepaymentPenalty(AccountsModel accountModel);
       // string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel);
        string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel, bool isCoborrower = false);
        string GetPrincipal(AccountsModel accountModel);
        string GetPrintStatement(AccountsModel accountModel);
        string GetRecentPayment1(AccountsModel accountModel);
        string GetRecentPayment2(AccountsModel accountModel);
        string GetRecentPayment3(AccountsModel accountModel);
        string GetRecentPayment4(AccountsModel accountModel);
        string GetRecentPayment5(AccountsModel accountModel);
        string GetRecentPayment6(AccountsModel accountModel);
        string GetRegularMonthlyPayment(AccountsModel accountModel);
        string GetSecondaryBorrower(AccountsModel accountModel);
        string GetStateDisclosures(AccountsModel accountModel);
        string GetStateNSF(AccountsModel accountModel);
        string GetSuspense(AccountsModel accountModel);
        string GetTotalDue(AccountsModel accountModel);
        string GetTotalFeesandCharges(AccountsModel accountModel);
        decimal GetTotalFeesPaid(AccountsModel accountModel);
        string GetTotalPaidLastMonth(AccountsModel accountsModel);
        string GetTotalPaidYearToDate(AccountsModel accountModel);
        string GetTotalPaymentAmount(AccountsModel accountModel);
        string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel);
        string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel);
    }
}