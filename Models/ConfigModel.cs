
using System.Collections.Generic;

namespace Heloc.Models
{
    public class ConfigModel
    {
        // Logger Congiguration
        public bool IsLoggingEnabled { get; set; }
        public int LoggingFileMaxSizeInMB { get; set; }
        public string LoggingPath { get; set; }
        public bool IsReleaseMode { get; set; }
        public string InputFilePathLocation_Local { get; set; }
        public string OutputFilePathLocation_Local { get; set; }
        public string WatcherStartTime { get; set; }
        public string WatcherEndTime { get; set; }
    }
}
