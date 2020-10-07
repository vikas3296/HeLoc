using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelocService.Models
{
    public class TransModel
    {
        public string SnapShotDate { get; set; }
        public string FieldDescription { get; set; }
        public string LoanNumber { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionAmount { get; set; }
        public string PrincipalAmount { get; set; }
        public string InterestAmount { get; set; }
        public string EscrowAmount { get; set; }
        public string LateChargeAmount { get; set; }
    }
}
