using HelocService.Models.InputCopyBookModels;

namespace HelocService.Calculation_Classes
{
    public interface IRejectStatement
    {
        bool IsRejectAccount(AccountsModel accountModel);
    }
}