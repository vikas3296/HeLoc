namespace Heloc.Models.InputCopyBookModels.HelocBillingModels
{
    public class MultiLockboxRecordModel
    {
        public string B650_Rcd_Id { get; set; }
        public string B650_Inst { get; set; }
        public string B650_Acct_No { get; set; }
        public string B650_Seq_No { get; set; }
        public string B650_Lkbx_Id_Data { get; set; }
        public string B650_Lkbx_Addr_1 { get; set; }
        public string B650_Lkbx_Addr_2 { get; set; }
        public string B650_Lkbx_City { get; set; }
        public string B650_Lkbx_State { get; set; }
        public string B650_Lkbx_Zip { get; set; }
        public string Filler { get; set; }
    }
}
