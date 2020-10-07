using System;
using System.Collections.Generic;

namespace HelocService.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class MortgageLoanBillingFileModel
    {
        public MortgageLoanBillingFileModel()
        {
            HeaderRecords = new HeaderRecordModel();
            InstitutionRecords = new InstitutionRecordModel();
            AccountModelList = new List<AccountsModel>();
        }
        public HeaderRecordModel HeaderRecords { get; set; }
        public InstitutionRecordModel InstitutionRecords { get; set; }
        public List<AccountsModel> AccountModelList { get; set; }

        public string InputFileName { get; set; }
        public long InputFileSize { get; set; }
        public DateTime InputFileDate { get; set; }

        public int TotalNumberOfAccount { get; set; }
        public string TrackingId { get; set; }

    }
}
