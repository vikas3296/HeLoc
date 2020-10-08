using Heloc.Models;
using System;
using System.Configuration;

namespace Heloc.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public ConfigModel Model;
        public ConfigHelper()
        {
            Model = new ConfigModel
            {
                IsLoggingEnabled = GetSetting<bool>("IsLoggingEnabled"),
                LoggingFileMaxSizeInMB = GetSetting<int>("LoggingFileMaxSizeInMB"),
                LoggingPath = GetSetting<string>("LoggingPath"),
                IsReleaseMode = GetSetting<bool>("IsReleaseMode"),
                InputFilePathLocation_Local = GetSetting<string>("InputFilePathLocation_Local"),
                OutputFilePathLocation_Local = GetSetting<string>("OutFilePathLocation_Local"),
                WatcherStartTime = GetSetting<string>("WatcherStartTime"),
                WatcherEndTime = GetSetting<string>("WatcherEndTime"),
            };
        }

        ConfigModel IConfigHelper.Model
        {
            get => Model;
            set => Model = value;
        }

        public ConfigModel GetConfigModel()
        {
            return Model;
        }

        private T GetSetting<T>(string keys, T defaultValue = default) where T : IConvertible
        {

            string val = ConfigurationManager.AppSettings[keys] ?? "";
            T result = defaultValue;
            if (!string.IsNullOrEmpty(val))
            {
                T typeDefault = default;
                if (typeof(T) == typeof(string))
                {
                    typeDefault = (T)(object)string.Empty;
                }
                result = (T)Convert.ChangeType(val, typeDefault.GetTypeCode());
            }
            return result;
        }
    }
}
