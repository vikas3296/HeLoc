﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class OptionalItemEscrowRecord
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string ProductName { get; set; }

        public string MonthlyAmount { get; set; }

        public string PendingAmount { get; set; }

        public string PendingDate { get; set; }
        public string EscrowType { get; set; }
        public string EscrowLineUncollectedOptIns { get; set; }
        public string Filler { get; set; }

    }
}
