
namespace HelocService.Helpers
{
    public static class Enums
    {
        [System.Flags]
        public enum LogLevels
        {
            TRACE,
            INFO,
            DEBUG,
            WARNING,
            ERROR,
            FATAL
        }
        public enum FormModes
        {
            Add,
            Edit
        }
        public enum WFStepStaus
        {
            InProgress,
            Completed,
            Error,
        }
        public enum EmailStatus
        {
            New,
            Error,
            Delivered,
            Undelivered,
            Bounced
        }
        public enum ProcessingStatus
        {
            New,
            InProcessing,
            ProcessCompleted
        }
       
    }
}
