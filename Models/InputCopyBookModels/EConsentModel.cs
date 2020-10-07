using System;

namespace HelocService.Models.InputCopyBookModels
{
    public class EConsentModel
    {
        public DateTime FileDate { get; set; }
        public string LoanNumber { get; set; }
        public string DocumentType { get; set; }
        public string EConsentFlag { get; set; }
        public string EConsentDate { get; set; }
        public string EMailAddress { get; set; }
        public string Filler { get; set; }
    }
}
