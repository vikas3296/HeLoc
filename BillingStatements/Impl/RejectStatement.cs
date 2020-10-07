using HelocService.Models.InputCopyBookModels;
using HelocService.Helpers;
using System;
using System.Linq;

namespace HelocService.Calculation_Classes
{
    public class RejectStatement : IRejectStatement
    {
        public ILogger Logger;

        public RejectStatement(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// This method check if an account needs to be rejected
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public bool IsRejectAccount(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Executing to check Reject Account.");

                bool isReject = false;

              

                //Rejection condition 1
                if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && (accountModel.ArchivedBankruptcyDetailRecordModel.Any(m=>m.Rssi_K_B_Reaffirm_Dt_PackedData == "00/00/00") || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
                {
                    isReject = true;
                }
                //Rejection condition 2
                else if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
                {
                    isReject = true;
                }
                //Rejection condition 3
                else if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (accountModel.ArchivedBankruptcyDetailRecordModel.Any(m=>m.Rssi_K_B_Reaffirm_Dt_PackedData == "00/00/00") || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
                {
                    isReject = true;
                }
                //Rejection condition 4
                else if ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13")
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "null"))
                {
                    isReject = true;
                }
              //  Logger.Trace("ENDED:   Executed to check Reject Account..");
                return isReject;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return false;
            }
        }
    }
}
