using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarringtonMortgage.Models.InputCopyBookModels.HelocBillingModels
{
    class LineOfCreditItemizedInitialAdvanceModel
    {
        public string B650_Rcd_Id { get; set; }
        public string B650_Inst { get; set; }
        public string B650_Acct_No { get; set; }
        public string B650_Seq_No { get; set; }
        public string B650_Item_Adv_Occ_No { get; set; }
        public string B650_Item_Adv_Amt_Packeddata { get; set; }
        public string B650_Item_Adv_Eff_Dt_Packeddata { get; set; }
        public string B650_Item_Adv_Check_Nbr { get; set; }
        public string B650_Item_Adv_Desc { get; set; }
        public string Filler { get; set; }

    }
}
