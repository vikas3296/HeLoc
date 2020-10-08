using System;

namespace Heloc.Helpers
{
    public interface ILogger
    {
        void Debug(string text);

        void Error(Exception ex, string methodName);

        void Fatal(string text);

        void Info(string text);

        void Trace(string text);

        void Warning(string text);

        bool WriteLine(string text, bool append = true);

        bool WriteInFile(string fullFilenameWithPath, string text, bool append = true);

        void ExecuteWriteFileOperation(string fullFilenameWithPath, string text, bool append);

        void PrintJob(object data);

        void WriteFormattedLog(Enums.LogLevels level, string text);

        void CreateNewLogFile();
    }
}
