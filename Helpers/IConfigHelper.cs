using HelocService.Models;

namespace HelocService.Helpers
{
    public interface IConfigHelper
    {
        ConfigModel Model
        {
            get;
            set;
        }
        ConfigModel GetConfigModel();

    }
}
