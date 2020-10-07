using HelocService.Models.InputCopyBookModels.MortgageLoanBillingModels;

namespace HelocService.BusinessExpert
{
    public interface ICRL30FileGeneration
    {
        void GenerateCRL30File(MortgageLoanBillingFileModel mortgageLoanBillingFileModel, string inputFile);
    }
}