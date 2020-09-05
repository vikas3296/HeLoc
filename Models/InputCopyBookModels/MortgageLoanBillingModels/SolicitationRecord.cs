﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class SolicitationRecord
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string LoanSolicitationCampaignId { get; set; }
        public string LoanSolicitationCampaignControl { get; set; }
        public string LoanSolicitationCampaignMethod { get; set; }

    }
}
