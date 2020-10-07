namespace HelocService.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class LateChargeDetailRecordModel
    {
        public string Rssi_Rcd_Id { get; set; }
        public string Rssi_Inst { get; set; }
        public string Rssi_Acct_No { get; set; }
        public string Rssi_Seq_No { get; set; }
        public string Rssi_Lcd_Pymt_Due_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Due_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Calc_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Amt_For_Lc_Due_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Pd_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Factor_PackedData { get; set; }
        public string Rssi_Lcd_Calc_Meth { get; set; }
        public string Rssi_Lcd_Waiver_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Waiver_Cd { get; set; }
        public string Rssi_Lcd_Rev_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Paid_Amt { get; set; }
        public string Rssi_Lcd_Waive_Amt { get; set; }
        public string Rssi_Lcd_Rev_Amt { get; set; }
        public string Rssi_Lcd_Lc_Adj_Dt_PackedData { get; set; }
        public string Rssi_Lcd_Lc_Adj_Amt_PackedData { get; set; }

        public string Rssi_Lcd_Rem_Bal_PackedData { get; set; }
        public string Filler { get; set; }

    }
}
