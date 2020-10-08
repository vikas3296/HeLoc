using Heloc.Models;

namespace Heloc.Helpers
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
