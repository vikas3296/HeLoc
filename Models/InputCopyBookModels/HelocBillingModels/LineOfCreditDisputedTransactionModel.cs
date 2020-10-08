using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarringtonMortgage.Models.InputCopyBookModels.HelocBillingModels
{
    class LineOfCreditDisputedTransactionModel
    {
        public string B650_Rcd_Id { get; set; }
        public string B650_Inst { get; set; }
        public string B650_Acct_No { get; set; }
        public string B650_Seq_No { get; set; }
        public string B650_Dis_Tran_Nbr_Packeddata { get; set; }
        public string B650_Dis_Tran_Report_Dt_Packeddata { get; set; }
        public string B650_Dis_Tran_Reason { get; set; }
        public string B650_Dis_Tran_Desc { get; set; }
        public string B650_Dis_Tran_Post_Dt_Packeddata { get; set; }
        public string B650_Dis_Tran_Eff_Dt_Packeddata { get; set; }
        public string B650_Dis_Tran_Amt_Packeddata { get; set; }
        public string B650_Dis_Tran_Ref_Id { get; set; }
        public string B650_Dis_Tran_Resolve_Dt_Packeddata { get; set; }
        public string B650_Dis_Tran_Resolved_For { get; set; }
        public string B650_Dis_Tran_Payee_Name { get; set; }
        public string B650_Dis_Tran_Payee_Addr { get; set; }
        public string B650_Dis_Tran_City { get; set; }
        public string B650_Dis_Tran_State { get; set; }
        public string B650_Dis_Tran_Zip { get; set; }
        public string Filler { get; set; }

    }
}
