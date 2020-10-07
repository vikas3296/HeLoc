using HelocService.Helpers;
using HelocService.Models;
using HelocService.Models.InputCopyBookModels;
using HelocService.Models.InputCopyBookModels.MortgageLoanBillingModels;
using HelocService.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HelocService.BusinessExpert
{
    public class WorkFlowExpert : IWorkFlowExpert
    {
        #region Class Members Definitions & Constructor 
        public ILogger Logger;
        private readonly IConfigHelper ConfigHelper;
        private string pmFilePath;
        private static string supplimentFilePath;
        private static string EConsentFilePath;
        public FileStream InputFileStream;
        //MortgageLoanBillingFileModel MortgageLoanBillingFile = new MortgageLoanBillingFileModel();
        //CmsBillingInputModel CmsBillInput = new CmsBillingInputModel();
        //EConsentInput EConsentInput = new EConsentInput();
        AccountsModel accountsModel;
       // private readonly ICRL30FileGeneration CRL30FileGeneration;
        /// <summary>The NCP10 version.</summary>
        private const string Ncp10Version = "03";
        //public static List<DetModel> detModels = new List<DetModel>();
        //public static List<TransModel> transModels = new List<TransModel>();
        //public static List<EConsentModel> eConsentModels = new List<EConsentModel>();
        
        //public static List<MultiLocationValueModel> Rssi_Inv_Code_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Past_Date_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Name_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Block_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Pc_Owned_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Rate_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Sv_Code_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Sv_Fee_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Sv_Acct_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Inv_Fill_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Reg_Amt_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Late_Amt_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Past_Date_R_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Reg_Amt_R_PackedData_Model = new List<MultiLocationValueModel>();
        //public static List<MultiLocationValueModel> Rssi_Late_Amt_R_PackedData_Model = new List<MultiLocationValueModel>();


        /// <summary>The delimiter.</summary>
        private const string Delimiter = "|";
        //public WorkFlowExpert(IConfigHelper configHelper, ILogger logger, ICRL30FileGeneration cRL30FileGeneration)
        //{
        //    ConfigHelper = configHelper;
        //    Logger = logger;
        //    CRL30FileGeneration = cRL30FileGeneration;
        //    SetFilePath();
        //    ReadCMSBillInputFileDetRecord(supplimentFilePath);
        //    ReadEConsentRecord(EConsentFilePath);
        //}

        #endregion

        public bool StartWorkFlow(string _inputFile, string _trackingId)
        {
            try
            {
                return FileReadingProcess(_inputFile, _trackingId);

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "");
                return false;
            }

        }
        public bool FileReadingProcess(string inputFile, string trackingId)
        {
            Logger.Trace("STARTED: File Reading Process Started");
            try
            {
                string pathFinal = inputFile;
                string filelocation = pathFinal;
                pmFilePath = inputFile;
                bool fileReadingProcess = false;

                //if (DateTime.Now.Hour >= Convert.ToInt32(ConfigHelper.Model.WatcherStartTime) && DateTime.Now.Hour < Convert.ToInt32(ConfigHelper.Model.WatcherEndTime))
                {
                    //if (Convert.ToString(DateTime.Now.DayOfWeek) != "Monday")
                    {
                        bool isFileMissing = false;
                        if (pmFilePath == null)
                        {
                            Logger.Trace("ERROR: PM File Not Found");
                            isFileMissing = true;
                        }
                        if (supplimentFilePath == null)
                        {
                            Logger.Trace("ERROR: Suppliment  File Not Found");
                            isFileMissing = true;

                            //throw new FileNotFoundException($"Suppliment  File Not Found");
                        }
                        if (EConsentFilePath == null)
                        {
                            Logger.Trace("ERROR: Econsent  File Not Found");
                            isFileMissing = true;

                            //throw new FileNotFoundException($"Econsent  File Not Found");

                        }

                        if (!isFileMissing)
                        {

                            //ReadPMFile(pmFilePath);
                            //if (MortgageLoanBillingFile.AccountModelList.Count > 0)
                            //{
                            //    MortgageLoanBillingFile.TrackingId = trackingId;
                            //    CRL30FileGeneration.GenerateCRL30File(MortgageLoanBillingFile, inputFile);
                            //}
                            //else
                            //{
                            //    Logger.Trace("Trace: Can not Generate CRL30 File. FileReadingProcess: " + fileReadingProcess + "Total Accounts: " + MortgageLoanBillingFile.AccountModelList.Count);
                            //}
                        }
                    }
                    //else
                    //{
                    //    Logger.Trace("SUCCESS: Outside Time Frame Window File Found :-");
                    //    if (pmFilePath != null)
                    //    {
                    //        Logger.Trace("PM File Found at Time =  " + DateTime.Now.ToString());
                    //    }
                    //    if (supplimentFilePath != null)
                    //    {
                    //        Logger.Trace("SUCCESS: Suppliment File Found at Time =  " + DateTime.Now.ToString());
                    //    }
                    //    if (EConsentFilePath != null)
                    //    {
                    //        Logger.Trace("SUCCESS: Econsent File Found at Time =  " + DateTime.Now.ToString());
                    //    }
                    //}
                }
                //else
                //{
                //    Logger.Trace("SUCCESS: Outside Time Frame Window File Found :-");
                //    if (pmFilePath != null)
                //    {
                //        Logger.Trace("PM File Found at Time =  " + DateTime.Now.ToString());
                //    }
                //    if (supplimentFilePath != null)
                //    {
                //        Logger.Trace("SUCCESS: Suppliment File Found at Time =  " + DateTime.Now.ToString());
                //    }
                //    if (EConsentFilePath != null)
                //    {
                //        Logger.Trace("SUCCESS: Econsent File Found at Time =  " + DateTime.Now.ToString());
                //    }
                // }
                // TimeWatch();
                //if (fileReadingProcess)
                //{

                //    Logger.Trace("ENDED: File Reading Process Completed");
                //}
                //else
                //{
                //    Logger.Trace("ENDED: File Reading Process is In-Complete");
                //}
                Logger.Trace("ENDED: File Reading Process Completed");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "File Reading Process Failed :");
                throw new FileNotFoundException($"File Reading Process Failed :");
            }
        }


        #region  Private Methods - Workflow Steps Definitions 

        /// </summary> Step - 1 Execute workflow to send mail alongwith the Campaigning Request./// <summary>
        /// <param name="WFSID"></param>
        /// <param name="clientId"></param>
        /// <param name="batchId"></param>
        /// <returns></returns>
        /// Note:- Don't change method name and parameters.
        //private bool SendCampaignRequest(int WFSID, int clientId, int batchId = 0)
        //{
        //    //Before start of work flow step Insert history
        //    long sessionID = DateTime.Now.Ticks;

        //    try
        //    {
        //        Logger.Trace("STARTED:  Step - 1 Execute workflow to send mail alongwith the Campaigning Request using Send Campaign Request with WFSID =" + WFSID.ToString());

        //        Logger.Trace("ENDED:    Step - 1 Send Campaign Request with WFSID =" + WFSID.ToString());
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Error(ex, ex.TargetSite.Name);
        //        return false;
        //    }
        //}

        //private void TimeWatch()
        //{
        //    //24 hours timer is working perfectly
        //    string path = @"C:\NCP-Carrington\Input";
        //    var DailyTime = "16:36:00";
        //    var timeParts = DailyTime.Split(new char[1] { ':' });

        //    var dateNow = DateTime.Now;
        //    var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
        //               int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
        //    TimeSpan ts;
        //    if (date > dateNow)
        //        ts = date - dateNow;
        //    else
        //    {
        //        date = date.AddDays(1);
        //        ts = date - dateNow;
        //    }
        //    //waits certan time and run the code
        //    Task.Delay(ts).ContinueWith((x) => MonitorDirectory(path));
        //}
        //private void MonitorDirectory(string path)
        //{
        //    FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

        //    fileSystemWatcher.Path = path;

        //    fileSystemWatcher.Created += FileSystemWatcher_Created;

        //    fileSystemWatcher.EnableRaisingEvents = true;

        //}

        //private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        //{
        //    string fileName = e.Name;
        //    Logger.Trace("File created: " + fileName + "");
        //}
        //#endregion       


        //public void ReadPMFile(string fileNameWithPath)
        //{
        //    Logger.Trace("STARTED: Reading PM File");
        //    try
        //    {
        //        int numOfBytes = 4010;
        //        InputFileStream = new System.IO.FileStream(fileNameWithPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);

        //        byte[] currentByteLine = new byte[numOfBytes];


        //        int iBytesRead = InputFileStream.Read(currentByteLine, 0, numOfBytes);
        //        int counter = 0;
        //        int startPos = 0;
        //        int fieldLength = 1;
        //        bool firstRecord = false;
        //        while (iBytesRead > 0)
        //        {
        //            string inputValue = Encoding.Default.GetString(currentByteLine, startPos, fieldLength);
        //            if (counter <= 1)
        //            {
        //                if (inputValue == "H")
        //                {
        //                    GetHeaderRecord(currentByteLine);
        //                }
        //                else if (inputValue == "B")
        //                {
        //                    GetInstitutionRecord(currentByteLine);
        //                }
        //            }
        //            else if (counter > 1)
        //            {
        //                if (inputValue == "P")
        //                {
        //                    GetPL_Record(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "A")
        //                {
        //                    if (firstRecord)
        //                    {
        //                        MortgageLoanBillingFile.AccountModelList.Add(accountsModel);
        //                        SetSupplimentalAndEConsentModel(accountsModel);
        //                        accountsModel = null;
        //                    }
        //                    accountsModel = new AccountsModel();
        //                    firstRecord = true;
        //                    GetMasterFileDataPart_1(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "2")
        //                {
        //                    GetMasterFileDataPart_2(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "U")
        //                {
        //                    GetUserFieldRecord(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "L")
        //                {
        //                    GetMultiLockboxRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "R")
        //                {
        //                    GetRateReductionRecord(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "E")
        //                {
        //                    GetEscrowRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "O")
        //                {
        //                    GetOptionalItemEscrowRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "F")
        //                {
        //                    GetFeeRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "S")
        //                {
        //                    GetSolicitationRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "T")
        //                {
        //                    GetTransactionRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "C")
        //                {
        //                    GetForeignInformationRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "D")
        //                {
        //                    GetBlendedRateInformationRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "I")
        //                {
        //                    GetCoBorrowerRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "<")
        //                {
        //                    GetLateChargeInformationRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "-")
        //                {
        //                    GetLateChargeDetailRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "J")
        //                {
        //                    GetActiveBankruptcyInformationRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "K")
        //                {
        //                    GetArchivedBankruptcyDetailRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "X")
        //                {
        //                    GetEmailAddressRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "3")
        //                {
        //                    GetDisasterTrackingRecordModel(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "4")
        //                {
        //                    GetRHCDRecords(currentByteLine, ref accountsModel);
        //                }
        //                else if (inputValue == "Z")
        //                {
        //                    GetTrailerRecords(currentByteLine, ref accountsModel);
        //                }



        //            }
        //            iBytesRead = InputFileStream.Read(currentByteLine, 0, numOfBytes);
        //            counter++;
        //        }
        //        MortgageLoanBillingFile.AccountModelList.Add(accountsModel);
        //        Logger.Trace("ENDED: Reading PM File");

        //        //Adding File info
        //        MortgageLoanBillingFile.InputFileSize = InputFileStream.Length / 1024;
        //        MortgageLoanBillingFile.InputFileName = Path.GetFileName(fileNameWithPath);
        //        MortgageLoanBillingFile.InputFileDate = File.GetCreationTime(fileNameWithPath);
        //        MortgageLoanBillingFile.TotalNumberOfAccount = MortgageLoanBillingFile.AccountModelList.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "PM File Error :");
        //    }

        //}
        ///// <summary>
        ///// Set Supplimental And EConsent Model Values
        ///// </summary>
        //private void SetSupplimentalAndEConsentModel(AccountsModel model)
        //{
        //    var ytdAmount = detModels.Where(df =>
        //           df.LoanNumber == accountsModel.MasterFileDataPart_1Model.Rssi_Acct_No).FirstOrDefault()?.YTDAmnt;
        //    var priorMoAmnt = detModels.Where(df =>
        //          df.LoanNumber == accountsModel.MasterFileDataPart_1Model.Rssi_Acct_No).FirstOrDefault()?.PriorMoAmnt;
        //    var flagRecordIndicator = detModels.Where(df =>
        //          df.LoanNumber == accountsModel.MasterFileDataPart_1Model.Rssi_Acct_No).FirstOrDefault()?.FlagRecordIndicator;


        //    //Adding values from Supplimental file
        //    model.SupplementalCCFModel = new SupplementalCCFModel
        //    {
        //        YTDAmnt = ytdAmount == "" ? "0" : ytdAmount,
        //        PriorMoAmnt = priorMoAmnt == "" ? "0" : priorMoAmnt,
        //        FlagRecordIndicator = flagRecordIndicator == "" ? "0" : flagRecordIndicator,

        //    };

        //    //Adding values  from eConsent file
        //    model.EConsentModel = new EConsentModel
        //    {
        //        DocumentType = eConsentModels.Where(df =>
        //               df.LoanNumber == accountsModel.MasterFileDataPart_1Model.Rssi_Acct_No).FirstOrDefault()?.DocumentType,
        //        EConsentFlag = eConsentModels.Where(df =>
        //           df.LoanNumber == accountsModel.MasterFileDataPart_1Model.Rssi_Acct_No).FirstOrDefault()?.EConsentFlag

        //    };
        //}

        //private void ReadCMSBillInputFileDetRecord(string path)
        //{
        //    Logger.Trace("STARTED: Reading Suppliment File");
        //    try
        //    {
        //        var fileContents = File.ReadAllLines(path);
        //        var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();


        //        foreach (var line in splitFileContents)
        //        {
        //            if (line[1].ToString() == "DET")
        //            {
        //                CmsBillInput.DetRecord = new DetModel()
        //                {
        //                    SnapShotDate = line[0].ToString(),
        //                    FieldDescription = line[1].ToString(),
        //                    LoanNumber = line[2].ToString(),
        //                    Eligible = line[3].ToString(),
        //                    PriorMoAmnt = line[4].ToString(),
        //                    YTDAmnt = line[5].ToString(),
        //                    SentNO631 = line[6].ToString(),
        //                    FlagRecordIndicator = line[7].ToString(),
        //                    CurrentDate = line[8].ToString(),
        //                    NYOrdinance = line[9].ToString(),
        //                    PriorServicerLoanNumber = line[10].ToString(),
        //                    PrimaryBorrowerName = line[11].ToString(),
        //                    MailingAddressLine1 = line[12].ToString(),
        //                    MailingAddressLine2 = line[13].ToString(),
        //                    MailingAddressCity = line[14].ToString(),
        //                    MailingAddressState = line[15].ToString(),
        //                    MailingAddressZip = line[16].ToString(),
        //                    PropertAddressLine1 = line[17].ToString(),
        //                    PropertyAddressLine2 = line[18].ToString(),
        //                    PropertyAddressCity = line[19].ToString(),
        //                    PropertyAddressState = line[20].ToString(),
        //                    PropertyAddressZip = line[21].ToString(),
        //                    OriginationDate = line[22].ToString(),
        //                    OriginalLoanAmount = line[23].ToString(),
        //                    CurrentPrincipalBalance = line[24].ToString(),
        //                    MaturityDate = line[25].ToString(),
        //                    TotalAmountDue = line[26].ToString(),
        //                    MERSFlag = line[27].ToString(),
        //                    PriorServicerName = line[28].ToString(),
        //                    PriorServicerAddressLine1 = line[29].ToString(),
        //                    PriorServicerAddressLine2 = line[30].ToString(),
        //                    PriorServicerCity = line[31].ToString(),
        //                    PriorServicerState = line[32].ToString(),
        //                    PriorServicerZip = line[33].ToString(),
        //                    PriorServicerPhoneNumber = line[34].ToString(),
        //                    CMSCSHoursofOperation = line[35].ToString(),
        //                    ServiceTransferDate = line[36].ToString(),
        //                    PriorServicerReleaseDate = line[37].ToString(),
        //                    SaleDate = line[38].ToString(),
        //                    InvestorCreditorName = line[39].ToString(),
        //                    TrusteeName = line[40].ToString(),
        //                    TrusteeAddressLine1 = line[41].ToString(),
        //                    TrusteeAddressLine2 = line[42].ToString(),
        //                    TrusteeCity = line[43].ToString(),
        //                    TrusteeState = line[44].ToString(),
        //                    TrusteeZip = line[45].ToString(),
        //                    TrusteePhone = line[46].ToString(),
        //                    CMSCustomerServicePhone = line[47].ToString(),
        //                    SecondaryBorrowerName = line[48].ToString(),
        //                    Originator = line[49].ToString(),
        //                    ACH_Verbiage = line[50].ToString(),
        //                    SecurityPosition = line[51].ToString(),
        //                    OnboardingFlyer = line[52].ToString(),
        //                    TrusteePart1 = line[53].ToString(),
        //                    TrusteePart2 = line[54].ToString(),
        //                    DealName = line[55].ToString(),
        //                    TotalDue = line[56].ToString(),
        //                    LockBoxAddress = line[57].ToString()
        //                };
        //                detModels.Add(CmsBillInput.DetRecord);
        //            }
        //            if (line[1].ToString() == "TRN")
        //            {
        //                CmsBillInput.TransRecord = new TransModel()
        //                {
        //                    SnapShotDate = line[0].ToString(),
        //                    FieldDescription = line[1].ToString(),
        //                    LoanNumber = line[2].ToString(),
        //                    TransactionDate = line[3].ToString(),
        //                    TransactionAmount = line[4].ToString(),
        //                    PrincipalAmount = line[5].ToString(),
        //                    InterestAmount = line[6].ToString(),
        //                    EscrowAmount = line[7].ToString(),
        //                    LateChargeAmount = line[8].ToString()
        //                };
        //                transModels.Add(CmsBillInput.TransRecord);
        //            }

        //        }
        //        Logger.Trace("ENDED: Reading Suppliment File Complete");
        //        //return (detList, transList);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Suppliment File Error");
        //        //return (null, null);
        //    }
        //}

        //private void ReadEConsentRecord(string path)
        //{

        //    Logger.Trace("STARTED: Reading EConsent File");
        //    try
        //    {
        //        var fileContents = File.ReadAllLines(path);
        //        var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();


        //        foreach (var line in splitFileContents)
        //        {
        //            //DateTime date = DateTime.Parse(line[0].ToString());
        //            EConsentInput.EConsentRecord = new EConsentModel()
        //            {
        //                FileDate = Convert.ToDateTime(DateTime.ParseExact(line[0].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture)),
        //                LoanNumber = line[1].ToString(),
        //                DocumentType = line[2].ToString(),
        //                EConsentFlag = line[3].ToString(),
        //                EConsentDate = line[4].ToString(),
        //                EMailAddress = line[5].ToString(),
        //                Filler = line[6].ToString()
        //            };
        //            eConsentModels.Add(EConsentInput.EConsentRecord);
        //        }
        //        Logger.Trace("ENDED: Reading Econsent File Complete");
        //        // return eConsentList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Econsent File Reading Error :");
        //        //return null;
        //    }

        //}


        //#region PM File Mapping

        //// H Header Record. One record per file.
        //public void GetHeaderRecord(byte[] currentByte)
        //{
        //    MortgageLoanBillingFile.HeaderRecords = new HeaderRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_File_Id = PackedTypeCheckAndUnPackData("Rssi_File_Id", currentByte, 20, 24)
        //    };

        //}

        //// B Institution Record.One record per institution.
        //public void GetInstitutionRecord(byte[] currentByte)
        //{
        //    MortgageLoanBillingFile.InstitutionRecords = new InstitutionRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Institution_Name = PackedTypeCheckAndUnPackData("Rssi_Institution_Name", currentByte, 20, 35),
        //        Rssi_Inst_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Inst_Adrs_1", currentByte, 55, 35),

        //        Rssi_Inst_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Inst_Adrs_2", currentByte, 90, 35),
        //        Rssi_Inst_City = PackedTypeCheckAndUnPackData("Rssi_Inst_City", currentByte, 125, 21),

        //        Rssi_Inst_State = PackedTypeCheckAndUnPackData("Rssi_Inst_State", currentByte, 146, 2),
        //        Rssi_Inst_Zip = PackedTypeCheckAndUnPackData("Rssi_Inst_Zip", currentByte, 148, 10),

        //        Rssi_Inst_Phone = PackedTypeCheckAndUnPackData("Rssi_Inst_Phone", currentByte, 158, 10),
        //        Rssi_Alt_Coup_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Adrs_1", currentByte, 168, 35),

        //        Rssi_Alt_Coup_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Adrs_2", currentByte, 203, 35),
        //        Rssi_Alt_Coup_City = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_City", currentByte, 238, 21),

        //        Rssi_Alt_Coup_State = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_State", currentByte, 259, 2),
        //        Rssi_Alt_Coup_Zip = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Zip", currentByte, 261, 10),

        //        Rssi_Alt_Coup_Ph_Desc_1 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_1", currentByte, 271, 20),
        //        Rssi_Alt_Coup_Ph_No_1 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_1", currentByte, 291, 10),

        //        Rssi_Alt_Coup_Ph_Desc_2 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_2", currentByte, 301, 20),
        //        Rssi_Alt_Coup_Ph_No_2 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_2", currentByte, 321, 10),

        //        Rssi_Alt_Coup_Ph_Desc_3 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_3", currentByte, 331, 20),
        //        Rssi_Alt_Coup_Ph_No_3 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_3", currentByte, 351, 10),

        //        Rssi_Alt_Coup_Ph_Desc_4 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_4", currentByte, 361, 20),
        //        Rssi_Alt_Coup_Ph_No_4 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_4", currentByte, 381, 10),

        //        Rssi_Alt_Coup_Ph_Desc_5 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_5", currentByte, 391, 20),
        //        Rssi_Alt_Coup_Ph_No_5 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_5", currentByte, 411, 10),

        //        Rssi_Lock_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Lock_Adrs_1", currentByte, 421, 35),
        //        Rssi_Lock_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Lock_Adrs_2", currentByte, 456, 35),

        //        Rssi_Lock_City = PackedTypeCheckAndUnPackData("Rssi_Lock_City", currentByte, 491, 21),
        //        Rssi_Lock_State = PackedTypeCheckAndUnPackData("Rssi_Lock_State", currentByte, 512, 2),

        //        Rssi_Lock_Zip = PackedTypeCheckAndUnPackData("Rssi_Lock_Zip", currentByte, 514, 10)
        //    };
        //}

        //// P PL$$ Entity Record.One record per Entity within Institution if applicable.
        //public void GetPL_Record(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.PL_RecordModel = new PL_RecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_N1Mx_Plss_Entity = PackedTypeCheckAndUnPackData("Rssi_N1Mx_Plss_Entity", currentByte, 20, 3),
        //        Rssi_Enty_Plss_Group = PackedTypeCheckAndUnPackData("Rssi_Enty_Plss_Group", currentByte, 23, 8),

        //        Rssi_Enty_Status = PackedTypeCheckAndUnPackData("Rssi_Enty_Status", currentByte, 31, 1),
        //        Rssi_Enty_Name = PackedTypeCheckAndUnPackData("Rssi_Enty_Name", currentByte, 32, 35),

        //        Rssi_Enty_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Adrs_1", currentByte, 67, 35),
        //        Rssi_Enty_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Adrs_2", currentByte, 102, 35),

        //        Rssi_Enty_City = PackedTypeCheckAndUnPackData("Rssi_Enty_City", currentByte, 137, 21),
        //        Rssi_Enty_State = PackedTypeCheckAndUnPackData("Rssi_Enty_State", currentByte, 158, 35),

        //        Rssi_Enty_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Zip", currentByte, 193, 10),
        //        Rssi_Enty_Phone = PackedTypeCheckAndUnPackData("Rssi_Enty_Phone", currentByte, 203, 10),

        //        Rssi_Enty_Tax_Id_Number = PackedTypeCheckAndUnPackData("Rssi_Enty_Tax_Id_Number", currentByte, 213, 09),
        //        Rssi_I_Mers_Org_Id = PackedTypeCheckAndUnPackData("Rssi_I_Mers_Org_Id", currentByte, 222, 07),

        //        Rssi_I_Hud_Id = PackedTypeCheckAndUnPackData("Rssi_I_Hud_Id", currentByte, 229, 12),
        //        Rssi_I_Va_Set264_Id = PackedTypeCheckAndUnPackData("Rssi_I_Va_Set264_Id", currentByte, 241, 06),

        //        Rssi_Enty_Rhs_Lender_Number = PackedTypeCheckAndUnPackData("Rssi_Enty_Rhs_Lender_Number", currentByte, 247, 03),
        //        Rssi_Enty_Hud_Cont_Name_First = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Cont_Name_First", currentByte, 250, 10),

        //        Rssi_Enty_Hud_Cont_Name_Last = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Cont_Name_Last", currentByte, 260, 20),
        //        Rssi_Enty_Cont_Phn = PackedTypeCheckAndUnPackData("Rssi_Enty_Cont_Phn", currentByte, 280, 10),

        //        Rssi_Enty_Hud_Office_City = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Office_City", currentByte, 290, 21),
        //        Rssi_Enty_Hud_Office_State = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Office_State", currentByte, 311, 2),

        //        Rssi_Enty_Hud_Office_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Office_Zip", currentByte, 313, 09),
        //        Rssi_Enty_Company_Head_St_Cd = PackedTypeCheckAndUnPackData("Rssi_Enty_Company_Head_St_Cd", currentByte, 322, 03),

        //        Rssi_Enty_Lock_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_Adrs_1", currentByte, 325, 35),
        //        Rssi_Enty_Lock_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_Adrs_2", currentByte, 360, 35),

        //        Rssi_Enty_Lock_City = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_City", currentByte, 395, 21),
        //        Rssi_Enty_Lock_State = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_State", currentByte, 416, 2),

        //        Rssi_Enty_Lock_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_Zip", currentByte, 418, 10),
        //        Rssi_Enty_Alt_Coup_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Adrs_1", currentByte, 428, 35),

        //        Rssi_Enty_Alt_Coup_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Adrs_2", currentByte, 463, 35),
        //        Rssi_Enty_Alt_Coup_City = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_City", currentByte, 498, 21),

        //        Rssi_Enty_Alt_Coup_State = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_State", currentByte, 519, 2),
        //        Rssi_Enty_Alt_Coup_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Zip", currentByte, 521, 10),

        //        Rssi_Enty_Alt_Coup_Ph_Desc_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_1", currentByte, 531, 20),
        //        Rssi_Enty_Alt_Coup_Ph_No_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_1", currentByte, 551, 10),

        //        Rssi_Enty_Alt_Coup_Ph_Desc_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_2", currentByte, 561, 20),
        //        Rssi_Enty_Alt_Coup_Ph_No_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_2", currentByte, 581, 10),

        //        Rssi_Enty_Alt_Coup_Ph_Desc_3 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_3", currentByte, 591, 20),
        //        Rssi_Enty_Alt_Coup_Ph_No_3 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_3", currentByte, 611, 10),

        //        Rssi_Enty_Alt_Coup_Ph_Desc_4 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_4", currentByte, 621, 20),
        //        Rssi_Enty_Alt_Coup_Ph_No_4 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_4", currentByte, 641, 10),

        //        Rssi_Enty_Alt_Coup_Ph_Desc_5 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_5", currentByte, 651, 20),
        //        Rssi_Enty_Alt_Coup_Ph_No_5 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_5", currentByte, 671, 10),
        //    };
        //}

        ////public MultiLocationValueModel GetValueFromMultiLocationModel(string variableName, byte[] currentByte, string acc)
        ////{
        ////    var model = new MultiLocationValueModel();
        ////    model.AccountNo = acc;

        ////    if (variableName == "Rssi_Inv_Code_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 50, 3);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 120, 3);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 190, 3);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 260, 3);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";

        ////    }
        ////    else if (variableName == "Rssi_Inv_Name")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 53, 35);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 123, 35);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 193, 35);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 263, 35);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Inv_Block_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 88, 3);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 158, 3);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 228, 3);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 298, 3);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Inv_Pc_Owned_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 91, 4, 5);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 161, 4, 5);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 231, 4, 5);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 301, 4, 5);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";

        ////    }
        ////    else if (variableName == "Rssi_Inv_Rate_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 95, 4, 5);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 165, 4, 5);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 235, 4, 5);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 305, 4, 5);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";

        ////    }
        ////    else if (variableName == "Rssi_Inv_Sv_Code_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 99, 1);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 169, 1);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 239, 1);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 309, 1);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Inv_Sv_Fee_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 100, 4, 5);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 170, 4, 5);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 240, 4, 5);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 310, 4, 5);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Inv_Sv_Acct")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 104, 15);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 174, 15);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 244, 15);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 314, 15);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Inv_Fill")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 119, 1);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 189, 1);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 259, 1);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 329, 1);
        ////        model.Postion5 = "";
        ////        model.Postion6 = "";
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Past_Date")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 813, 6);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 831, 6);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 849, 6);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 867, 6);
        ////        model.Postion5 = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 885, 6);
        ////        model.Postion6 = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 903, 6);
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Reg_Amt_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 819, 6, 2);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 837, 6, 2);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 855, 6, 2);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 873, 6, 2);
        ////        model.Postion5 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 891, 6, 2);
        ////        model.Postion6 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 909, 6, 2);
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Late_Amt_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 825, 6, 2);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 843, 6, 2);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 861, 6, 2);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 879, 6, 2);
        ////        model.Postion5 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 897, 6, 2);
        ////        model.Postion6 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 915, 6, 2);
        ////        model.Postion7 = "";
        ////        model.Postion8 = "";
        ////        model.Postion9 = "";
        ////        model.Postion10 = "";
        ////        model.Postion11 = "";
        ////        model.Postion12 = "";
        ////        model.Postion13 = "";
        ////        model.Postion14 = "";
        ////        model.Postion15 = "";
        ////        model.Postion16 = "";
        ////        model.Postion17 = "";
        ////        model.Postion18 = "";
        ////        model.Postion19 = "";
        ////        model.Postion20 = "";
        ////        model.Postion21 = "";
        ////        model.Postion22 = "";
        ////    }
        ////    else if (variableName == "Rssi_Past_Date_R")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1791, 6);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1809, 6);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1827, 6);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1845, 6);
        ////        model.Postion5 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1863, 6);
        ////        model.Postion6 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1881, 6);
        ////        model.Postion7 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1899, 6);
        ////        model.Postion8 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1917, 6);
        ////        model.Postion9 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1935, 6);
        ////        model.Postion10 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1953, 6);
        ////        model.Postion11 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1971, 6);
        ////        model.Postion12 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1989, 6);
        ////        model.Postion13 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2007, 6);
        ////        model.Postion14 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2025, 6);
        ////        model.Postion15 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2043, 6);
        ////        model.Postion16 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2061, 6);
        ////        model.Postion17 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2079, 6);
        ////        model.Postion18 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2097, 6);
        ////        model.Postion19 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2115, 6);
        ////        model.Postion20 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2133, 6);
        ////        model.Postion21 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2151, 6);
        ////        model.Postion22 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2169, 6);
        ////    }
        ////    else if (variableName == "Rssi_Reg_Amt_R_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1797, 6, 2);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1815, 6, 2);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1833, 6, 2);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1851, 6, 2);
        ////        model.Postion5 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1869, 6, 2);
        ////        model.Postion6 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1887, 6, 2);
        ////        model.Postion7 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1905, 6, 2);
        ////        model.Postion8 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1923, 6, 2);
        ////        model.Postion9 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1941, 6, 2);
        ////        model.Postion10 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1959, 6, 2);
        ////        model.Postion11 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1977, 6, 2);
        ////        model.Postion12 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1995, 6, 2);
        ////        model.Postion13 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2013, 6, 2);
        ////        model.Postion14 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2031, 6, 2);
        ////        model.Postion15 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2049, 6, 2);
        ////        model.Postion16 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2067, 6, 2);
        ////        model.Postion17 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2085, 6, 2);
        ////        model.Postion18 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2103, 6, 2);
        ////        model.Postion19 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2021, 6, 2);
        ////        model.Postion20 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2139, 6, 2);
        ////        model.Postion21 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2157, 6, 2);
        ////        model.Postion22 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2175, 6, 2);
        ////    }
        ////    else if (variableName == "Rssi_Late_Amt_R_PackedData")
        ////    {
        ////        model.Postion1 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1803, 6, 2);
        ////        model.Postion2 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1821, 6, 2);
        ////        model.Postion3 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1839, 6, 2);
        ////        model.Postion4 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1857, 6, 2);
        ////        model.Postion5 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1875, 6, 2);
        ////        model.Postion6 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1893, 6, 2);
        ////        model.Postion7 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1911, 6, 2);
        ////        model.Postion8 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1929, 6, 2);
        ////        model.Postion9 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1947, 6, 2);
        ////        model.Postion10 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1965, 6, 2);
        ////        model.Postion11 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1983, 6, 2);
        ////        model.Postion12 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2001, 6, 2);
        ////        model.Postion13 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2019, 6, 2);
        ////        model.Postion14 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2037, 6, 2);
        ////        model.Postion15 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2055, 6, 2);
        ////        model.Postion16 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2073, 6, 2);
        ////        model.Postion17 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2091, 6, 2);
        ////        model.Postion18 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2109, 6, 2);
        ////        model.Postion19 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2127, 6, 2);
        ////        model.Postion20 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2145, 6, 2);
        ////        model.Postion21 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2163, 6, 2);
        ////        model.Postion22 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2181, 6, 2);
        ////    }
            

        ////    return model;

           
        ////}
        //// A Master File Data Part 1 Record.One record per loan.


        //public void GetMasterFileDataPart_1(byte[] currentByte, ref AccountsModel acc)
        //{
        //    string accountNo = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10);

        //    Rssi_Inv_Code_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Code_PackedData", currentByte, accountNo));
        //    Rssi_Inv_Name_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Name", currentByte, accountNo));
        //    Rssi_Inv_Block_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Block_PackedData", currentByte, accountNo));
           
        //    Rssi_Inv_Pc_Owned_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Pc_Owned_PackedData", currentByte, accountNo));
        //    Rssi_Inv_Rate_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Rate_PackedData", currentByte, accountNo));
        //    Rssi_Inv_Sv_Code_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Sv_Code_PackedData", currentByte, accountNo));
            
        //    Rssi_Inv_Sv_Fee_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Sv_Fee_PackedData", currentByte, accountNo));
        //    Rssi_Inv_Sv_Acct_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Sv_Acct", currentByte, accountNo));
        //    Rssi_Inv_Fill_Model.Add(GetValueFromMultiLocationModel("Rssi_Inv_Fill", currentByte, accountNo));
            
        //    Rssi_Past_Date_Model.Add(GetValueFromMultiLocationModel("Rssi_Past_Date", currentByte, accountNo));
        //    Rssi_Reg_Amt_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Reg_Amt_PackedData", currentByte, accountNo));
        //    Rssi_Late_Amt_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Late_Amt_PackedData", currentByte, accountNo));
            
        //    Rssi_Past_Date_R_Model.Add(GetValueFromMultiLocationModel("Rssi_Past_Date_R", currentByte, accountNo));
        //    Rssi_Reg_Amt_R_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Reg_Amt_R_PackedData", currentByte, accountNo));
        //    Rssi_Late_Amt_R_PackedData_Model.Add(GetValueFromMultiLocationModel("Rssi_Late_Amt_R_PackedData", currentByte, accountNo));


        //    string Rssi_Inv_Code_PackedData = GetValueFromMultiLocation("Rssi_Inv_Code_PackedData", currentByte);
        //    string Rssi_Inv_Name = GetValueFromMultiLocation("Rssi_Inv_Name", currentByte);
        //    string Rssi_Inv_Block_PackedData = GetValueFromMultiLocation("Rssi_Inv_Block_PackedData", currentByte);
        //    string Rssi_Inv_Pc_Owned_PackedData = GetValueFromMultiLocation("Rssi_Inv_Pc_Owned_PackedData", currentByte);
        //    string Rssi_Inv_Rate_PackedData = GetValueFromMultiLocation("Rssi_Inv_Rate_PackedData", currentByte);
        //    string Rssi_Inv_Sv_Code_PackedData = GetValueFromMultiLocation("Rssi_Inv_Sv_Code_PackedData", currentByte);
        //    string Rssi_Inv_Sv_Fee_PackedData = GetValueFromMultiLocation("Rssi_Inv_Sv_Fee_PackedData", currentByte);
        //    string Rssi_Inv_Sv_Acct = GetValueFromMultiLocation("Rssi_Inv_Sv_Acct", currentByte);
        //    string Rssi_Inv_Fill = GetValueFromMultiLocation("Rssi_Inv_Fill", currentByte);
        //    string Rssi_Past_Date = GetValueFromMultiLocation("Rssi_Past_Date", currentByte);
        //    string Rssi_Reg_Amt_PackedData = GetValueFromMultiLocation("Rssi_Reg_Amt_PackedData", currentByte);
        //    string Rssi_Late_Amt_PackedData = GetValueFromMultiLocation("Rssi_Late_Amt_PackedData", currentByte);
        //    string Rssi_Past_Date_R = GetValueFromMultiLocation("Rssi_Past_Date_R", currentByte);
        //    string Rssi_Reg_Amt_R_PackedData = GetValueFromMultiLocation("Rssi_Reg_Amt_R_PackedData", currentByte);
        //    string Rssi_Late_Amt_R_PackedData = GetValueFromMultiLocation("Rssi_Late_Amt_R_PackedData", currentByte);


        //    acc.MasterFileDataPart_1Model = new MasterFileDataPart_1Model()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Cr_Ins_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cr_Ins_Pymt_PackedData", currentByte, 20, 4, 2),
        //        Rssi_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prin_Bal_PackedData", currentByte, 24, 6, 2),

        //        Rssi_Esc_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Bal_PackedData", currentByte, 30, 6, 2),
        //        Rssi_Ln_Type_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ln_Type_PackedData", currentByte, 36, 1),

        //        Rssi_Sub_Type_PackedData = PackedTypeCheckAndUnPackData("Rssi_Sub_Type_PackedData", currentByte, 37, 1),
        //        Rssi_P_I_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_P_I_Pymt_PackedData", currentByte, 38, 6, 2),

        //        Rssi_Esc_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Pymt_PackedData", currentByte, 44, 5, 2),
        //        Rssi_Inv_Own_Cd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Own_Cd_PackedData", currentByte, 49, 1),

        //        Rssi_Inv_All = PackedTypeCheckAndUnPackData("Rssi_Inv_All", currentByte, 50, 280),
        //        Rssi_Inv_Code_PackedData = Rssi_Inv_Code_PackedData,

        //        Rssi_Inv_Name = Rssi_Inv_Name,
        //        Rssi_Inv_Block_PackedData = Rssi_Inv_Block_PackedData,

        //        Rssi_Inv_Pc_Owned_PackedData = Rssi_Inv_Pc_Owned_PackedData,
        //        Rssi_Inv_Rate_PackedData = Rssi_Inv_Rate_PackedData,

        //        Rssi_Inv_Sv_Code_PackedData = Rssi_Inv_Sv_Code_PackedData,
        //        Rssi_Inv_Sv_Fee_PackedData = Rssi_Inv_Sv_Fee_PackedData,

        //        Rssi_Inv_Sv_Acct = Rssi_Inv_Sv_Acct,
        //        Rssi_Inv_Fill = Rssi_Inv_Fill,

        //        Rssi_Lip_La_Date = PackedTypeCheckAndUnPackData("Rssi_Lip_La_Date", currentByte, 330, 6),
        //        Rssi_Pre_Int_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pre_Int_Amt_PackedData", currentByte, 336, 6, 2),

        //        Rssi_Esc_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Var_PackedData", currentByte, 342, 6, 2),
        //        Rssi_Prop_Cd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prop_Cd_PackedData", currentByte, 348, 2),

        //        Rssi_Int_Pd_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Pd_Ytd_PackedData", currentByte, 350, 6, 2),
        //        Rssi_Pur_Code_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pur_Code_PackedData", currentByte, 356, 2),

        //        Rssi_Unap_Fund_Cd = PackedTypeCheckAndUnPackData("Rssi_Unap_Fund_Cd", currentByte, 358, 1),
        //        Rssi_State_PackedData = PackedTypeCheckAndUnPackData("Rssi_State_PackedData", currentByte, 359, 2),

        //        Rssi_Due_Date = PackedTypeCheckAndUnPackData("Rssi_Due_Date", currentByte, 361, 6),
        //        Rssi_Pymts_Due_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pymts_Due_Amt_PackedData", currentByte, 367, 7, 2),

        //        Rssi_Pymts_Due_Ctr_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pymts_Due_Ctr_PackedData", currentByte, 374, 2),
        //        Rssi_Late_Chg_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Chg_Amt_PackedData", currentByte, 376, 4, 2),

        //        Rssi_Late_Chg_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Chg_Due_PackedData", currentByte, 380, 4, 2),
        //        Rssi_Prepaid_Flag = PackedTypeCheckAndUnPackData("Rssi_Prepaid_Flag", currentByte, 384, 1),

        //        Rssi_Esc_Int_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Int_Ytd_PackedData", currentByte, 385, 4, 2),
        //        Rssi_Run_Date = PackedTypeCheckAndUnPackData("Rssi_Run_Date", currentByte, 389, 6),

        //        Rssi_Primary_Name = PackedTypeCheckAndUnPackData("Rssi_Primary_Name", currentByte, 395, 35),
        //        Rssi_Secondary_Name = PackedTypeCheckAndUnPackData("Rssi_Secondary_Name", currentByte, 430, 35),

        //        Rssi_Mail_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Mail_Adrs_1", currentByte, 465, 35),
        //        Rssi_Mail_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Mail_Adrs_2", currentByte, 500, 35),
        //        Rssi_Mail_Adrs_3 = PackedTypeCheckAndUnPackData("Rssi_Mail_Adrs_3", currentByte, 535, 35),

        //        Rssi_Appl_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Appl_Adrs_1", currentByte, 570, 35),
        //        Rssi_Appl_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Appl_Adrs_2", currentByte, 605, 35),
        //        Rssi_Appl_Adrs_3 = PackedTypeCheckAndUnPackData("Rssi_Appl_Adrs_3", currentByte, 640, 35),

        //        Rssi_Bill_Pmt_Dte = PackedTypeCheckAndUnPackData("Rssi_Bill_Pmt_Dte", currentByte, 675, 6),
        //        Rssi_Bill_Pmt_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Pmt_Amt_PackedData", currentByte, 681, 6, 2),

        //        Rssi_Branch_PackedData = PackedTypeCheckAndUnPackData("Rssi_Branch_PackedData", currentByte, 687, 3),
        //        Rssi_Bill_Total_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Total_Due_PackedData", currentByte, 690, 7, 2),

        //        Rssi_Bill_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Lc_PackedData", currentByte, 697, 5, 2),
        //        Rssi_Pymt_Cyc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pymt_Cyc_PackedData", currentByte, 702, 1),

        //        Rssi_W_Flag_PackedData = PackedTypeCheckAndUnPackData("Rssi_W_Flag_PackedData", currentByte, 703, 1),
        //        Rssi_Dist_Mail_Cd = PackedTypeCheckAndUnPackData("Rssi_Dist_Mail_Cd", currentByte, 704, 1),

        //        Rssi_Last_Actvty_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Last_Actvty_Dt_PackedData", currentByte, 705, 4),
        //        Rssi_Apr_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Apr_Rate_PackedData", currentByte, 709, 3, 2),

        //        Rssi_Neg_Amort_Taken_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Amort_Taken_PackedData", currentByte, 712, 6, 2),
        //        Rssi_Grace_Days_PackedData = PackedTypeCheckAndUnPackData("Rssi_Grace_Days_PackedData", currentByte, 718, 2),

        //        Rssi_Taxpd_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Taxpd_Ytd_PackedData", currentByte, 720, 5, 2),
        //        Rssi_Pd_To_Date = PackedTypeCheckAndUnPackData("Rssi_Pd_To_Date", currentByte, 725, 6),

        //        Rssi_Cur_Due_Dte = PackedTypeCheckAndUnPackData("Rssi_Cur_Due_Dte", currentByte, 731, 6),
        //        Rssi_Prn_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prn_Var_PackedData", currentByte, 737, 6, 2),

        //        Rssi_Uncol_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Uncol_Int_PackedData", currentByte, 743, 6, 2),
        //        Rssi_Note_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Note_Rate_PackedData", currentByte, 749, 4, 5),

        //        Rssi_Neg_Am_Ass_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Am_Ass_Ytd_PackedData", currentByte, 753, 5, 2),
        //        Rssi_Neg_Am_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Am_Paid_Ytd_PackedData", currentByte, 758, 5, 2),

        //        Rssi_Rate_Ov_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rate_Ov_PackedData", currentByte, 763, 4, 5),
        //        Rssi_Org_Rate_Ov_PackedData = PackedTypeCheckAndUnPackData("Rssi_Org_Rate_Ov_PackedData", currentByte, 767, 4, 5),

        //        Rssi_Bill_Number_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Number_PackedData", currentByte, 771, 9),
        //        Rssi_Bank_Trans_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bank_Trans_PackedData", currentByte, 780, 5),

        //        Rssi_Withhold_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Withhold_Ytd_PackedData", currentByte, 785, 4, 2),
        //        Rssi_Neg_Amort_Flag_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Amort_Flag_PackedData", currentByte, 789, 1),

        //        Rssi_Int_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Due_PackedData", currentByte, 790, 6, 2),
        //        Rssi_Sec_Mort_Cd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Sec_Mort_Cd_PackedData", currentByte, 796, 1),

        //        Rssi_2Nd_Acct_No_PackedData = PackedTypeCheckAndUnPackData("Rssi_2Nd_Acct_No_PackedData", currentByte, 797, 6),
        //        Rssi_2Nd_Bill_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_2Nd_Bill_Amt_PackedData", currentByte, 803, 6, 2),

        //        Rssi_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_PackedData", currentByte, 809, 4, 2),
        //        Rssi_Past_Payments = PackedTypeCheckAndUnPackData("Rssi_Past_Payments", currentByte, 813, 108),

        //        Rssi_Past_Date = Rssi_Past_Date,
        //        Rssi_Reg_Amt_PackedData = Rssi_Reg_Amt_PackedData,

        //        Rssi_Late_Amt_PackedData = Rssi_Late_Amt_PackedData,
        //        Rssi_Billing_Opt = PackedTypeCheckAndUnPackData("Rssi_Billing_Opt", currentByte, 921, 1),

        //        Rssi_Alt_Ov_Un_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Ov_Un_PackedData", currentByte, 922, 4, 5),
        //        Rssi_Indx_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Indx_Dt_PackedData", currentByte, 926, 4),

        //        Rssi_Curr_Indx_PackedData = PackedTypeCheckAndUnPackData("Rssi_Curr_Indx_PackedData", currentByte, 930, 4, 5),
        //        Rssi_Mkt_Ov_Un_PackedData = PackedTypeCheckAndUnPackData("Rssi_Mkt_Ov_Un_PackedData", currentByte, 934, 4, 5),

        //        Rssi_Int_Pmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Pmt_PackedData", currentByte, 938, 6, 2),
        //        Rssi_Amort_Pmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Amort_Pmt_PackedData", currentByte, 944, 6, 2),

        //        Rssi_Bill_Method_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Method_PackedData", currentByte, 950, 1),
        //        Rssi_Ach_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Ach_Acct_No", currentByte, 951, 20),

        //        Rssi_Anl_Indx_Rte_PackedData = PackedTypeCheckAndUnPackData("Rssi_Anl_Indx_Rte_PackedData", currentByte, 971, 4, 5),
        //        Rssi_Int_Meth_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Meth_PackedData", currentByte, 975, 2),

        //        Rssi_Cross_Sell_Flag = PackedTypeCheckAndUnPackData("Rssi_Cross_Sell_Flag", currentByte, 977, 1),
        //        Rssi_Mult_Loan_Flag = PackedTypeCheckAndUnPackData("Rssi_Mult_Loan_Flag", currentByte, 978, 1),

        //        Rssi_Primary_Social_Fill = PackedTypeCheckAndUnPackData("Rssi_Primary_Social_Fill", currentByte, 979, 1),
        //        Rssi_Primary_Social_Sec = PackedTypeCheckAndUnPackData("Rssi_Primary_Social_Sec", currentByte, 980, 4),

        //        Rssi_Repay_Amt_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Repy_Plan_Due_Date_PackedData", currentByte, 984, 6, 2),
        //        Rssi_Amort_Fee_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Amort_Fee_Pymt_PackedData", currentByte, 990, 5, 2),

        //        Rssi_Repy_Plan_Due_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Repay_Amt_Due_PackedData", currentByte, 995, 4),
        //        Rssi_Repy_Remain_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Repy_Remain_Bal_PackedData", currentByte, 999, 6, 2),

        //        Rssi_Email_Bill_Ind = PackedTypeCheckAndUnPackData("Rssi_Email_Bill_Ind", currentByte, 1005, 1),
        //        Rssi_Primary_Email_Adr = PackedTypeCheckAndUnPackData("Rssi_Primary_Email_Adr", currentByte, 1006, 40),

        //        Rssi_Primary_Fax_Phone_PackedData = PackedTypeCheckAndUnPackData("Rssi_Primary_Fax_Phone_PackedData", currentByte, 1046, 6),
        //        Rssi_Primary_Cell_Ph_PackedData = PackedTypeCheckAndUnPackData("Rssi_Primary_Cell_Ph_PackedData", currentByte, 1052, 6),

        //        Rssi_Direct_Mail = PackedTypeCheckAndUnPackData("Rssi_Direct_Mail", currentByte, 1058, 2),
        //        Rssi_Telemarket = PackedTypeCheckAndUnPackData("Rssi_Telemarket", currentByte, 1060, 2),

        //        Rssi_Fees_New_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_New_PackedData", currentByte, 1062, 5, 2),
        //        Rssi_Serv_Date = PackedTypeCheckAndUnPackData("Rssi_Serv_Date", currentByte, 1067, 8),

        //        Rssi_First_Stmt_Ind = PackedTypeCheckAndUnPackData("Rssi_First_Stmt_Ind", currentByte, 1075, 1),
        //        Rssi_Mail_Cd = PackedTypeCheckAndUnPackData("Rssi_Mail_Cd", currentByte, 1076, 1),

        //        Rssi_Spec_Stmt_Req = PackedTypeCheckAndUnPackData("Rssi_Spec_Stmt_Req", currentByte, 1077, 1),
        //        Rssi_Stop_1 = PackedTypeCheckAndUnPackData("Rssi_Stop_1", currentByte, 1078, 1),

        //        Rssi_Opt_In_Flag = PackedTypeCheckAndUnPackData("Rssi_Opt_In_Flag", currentByte, 1079, 1),
        //        Rssi_Opt_Out_Flag = PackedTypeCheckAndUnPackData("Rssi_Opt_Out_Flag", currentByte, 1080, 1),

        //        Rssi_Ml_Scnd_Email_Bill_Ind = PackedTypeCheckAndUnPackData("Rssi_Ml_Scnd_Email_Bill_Ind", currentByte, 1081, 1),
        //        Rssi_First_Due_Dt = PackedTypeCheckAndUnPackData("Rssi_First_Due_Dt", currentByte, 1082, 8),

        //        Rssi_Mort_Ln_Flg = PackedTypeCheckAndUnPackData("Rssi_Mort_Ln_Flg", currentByte, 1090, 1),
        //        Rssi_Purch_From_Name = PackedTypeCheckAndUnPackData("Rssi_Purch_From_Name", currentByte, 1091, 34),

        //        Rssi_Uncoll_Nsf_Fees = PackedTypeCheckAndUnPackData("Rssi_Uncoll_Nsf_Fees", currentByte, 1125, 7, 2),
        //        Rssi_Uncoll_Ext_Fees = PackedTypeCheckAndUnPackData("Rssi_Uncoll_Ext_Fees", currentByte, 1132, 7, 2),

        //        Rssi_Prim_Home_Ph = PackedTypeCheckAndUnPackData("Rssi_Prim_Home_Ph", currentByte, 1139, 11),
        //        Rssi_V_Tax_Id = PackedTypeCheckAndUnPackData("Rssi_V_Tax_Id", currentByte, 1150, 11),

        //        Rssi_F_O_Flag_1 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_1", currentByte, 1161, 1),
        //        Rssi_F_O_Flag_2 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_2", currentByte, 1162, 1),

        //        Rssi_F_O_Flag_3 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_3", currentByte, 1163, 1),
        //        Rssi_F_O_Flag_4 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_4", currentByte, 1164, 1),

        //        Rssi_F_O_Flag_5 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_5", currentByte, 1165, 1),
        //        Rssi_Scnd_Social_Fill = PackedTypeCheckAndUnPackData("Rssi_Scnd_Social_Fill", currentByte, 1166, 5),

        //        Rssi_Scnd_Social_Sec = PackedTypeCheckAndUnPackData("Rssi_Scnd_Social_Sec", currentByte, 1171, 4),
        //        Rssi_Origin_Date = PackedTypeCheckAndUnPackData("Rssi_Origin_Date", currentByte, 1175, 8),

        //        Rssi_Int_Start_Dt = PackedTypeCheckAndUnPackData("Rssi_Int_Start_Dt", currentByte, 1183, 8),
        //        Rssi_Term_Clos = PackedTypeCheckAndUnPackData("Rssi_Term_Clos", currentByte, 1191, 3),

        //        Rssi_Couns_Cd = PackedTypeCheckAndUnPackData("Rssi_Couns_Cd", currentByte, 1194, 5),
        //        Rssi_Updated_Term = PackedTypeCheckAndUnPackData("Rssi_Updated_Term", currentByte, 1199, 3),

        //        Rssi_Modify_Date = PackedTypeCheckAndUnPackData("Rssi_Modify_Date", currentByte, 1202, 8),
        //        Rssi_Var_Rate = PackedTypeCheckAndUnPackData("Rssi_Var_Rate", currentByte, 1210, 1),

        //        Rssi_Name_Chg_Ind = PackedTypeCheckAndUnPackData("Rssi_Name_Chg_Ind", currentByte, 1211, 1),
        //        Rssi_Addr_Chg_Ind = PackedTypeCheckAndUnPackData("Rssi_Addr_Chg_Ind", currentByte, 1212, 1),

        //        Rssi_Balloon_Date = PackedTypeCheckAndUnPackData("Rssi_Balloon_Date", currentByte, 1213, 8),
        //        Rssi_Times_Delq_30 = PackedTypeCheckAndUnPackData("Rssi_Times_Delq_30", currentByte, 1221, 3),

        //        Rssi_Times_Delq_60 = PackedTypeCheckAndUnPackData("Rssi_Times_Delq_60", currentByte, 1224, 3),
        //        Rssi_Times_Delq_90 = PackedTypeCheckAndUnPackData("Rssi_Times_Delq_90", currentByte, 1227, 3),

        //        Rssi_Nsf_Tl_Ctr = PackedTypeCheckAndUnPackData("Rssi_Nsf_Tl_Ctr", currentByte, 1230, 3),
        //        Rssi_Dem1_Prim_Birthdt = PackedTypeCheckAndUnPackData("Rssi_Dem1_Prim_Birthdt", currentByte, 1233, 8),

        //        Rssi_Dem1_Cb_Score_1 = PackedTypeCheckAndUnPackData("Rssi_Dem1_Cb_Score_1", currentByte, 1241, 15),
        //        Rssi_Dem1_Cb_Score_2 = PackedTypeCheckAndUnPackData("Rssi_Dem1_Cb_Score_2", currentByte, 1256, 15),

        //        Rssi_Dem1_Cb_Score_3 = PackedTypeCheckAndUnPackData("Rssi_Dem1_Cb_Score_3", currentByte, 1271, 15),
        //        Rssi_Ext_Latest_Post_Dt = PackedTypeCheckAndUnPackData("Rssi_Ext_Latest_Post_Dt", currentByte, 1286, 8),

        //        Rssi_Ext_Tot_Act_Ext = PackedTypeCheckAndUnPackData("Rssi_Ext_Tot_Act_Ext", currentByte, 1294, 3),
        //        Rssi_Pre_Note = PackedTypeCheckAndUnPackData("Rssi_Pre_Note", currentByte, 1297, 1),

        //        Rssi_Prim_Work_Ph = PackedTypeCheckAndUnPackData("Rssi_Prim_Work_Ph", currentByte, 1298, 11),
        //        Rssi_Eoyh_Int_Gross = PackedTypeCheckAndUnPackData("Rssi_Eoyh_Int_Gross", currentByte, 1309, 11, 2),

        //        Rssi_Foreclosure_Adv = PackedTypeCheckAndUnPackData("Rssi_Foreclosure_Adv", currentByte, 1320, 7, 2),
        //        Rssi_Net_Investment = PackedTypeCheckAndUnPackData("Rssi_Net_Investment", currentByte, 1327, 11, 2),

        //        Rssi_Orig_Dcnt_Amount = PackedTypeCheckAndUnPackData("Rssi_Orig_Dcnt_Amount", currentByte, 1338, 9, 2),
        //        Rssi_Tot_Pymts_Lol = PackedTypeCheckAndUnPackData("Rssi_Tot_Pymts_Lol", currentByte, 1347, 13, 2),

        //        Rssi_Monthly_Int_Rate = PackedTypeCheckAndUnPackData("Rssi_Monthly_Int_Rate", currentByte, 1360, 7, 5),
        //        Rssi_Num_Days_Delq = PackedTypeCheckAndUnPackData("Rssi_Num_Days_Delq", currentByte, 1367, 5),

        //        Rssi_Optn_Maint_Dt = PackedTypeCheckAndUnPackData("Rssi_Optn_Maint_Dt", currentByte, 1372, 8),
        //        Rssi_Prior_Acnt_Nbr = PackedTypeCheckAndUnPackData("Rssi_Prior_Acnt_Nbr", currentByte, 1380, 20),

        //        Rssi_Last_Pymt_Dt = PackedTypeCheckAndUnPackData("Rssi_Last_Pymt_Dt", currentByte, 1400, 8),
        //        Rssi_Prim_Marital_Stat = PackedTypeCheckAndUnPackData("Rssi_Prim_Marital_Stat", currentByte, 1408, 1),

        //        Rssi_Cls_Cd = PackedTypeCheckAndUnPackData("Rssi_Cls_Cd", currentByte, 1409, 1),
        //        Rssi_Reo_Ind = PackedTypeCheckAndUnPackData("Rssi_Reo_Ind", currentByte, 1410, 1),

        //        Rssi_Mat_Date = PackedTypeCheckAndUnPackData("Rssi_Mat_Date", currentByte, 1411, 8),

        //        Rssi_Lien_3_Pymt_Amt = PackedTypeCheckAndUnPackData("Rssi_Lien_3_Pymt_Amt", currentByte, 1419, 11, 2),

        //        Rssi_L_Flag = PackedTypeCheckAndUnPackData("Rssi_L_Flag", currentByte, 1430, 1),
        //        Rssi_Stop_Code_2 = PackedTypeCheckAndUnPackData("Rssi_Stop_Code_2", currentByte, 1431, 1),

        //        Rssi_Stop_Code_3 = PackedTypeCheckAndUnPackData("Rssi_Stop_Code_3", currentByte, 1432, 1),
        //        Rssi_Fico_Score = PackedTypeCheckAndUnPackData("Rssi_Fico_Score", currentByte, 1433, 5),

        //        Rssi_Nsf_Indicator = PackedTypeCheckAndUnPackData("Rssi_Nsf_Indicator", currentByte, 1438, 1),
        //        Rssi_Empl_Code = PackedTypeCheckAndUnPackData("Rssi_Empl_Code", currentByte, 1439, 1),

        //        Rssi_Audit_Date = PackedTypeCheckAndUnPackData("Rssi_Audit_Date", currentByte, 1440, 8),
        //        Rssi_Prim_Age = PackedTypeCheckAndUnPackData("Rssi_Prim_Age", currentByte, 1448, 3),

        //        Rssi_Scnd_Age = PackedTypeCheckAndUnPackData("Rssi_Scnd_Age", currentByte, 1451, 3),
        //        Rssi_Realtr_Bldr = PackedTypeCheckAndUnPackData("Rssi_Realtr_Bldr", currentByte, 1454, 5),

        //        Rssi_Usr_01_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_01_PackedData", currentByte, 1459, 4),
        //        Rssi_Tot_Fees_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tot_Fees_Due_PackedData", currentByte, 1463, 5, 2),

        //        Rssi_Rd_Status = PackedTypeCheckAndUnPackData("Rssi_Rd_Status", currentByte, 1468, 1),
        //        Rssi_Int_Refi_Code = PackedTypeCheckAndUnPackData("Rssi_Int_Refi_Code", currentByte, 1469, 1),

        //        Rssi_Usr_07 = PackedTypeCheckAndUnPackData("Rssi_Usr_07", currentByte, 1470, 2),
        //        Rssi_Usr_36 = PackedTypeCheckAndUnPackData("Rssi_Usr_36", currentByte, 1472, 1),

        //        Rssi_Ln_Ext_Extend_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ln_Ext_Extend_Int_PackedData", currentByte, 1473, 6, 2),
        //        Rssi_Stmnt_Freq_Type = PackedTypeCheckAndUnPackData("Rssi_Stmnt_Freq_Type", currentByte, 1479, 2),

        //        Rssi_Stmnt_Chg_Dt = PackedTypeCheckAndUnPackData("Rssi_Stmnt_Chg_Dt", currentByte, 1481, 8),
        //        Rssi_Accel_Apds_Part = PackedTypeCheckAndUnPackData("Rssi_Accel_Apds_Part", currentByte, 1489, 1),

        //        Rssi_Accel_Prog_Ind = PackedTypeCheckAndUnPackData("Rssi_Accel_Prog_Ind", currentByte, 1490, 2),
        //        Rssi_Org_Code = PackedTypeCheckAndUnPackData("Rssi_Org_Code", currentByte, 1492, 5),

        //        Rssi_Nimx_Plss_Entity = PackedTypeCheckAndUnPackData("Rssi_Nimx_Plss_Entity", currentByte, 1497, 3),
        //        Rssi_Rate_Chg_Date = PackedTypeCheckAndUnPackData("Rssi_Rate_Chg_Date", currentByte, 1500, 8),

        //        Rssi_Prepay_Pen_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prepay_Pen_Amt_PackedData", currentByte, 1508, 6, 2),
        //        Rssi_Prin_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prin_Paid_Ytd_PackedData", currentByte, 1514, 6, 2),

        //        Rssi_Esc_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Paid_Ytd_PackedData", currentByte, 1520, 6, 2),
        //        Rssi_Fees_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_Paid_Ytd_PackedData", currentByte, 1526, 5, 2),

        //        Rssi_Late_Chg_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Chg_Paid_Ytd_PackedData", currentByte, 1531, 5, 2),
        //        Rssi_Pmt_Due_Date_1 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_1", currentByte, 1536, 6),

        //        Rssi_Pmt_Paid_Date_1 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_1", currentByte, 1542, 6),
        //        Rssi_Pmt_Due_Date_2 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_2", currentByte, 1548, 6),

        //        Rssi_Pmt_Paid_Date_2 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_2", currentByte, 1554, 6),
        //        Rssi_Pmt_Due_Date_3 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_3", currentByte, 1560, 6),

        //        Rssi_Pmt_Paid_Date_3 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_3", currentByte, 1566, 6),
        //        Rssi_Pmt_Due_Date_4 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_4", currentByte, 1572, 6),

        //        Rssi_Pmt_Paid_Date_4 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_4", currentByte, 1578, 6),
        //        Rssi_Pmt_Due_Date_5 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_5", currentByte, 1584, 6),

        //        Rssi_Pmt_Paid_Date_5 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_5", currentByte, 1590, 6),
        //        Rssi_Pmt_Due_Date_6 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_6", currentByte, 1596, 6),

        //        Rssi_Pmt_Paid_Date_6 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_6", currentByte, 1602, 6),
        //        Rssi_Prin_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prin_Pd_Since_Lst_Stmt_PackedData", currentByte, 1608, 7, 2),

        //        Rssi_Int_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Pd_Since_Lst_Stmt_PackedData", currentByte, 1615, 7, 2),
        //        Rssi_Esc_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Pd_Since_Lst_Stmt_PackedData", currentByte, 1622, 7, 2),

        //        Rssi_Lc_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lc_Pd_Since_Lst_Stmt_PackedData", currentByte, 1629, 6, 2),
        //        Rssi_Fees_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_Pd_Since_Lst_Stmt_PackedData", currentByte, 1635, 7, 2),

        //        Rssi_Amt_To_Uaf_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Amt_To_Uaf_Since_Lst_Stmt_PackedData", currentByte, 1642, 6, 2),
        //        Rssi_Tot_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tot_Pd_Since_Lst_Stmt_PackedData", currentByte, 1648, 8, 2),

        //        Rssi_Fees_Assd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_Assd_Since_Lst_Stmt_PackedData", currentByte, 1656, 6, 2),
        //        Rssi_Accr_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accr_Lc_PackedData", currentByte, 1662, 6, 2),

        //        Rssi_Loss_Mit_Ind = PackedTypeCheckAndUnPackData("Rssi_Loss_Mit_Ind", currentByte, 1668, 1),
        //        Rssi_1St_Contact_Name = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Name", currentByte, 1669, 20),

        //        Rssi_1St_Contact_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Adrs_1", currentByte, 1689, 50),
        //        Rssi_1St_Contact_City = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_City", currentByte, 1739, 20),

        //        Rssi_1St_Contact_St = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_St", currentByte, 1759, 2),
        //        Rssi_1St_Contact_Zip = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Zip", currentByte, 1761, 10),

        //        Rssi_1St_Contact_Phone = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Phone", currentByte, 1771, 15),
        //        Rssi_1St_Contact_Ph_Ext = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Ph_Ext", currentByte, 1786, 5),

        //        Rssi_Past_Date_R = Rssi_Past_Date_R,
        //        Rssi_Reg_Amt_R_PackedData = Rssi_Reg_Amt_R_PackedData,
        //        Rssi_Late_Amt_R_PackedData = Rssi_Late_Amt_R_PackedData,

        //        Rssi_Pmt_Due_Date_7 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_7", currentByte, 2187, 6),
        //        Rssi_Pmt_Paid_Date_7 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_7", currentByte, 2193, 6),

        //        Rssi_Pmt_Due_Date_8 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_8", currentByte, 2199, 6),
        //        Rssi_Pmt_Paid_Date_8 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_8", currentByte, 2205, 6),

        //        Rssi_Pmt_Due_Date_9 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_9", currentByte, 2211, 6),
        //        Rssi_Pmt_Paid_Date_9 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_9", currentByte, 2217, 6),

        //        Rssi_Pmt_Due_Date_10 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_10", currentByte, 2223, 6),
        //        Rssi_Pmt_Paid_Date_10 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_10", currentByte, 2229, 6),

        //        Rssi_Pmt_Due_Date_11 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_11", currentByte, 2235, 6),
        //        Rssi_Pmt_Paid_Date_11 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_11", currentByte, 2241, 6),

        //        Rssi_Pmt_Due_Date_12 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_12", currentByte, 2247, 6),
        //        Rssi_Pmt_Paid_Date_12 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_12", currentByte, 2253, 6),

        //        Rssi_Pmt_Due_Date_13 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_13", currentByte, 2259, 6),
        //        Rssi_Pmt_Paid_Date_13 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_13", currentByte, 2265, 6),

        //        Rssi_Pmt_Due_Date_14 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_14", currentByte, 2271, 6),
        //        Rssi_Pmt_Paid_Date_14 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_14", currentByte, 2277, 6),

        //        Rssi_Pmt_Due_Date_15 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_15", currentByte, 2283, 6),
        //        Rssi_Pmt_Paid_Date_15 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_15", currentByte, 2289, 6),

        //        Rssi_Pmt_Due_Date_16 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_16", currentByte, 2295, 6),
        //        Rssi_Pmt_Paid_Date_16 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_16", currentByte, 2301, 6),

        //        Rssi_Pmt_Due_Date_17 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_17", currentByte, 2307, 6),
        //        Rssi_Pmt_Paid_Date_17 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_17", currentByte, 2313, 6),

        //        Rssi_Pmt_Due_Date_18 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_18", currentByte, 2319, 6),
        //        Rssi_Pmt_Paid_Date_18 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_18", currentByte, 2325, 6),

        //        Rssi_Pmt_Due_Date_19 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_19", currentByte, 2331, 6),
        //        Rssi_Pmt_Paid_Date_19 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_19", currentByte, 2337, 6),

        //        Rssi_Pmt_Due_Date_20 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_20", currentByte, 2343, 6),
        //        Rssi_Pmt_Paid_Date_20 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_20", currentByte, 2349, 6),

        //        Rssi_Pmt_Due_Date_21 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_21", currentByte, 2355, 6),
        //        Rssi_Pmt_Paid_Date_21 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_21", currentByte, 2361, 6),

        //        Rssi_Pmt_Due_Date_22 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_22", currentByte, 2367, 6),
        //        Rssi_Pmt_Paid_Date_22 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_22", currentByte, 2373, 6),


        //        Rssi_Pmt_Due_Date_23 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_23", currentByte, 2379, 6),
        //        Rssi_Pmt_Paid_Date_23 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_23", currentByte, 2385, 6),

        //        Rssi_Pmt_Due_Date_24 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_24", currentByte, 2391, 6),
        //        Rssi_Pmt_Paid_Date_24 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_24", currentByte, 2397, 6),

        //        Rssi_Pmt_Due_Date_25 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_25", currentByte, 2403, 6),
        //        Rssi_Pmt_Paid_Date_25 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_25", currentByte, 2409, 6),

        //        Rssi_Pmt_Due_Date_26 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_26", currentByte, 2415, 6),
        //        Rssi_Pmt_Paid_Date_26 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_26", currentByte, 2421, 6),

        //        Rssi_Pmt_Due_Date_27 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_27", currentByte, 2427, 6),
        //        Rssi_Pmt_Paid_Date_27 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_27", currentByte, 2433, 6),

        //        Rssi_Pmt_Due_Date_28 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_28", currentByte, 2439, 6),
        //        Rssi_Pmt_Paid_Date_28 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_28", currentByte, 2445, 6),

        //        Rssi_Cash_Tran_Opt_Out = PackedTypeCheckAndUnPackData("Rssi_Cash_Tran_Opt_Out", currentByte, 2451, 1),
        //        Rssi_Mult_Loan_Ind = PackedTypeCheckAndUnPackData("Rssi_Mult_Loan_Ind", currentByte, 2452, 1),

        //        Rssi_Last_Ann_Stmt_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Last_Ann_Stmt_Dt_PackedData", currentByte, 2453, 4),
        //        Rssi_Last_Ann_Stmt_Meth = PackedTypeCheckAndUnPackData("Rssi_Last_Ann_Stmt_Meth", currentByte, 2457, 2),

        //        Rssi_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Opt_Out_Type", currentByte, 2459, 1),
        //        Rssi_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Opt_Out_Date_PackedData", currentByte, 2460, 4),

        //        Rssi_Special_Contact_Code = PackedTypeCheckAndUnPackData("Rssi_Special_Contact_Code", currentByte, 2464, 5),
        //        Rssi_Last_Dscl_Notice_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Last_Dscl_Notice_Dt_PackedData", currentByte, 2469, 4),

        //        Rssi_Last_Dscl_Notice_Meth = PackedTypeCheckAndUnPackData("Rssi_Last_Dscl_Notice_Meth", currentByte, 2473, 2),
        //        Rssi_Prim_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Prim_Opt_Out_Type", currentByte, 2475, 1),

        //        Rssi_Prim_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prim_Opt_Out_Date_PackedData", currentByte, 2476, 4),
        //        Rssi_Scnd_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Scnd_Opt_Out_Type", currentByte, 2480, 1),
        //        Rssi_Scnd_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Scnd_Opt_Out_Date_PackedData", currentByte, 2481, 4),

        //        Rssi_Cbwr1_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr1_Opt_Out_Type", currentByte, 2485, 1),
        //        Rssi_Cbwr1_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr1_Opt_Out_Date_PackedData", currentByte, 2486, 4),

        //        Rssi_Cbwr2_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr2_Opt_Out_Type", currentByte, 2490, 1),
        //        Rssi_Cbwr2_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr2_Opt_Out_Date_PackedData", currentByte, 2491, 4),

        //        Rssi_Cbwr3_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr3_Opt_Out_Type", currentByte, 2495, 1),
        //        Rssi_Cbwr3_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr3_Opt_Out_Date_PackedData", currentByte, 2496, 4),

        //        Rssi_Cbwr4_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr4_Opt_Out_Type", currentByte, 2500, 1),
        //        Rssi_Cbwr4_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr4_Opt_Out_Date_PackedData", currentByte, 2501, 4),

        //        Rssi_Cbwr5_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr5_Opt_Out_Type", currentByte, 2505, 1),
        //        Rssi_Cbwr5_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr5_Opt_Out_Date_PackedData", currentByte, 2506, 4),

        //        Rssi_Cbwr6_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr6_Opt_Out_Type", currentByte, 2510, 1),
        //        Rssi_Cbwr6_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr6_Opt_Out_Date_PackedData", currentByte, 2511, 4),

        //        Rssi_Cbwr7_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr7_Opt_Out_Type", currentByte, 2515, 1),
        //        Rssi_Cbwr7_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr7_Opt_Out_Date_PackedData", currentByte, 2516, 4),

        //        Rssi_Cbwr8_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr8_Opt_Out_Type", currentByte, 2520, 1),
        //        Rssi_Cbwr8_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr8_Opt_Out_Date_PackedData", currentByte, 2521, 4),

        //        Rssi_Cbwr9_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr9_Opt_Out_Type", currentByte, 2525, 1),
        //        Rssi_Cbwr9_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr9_Opt_Out_Date_PackedData", currentByte, 2526, 4),

        //        Rssi_Cbwr10_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr10_Opt_Out_Type", currentByte, 2530, 1),
        //        Rssi_Cbwr10_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr10_Opt_Out_Date_PackedData", currentByte, 2531, 4),

        //        Rssi_Accelerated_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accelerated_Dt_PackedData", currentByte, 2535, 4),
        //        Rssi_Accelerated_Interest_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accelerated_Interest_Amt_PackedData", currentByte, 2539, 6, 2),

        //        Rssi_Print_Stmt = PackedTypeCheckAndUnPackData("Rssi_Print_Stmt", currentByte, 2545, 1),
        //        Rssi_Part_Pymts_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Part_Pymts_Ytd_PackedData", currentByte, 2546, 5, 2),

        //        Rssi_Closing_Int_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Closing_Int_Ytd_PackedData", currentByte, 2551, 6, 2),
        //        Rssi_Payoff_Amount = PackedTypeCheckAndUnPackData("Rssi_Payoff_Amount", currentByte, 2557, 6, 2),

        //        Rssi_Prim_Attention = PackedTypeCheckAndUnPackData("Rssi_Prim_Attention", currentByte, 2563, 35),
        //        Rssi_Dsi_Accr_Int = PackedTypeCheckAndUnPackData("Rssi_Dsi_Accr_Int", currentByte, 2598, 6, 2),

        //        Rssi_Accelerated_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accelerated_Amt_PackedData", currentByte, 2604, 7, 2),
        //        Rssi_Reinstatement_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Reinstatement_Dt_PackedData", currentByte, 2611, 4),

        //        Rssi_Reinstatement_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Reinstatement_Amt_PackedData", currentByte, 2615, 7, 2),
        //        Rssi_Task605_Comp_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Task605_Comp_Dt_PackedData", currentByte, 2622, 4),

        //        Rssi_Next_Draft_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Next_Draft_Dt_PackedData", currentByte, 2626, 4),
        //        Rssi_Breach_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Breach_Date_PackedData", currentByte, 2630, 4),

        //        Rssi_Chrg_Off_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Chrg_Off_Dt_PackedData", currentByte, 2634, 4),
        //        Rssi_Promise_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Date_PackedData", currentByte, 2638, 4),

        //        Rssi_Promise_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Amt_PackedData", currentByte, 2642, 5, 2),
        //        Rssi_Promise_Broken_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Broken_Dt_PackedData", currentByte, 2647, 4),

        //        Rssi_Promise_Kept_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Kept_Date_PackedData", currentByte, 2651, 4),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 2655, 1356),

        //    };
        //}

        //public string GetValueFromMultiLocation(string variableName, byte[] currentByte)
        //{
        //    string firstPostion, secondPostion, thirdPostion, fourthPostion, fifthPostion, sixPostion,
        //    Postion07, Postion08, Postion09, Postion10, Postion11, Postion12,
        //    Postion13, Postion14, Postion15, Postion16, Postion17, Postion18, Postion19, Postion20, Postion21, Postion22 = "";
        //    if (variableName == "Rssi_Inv_Code_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 50, 3);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 120, 3);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 190, 3);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 260, 3);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";

        //    }
        //    else if (variableName == "Rssi_Inv_Name")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 53, 35);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 123, 35);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 193, 35);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 263, 35);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Inv_Block_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 88, 3);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 158, 3);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 228, 3);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 298, 3);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Inv_Pc_Owned_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 91, 4, 5);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 161, 4, 5);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 231, 4, 5);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 301, 4, 5);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";

        //    }
        //    else if (variableName == "Rssi_Inv_Rate_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 95, 4, 5);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 165, 4, 5);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 235, 4, 5);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 305, 4, 5);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";

        //    }
        //    else if (variableName == "Rssi_Inv_Sv_Code_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 99, 1);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 169, 1);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 239, 1);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 309, 1);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Inv_Sv_Fee_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 100, 4, 5);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 170, 4, 5);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 240, 4, 5);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 310, 4, 5);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Inv_Sv_Acct")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 104, 15);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 174, 15);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 244, 15);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 314, 15);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Inv_Fill")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 119, 1);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 189, 1);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 259, 1);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 329, 1);
        //        fifthPostion = "";
        //        sixPostion = "";
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Past_Date")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 813, 6);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 831, 6);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 849, 6);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 867, 6);
        //        fifthPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 885, 6);
        //        sixPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 903, 6);
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Reg_Amt_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 819, 6, 2);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 837, 6, 2);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 855, 6, 2);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 873, 6, 2);
        //        fifthPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 891, 6, 2);
        //        sixPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 909, 6, 2);
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Late_Amt_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 825, 6, 2);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 843, 6, 2);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 861, 6, 2);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 879, 6, 2);
        //        fifthPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 897, 6, 2);
        //        sixPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 915, 6, 2);
        //        Postion07 = "";
        //        Postion08 = "";
        //        Postion09 = "";
        //        Postion10 = "";
        //        Postion11 = "";
        //        Postion12 = "";
        //        Postion13 = "";
        //        Postion14 = "";
        //        Postion15 = "";
        //        Postion16 = "";
        //        Postion17 = "";
        //        Postion18 = "";
        //        Postion19 = "";
        //        Postion20 = "";
        //        Postion21 = "";
        //        Postion22 = "";
        //    }
        //    else if (variableName == "Rssi_Past_Date_R")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1791, 6);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1809, 6);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1827, 6);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1845, 6);
        //        fifthPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1863, 6);
        //        sixPostion = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1881, 6);
        //        Postion07 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1899, 6);
        //        Postion08 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1917, 6);
        //        Postion09 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1935, 6);
        //        Postion10 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1953, 6);
        //        Postion11 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1971, 6);
        //        Postion12 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1989, 6);
        //        Postion13 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2007, 6);
        //        Postion14 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2025, 6);
        //        Postion15 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2043, 6);
        //        Postion16 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2061, 6);
        //        Postion17 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2079, 6);
        //        Postion18 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2097, 6);
        //        Postion19 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2115, 6);
        //        Postion20 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2133, 6);
        //        Postion21 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2151, 6);
        //        Postion22 = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 2169, 6);
        //    }
        //    else if (variableName == "Rssi_Reg_Amt_R_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1797, 6, 2);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1815, 6, 2);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1833, 6, 2);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1851, 6, 2);
        //        fifthPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1869, 6, 2);
        //        sixPostion = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1887, 6, 2);
        //        Postion07 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1905, 6, 2);
        //        Postion08 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1923, 6, 2);
        //        Postion09 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1941, 6, 2);
        //        Postion10 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1959, 6, 2);
        //        Postion11 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1977, 6, 2);
        //        Postion12 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1995, 6, 2);
        //        Postion13 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2013, 6, 2);
        //        Postion14 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2031, 6, 2);
        //        Postion15 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2049, 6, 2);
        //        Postion16 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2067, 6, 2);
        //        Postion17 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2085, 6, 2);
        //        Postion18 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2103, 6, 2);
        //        Postion19 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2021, 6, 2);
        //        Postion20 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2139, 6, 2);
        //        Postion21 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2157, 6, 2);
        //        Postion22 = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 2175, 6, 2);
        //    }
        //    else if (variableName == "Rssi_Late_Amt_R_PackedData")
        //    {
        //        firstPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1803, 6, 2);
        //        secondPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1821, 6, 2);
        //        thirdPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1839, 6, 2);
        //        fourthPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1857, 6, 2);
        //        fifthPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1875, 6, 2);
        //        sixPostion = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1893, 6, 2);
        //        Postion07 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1911, 6, 2);
        //        Postion08 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1929, 6, 2);
        //        Postion09 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1947, 6, 2);
        //        Postion10 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1965, 6, 2);
        //        Postion11 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1983, 6, 2);
        //        Postion12 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2001, 6, 2);
        //        Postion13 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2019, 6, 2);
        //        Postion14 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2037, 6, 2);
        //        Postion15 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2055, 6, 2);
        //        Postion16 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2073, 6, 2);
        //        Postion17 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2091, 6, 2);
        //        Postion18 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2109, 6, 2);
        //        Postion19 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2127, 6, 2);
        //        Postion20 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2145, 6, 2);
        //        Postion21 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2163, 6, 2);
        //        Postion22 = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 2181, 6, 2);
        //    }
        //    else
        //        return "";

        //    if (firstPostion != "")
        //    { return firstPostion; }
        //    else if (secondPostion != "")
        //    { return secondPostion; }
        //    else if (thirdPostion != "")
        //    { return thirdPostion; }
        //    else if (fourthPostion != "")
        //    { return fourthPostion; }
        //    else if (fifthPostion != "")
        //    { return fourthPostion; }
        //    else if (sixPostion != "")
        //    { return fourthPostion; }
        //    else if (Postion07 != "")
        //    { return Postion07; }
        //    else if (Postion08 != "")
        //    { return Postion08; }
        //    else if (Postion09 != "")
        //    { return Postion09; }
        //    else if (Postion10 != "")
        //    { return Postion10; }
        //    else if (Postion11 != "")
        //    { return Postion11; }
        //    else if (Postion12 != "")
        //    { return Postion12; }
        //    else if (Postion13 != "")
        //    { return Postion13; }
        //    else if (Postion14 != "")
        //    { return Postion14; }
        //    else if (Postion15 != "")
        //    { return Postion15; }
        //    else if (Postion16 != "")
        //    { return Postion16; }
        //    else if (Postion17 != "")
        //    { return Postion17; }
        //    else if (Postion18 != "")
        //    { return Postion18; }
        //    else if (Postion19 != "")
        //    { return Postion19; }
        //    else if (Postion20 != "")
        //    { return Postion20; }
        //    else if (Postion21 != "")
        //    { return Postion21; }
        //    else if (Postion22 != "")
        //    { return Postion22; }
        //    else
        //        return "";
        //}

        //// 2 Master File Data Part 2 Record.One record per loan.
        //public void GetMasterFileDataPart_2(byte[] currentByte, ref AccountsModel acc)
        //{

        //    acc.MasterFileDataPart2Model = new MasterFileDataPart2Model()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Unap_Bal_2_PackedData = PackedTypeCheckAndUnPackData("Rssi_Unap_Bal_2_PackedData", currentByte, 20, 5, 2),
        //        Rssi_Unap_Cd_2 = PackedTypeCheckAndUnPackData("Rssi_Unap_Cd_2", currentByte, 25, 1),

        //        Rssi_Unap_Bal_3_PackedData = PackedTypeCheckAndUnPackData("Rssi_Unap_Bal_3_PackedData", currentByte, 26, 5, 2),
        //        Rssi_Unap_Cd_3 = PackedTypeCheckAndUnPackData("Rssi_Unap_Cd_3", currentByte, 31, 1),

        //        Rssi_Unap_Bal_4_PackedData = PackedTypeCheckAndUnPackData("Rssi_Unap_Bal_4_PackedData", currentByte, 32, 5, 2),
        //        Rssi_Unap_Cd_4 = PackedTypeCheckAndUnPackData("Rssi_Unap_Cd_4", currentByte, 37, 1),

        //        Rssi_Unap_Bal_5_PackedData = PackedTypeCheckAndUnPackData("Rssi_Unap_Bal_5_PackedData", currentByte, 38, 5, 2),
        //        Rssi_Unap_Cd_5 = PackedTypeCheckAndUnPackData("Rssi_Unap_Cd_5", currentByte, 43, 1),

        //        Rssi_Unap_Bal_Tot_PackedData = PackedTypeCheckAndUnPackData("Rssi_Unap_Bal_Tot_PackedData", currentByte, 44, 6, 2),
        //        Rssi_Tot_Draft_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tot_Draft_Amt_PackedData", currentByte, 50, 6, 2),

        //        Rssi_Rd_Bk_Draft_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rd_Bk_Draft_Amt_PackedData", currentByte, 56, 6, 2),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 62, 26),

        //        Rssi_Uncoll_Pi_Adv_PackedData = PackedTypeCheckAndUnPackData("Rssi_Uncoll_Pi_Adv_PackedData", currentByte, 88, 6, 2),
        //        Rssi_Orig_Mat_Date = PackedTypeCheckAndUnPackData("Rssi_Orig_Mat_Date", currentByte, 94, 5),

        //        Rssi_Delq_Couns = PackedTypeCheckAndUnPackData("Rssi_Delq_Couns", currentByte, 99, 3),
        //        Rssi_Bmsg_Code_01 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_01", currentByte, 102, 6),

        //        Rssi_Bmsg_Code_02 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_02", currentByte, 108, 6),
        //        Rssi_Bmsg_Code_03 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_03", currentByte, 114, 6),

        //        Rssi_Bmsg_Code_04 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_04", currentByte, 120, 6),
        //        Rssi_Bmsg_Code_05 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_05", currentByte, 126, 6),

        //        Rssi_Bmsg_Code_06 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_06", currentByte, 132, 6),
        //        Rssi_Bmsg_Code_07 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_07", currentByte, 138, 6),

        //        Rssi_Bmsg_Code_08 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_08", currentByte, 144, 6),
        //        Rssi_Bmsg_Code_09 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_09", currentByte, 150, 6),

        //        Rssi_Bmsg_Code_10 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_10", currentByte, 156, 6),
        //        Rssi_Bmsg_Code_11 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_11", currentByte, 162, 6),

        //        Rssi_Bmsg_Code_12 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_12", currentByte, 168, 6),
        //        Rssi_Bmsg_Code_13 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_13", currentByte, 174, 6),

        //        Rssi_Bmsg_Code_14 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_14", currentByte, 180, 6),
        //        Rssi_Bmsg_Code_15 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_15", currentByte, 186, 6),

        //        Rssi_Bmsg_Code_16 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_16", currentByte, 192, 6),
        //        Rssi_Bmsg_Code_17 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_17", currentByte, 198, 6),

        //        Rssi_Bmsg_Code_18 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_18", currentByte, 204, 6),
        //        Rssi_Bmsg_Code_19 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_19", currentByte, 210, 6),
        //        Rssi_Bmsg_Code_20 = PackedTypeCheckAndUnPackData("Rssi_Bmsg_Code_20", currentByte, 216, 6),

        //        Rssi_Prim_Forgn_Flag = PackedTypeCheckAndUnPackData("Rssi_Prim_Forgn_Flag", currentByte, 222, 1),
        //        Rssi_Altr_Forgn_Flag = PackedTypeCheckAndUnPackData("Rssi_Altr_Forgn_Flag", currentByte, 223, 1),

        //        Rssi_Appl_Foreign_Flag = PackedTypeCheckAndUnPackData("Rssi_Appl_Foreign_Flag", currentByte, 224, 1),
        //        Rssi_Def_Tot_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Tot_Ball_PackedData", currentByte, 225, 7, 2),

        //        Rssi_Def_Int_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Int_Bal_PackedData", currentByte, 232, 6, 2),
        //        Rssi_Def_Late_Chrg_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Late_Chrg_Bal_PackedData", currentByte, 238, 4, 2),

        //        Rssi_Def_Escrow_Adv_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Escrow_Adv_Bal_PackedData", currentByte, 242, 6, 2),
        //        Rssi_Def_Paid_Exp_Adv_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Paid_Exp_Adv_Bal_PackedData", currentByte, 248, 6, 2),

        //        Rssi_Def_Unpd_Exp_Adv_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Unpd_Exp_Adv_Bal_PackedData", currentByte, 254, 6, 2),
        //        Rssi_Def_Admn_Fees_Bal = PackedTypeCheckAndUnPackData("Rssi_Def_Admn_Fees_Bal", currentByte, 260, 6, 2),

        //        Rssi_Borr_Lnge = PackedTypeCheckAndUnPackData("Rssi_Borr_Lnge", currentByte, 266, 1),
        //        Rssi_Uncoll_Esc_Short = PackedTypeCheckAndUnPackData("Rssi_Uncoll_Esc_Short", currentByte, 267, 6, 2),

        //        Rssi_Def_Opt_Ins_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Opt_Ins_Bal_PackedData", currentByte, 273, 5, 2),
        //        Rssi_Clo_Agent_Cd = PackedTypeCheckAndUnPackData("Rssi_Clo_Agent_Cd", currentByte, 278, 5),

        //        FillerPart2 = PackedTypeCheckAndUnPackData("FillerPart2", currentByte, 283, 13),
        //        Rssi_Def_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Def_Prin_Bal_PackedData", currentByte, 296, 6, 2),

        //        Rssi_Comb_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Comb_Prin_Bal_PackedData", currentByte, 302, 6, 2),
        //        Rssi_Pra_Original_Amount_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pra_Original_Amount_PackedData", currentByte, 308, 6, 2),

        //        Rssi_Pra_Remain_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pra_Remain_Amt_PackedData", currentByte, 314, 6, 2),
        //        Rssi_Pra_Taken_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pra_Taken_Amt_PackedData", currentByte, 320, 6, 2),

        //        Rssi_Lmt_Program = PackedTypeCheckAndUnPackData("Rssi_Lmt_Program", currentByte, 326, 3),
        //        Rssi_Fcl_Start_Date = PackedTypeCheckAndUnPackData("Rssi_Fcl_Start_Date", currentByte, 329, 6),

        //        Rssi_Breach_Ltr_Dt = PackedTypeCheckAndUnPackData("Rssi_Breach_Ltr_Dt", currentByte, 335, 6),
        //        Rssi_Higher_Priced_Flag = PackedTypeCheckAndUnPackData("Rssi_Higher_Priced_Flag", currentByte, 341, 1),

        //        Rssi_Hpml_Escrow_Reqd_Thru_Dt = PackedTypeCheckAndUnPackData("Rssi_Hpml_Escrow_Reqd_Thru_Dt", currentByte, 342, 8),
        //        Filler_350_536 = PackedTypeCheckAndUnPackData("Filler_350_536", currentByte, 350, 187),

        //        Rssi_Ml_Curr_Occ_Code = PackedTypeCheckAndUnPackData("Rssi_Ml_Curr_Occ_Code", currentByte, 537, 1),
        //        Filler_538_1500 = PackedTypeCheckAndUnPackData("Filler_538_1500", currentByte, 538, 965),

        //    };
        //}

        //// U User Field Record. One record per loan if applicable.
        //public void GetUserFieldRecord(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.UserFieldRecordModel = new UserFieldRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Usr_02_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_02_PackedData", currentByte, 20, 4),
        //        Rssi_Usr_03 = PackedTypeCheckAndUnPackData("Rssi_Usr_03", currentByte, 24, 1),

        //        Rssi_Usr_04 = PackedTypeCheckAndUnPackData("Rssi_Usr_04", currentByte, 25, 1),
        //        Rssi_Usr_05 = PackedTypeCheckAndUnPackData("Rssi_Usr_05", currentByte, 26, 1),

        //        Rssi_Usr_06 = PackedTypeCheckAndUnPackData("Rssi_Usr_06", currentByte, 27, 1),
        //        Rssi_Usr_08 = PackedTypeCheckAndUnPackData("Rssi_Usr_08", currentByte, 28, 2),

        //        Rssi_Usr_09 = PackedTypeCheckAndUnPackData("Rssi_Usr_09", currentByte, 30, 2),
        //        Rssi_Usr_10 = PackedTypeCheckAndUnPackData("Rssi_Usr_10", currentByte, 32, 2),

        //        Rssi_Usr_11 = PackedTypeCheckAndUnPackData("Rssi_Usr_11", currentByte, 34, 3),
        //        Rssi_Usr_12 = PackedTypeCheckAndUnPackData("Rssi_Usr_12", currentByte, 37, 3),

        //        Rssi_Usr_13 = PackedTypeCheckAndUnPackData("Rssi_Usr_13", currentByte, 40, 3),
        //        Rssi_Usr_14 = PackedTypeCheckAndUnPackData("Rssi_Usr_14", currentByte, 43, 6),

        //        Rssi_Usr_15_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_15_PackedData", currentByte, 49, 4),
        //        Rssi_Usr_16_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_16_PackedData", currentByte, 53, 4),

        //        Rssi_Usr_17_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_17_PackedData", currentByte, 57, 5),
        //        Rssi_Usr_18 = PackedTypeCheckAndUnPackData("Rssi_Usr_18", currentByte, 62, 15),

        //        Rssi_Usr_19 = PackedTypeCheckAndUnPackData("Rssi_Usr_19", currentByte, 77, 5),
        //        Rssi_Usr_20_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_20_PackedData", currentByte, 82, 2),

        //        Rssi_Usr_21 = PackedTypeCheckAndUnPackData("Rssi_Usr_21", currentByte, 84, 10),
        //        Rssi_Usr_22 = PackedTypeCheckAndUnPackData("Rssi_Usr_22", currentByte, 94, 10),

        //        Rssi_Usr_23 = PackedTypeCheckAndUnPackData("Rssi_Usr_23", currentByte, 104, 6),
        //        Rssi_Usr_24 = PackedTypeCheckAndUnPackData("Rssi_Usr_24", currentByte, 110, 6),

        //        Rssi_Usr_25_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_25_PackedData", currentByte, 116, 4),
        //        Rssi_Usr_26_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_26_PackedData", currentByte, 120, 4),

        //        Rssi_Usr_27_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_27_PackedData", currentByte, 124, 4),
        //        Rssi_Usr_28_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_28_PackedData", currentByte, 128, 4),

        //        Rssi_Usr_29_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_29_PackedData", currentByte, 132, 4),
        //        Rssi_Usr_30_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_30_PackedData", currentByte, 136, 4),

        //        Rssi_Usr_31_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_31_PackedData", currentByte, 140, 6),
        //        Rssi_Usr_32_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_32_PackedData", currentByte, 146, 6),

        //        Rssi_Usr_33_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_33_PackedData", currentByte, 152, 6),
        //        Rssi_Usr_34_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_34_PackedData", currentByte, 158, 6),

        //        Rssi_Usr_35 = PackedTypeCheckAndUnPackData("Rssi_Usr_35", currentByte, 164, 1),
        //        Rssi_Usr_37 = PackedTypeCheckAndUnPackData("Rssi_Usr_37", currentByte, 165, 1),

        //        Rssi_Usr_38 = PackedTypeCheckAndUnPackData("Rssi_Usr_38", currentByte, 166, 1),
        //        Rssi_Usr_39 = PackedTypeCheckAndUnPackData("Rssi_Usr_39", currentByte, 167, 2),

        //        Rssi_Usr_40 = PackedTypeCheckAndUnPackData("Rssi_Usr_40", currentByte, 169, 2),
        //        Rssi_Usr_41 = PackedTypeCheckAndUnPackData("Rssi_Usr_41", currentByte, 171, 2),

        //        Rssi_Usr_42 = PackedTypeCheckAndUnPackData("Rssi_Usr_42", currentByte, 173, 2),
        //        Rssi_Usr_43 = PackedTypeCheckAndUnPackData("Rssi_Usr_43", currentByte, 175, 3),

        //        Rssi_Usr_44 = PackedTypeCheckAndUnPackData("Rssi_Usr_44", currentByte, 178, 6),
        //        Rssi_Usr_45 = PackedTypeCheckAndUnPackData("Rssi_Usr_45", currentByte, 184, 6),

        //        Rssi_Usr_46 = PackedTypeCheckAndUnPackData("Rssi_Usr_46", currentByte, 190, 15),
        //        Rssi_Usr_47 = PackedTypeCheckAndUnPackData("Rssi_Usr_47", currentByte, 205, 15),

        //        Rssi_Usr_48 = PackedTypeCheckAndUnPackData("Rssi_Usr_48", currentByte, 220, 15),
        //        Rssi_Usr_49 = PackedTypeCheckAndUnPackData("Rssi_Usr_49", currentByte, 235, 15),

        //        Rssi_Usr_50 = PackedTypeCheckAndUnPackData("Rssi_Usr_50", currentByte, 250, 15),
        //        Rssi_Usr_51 = PackedTypeCheckAndUnPackData("Rssi_Usr_51", currentByte, 265, 35),

        //        Rssi_Usr_52 = PackedTypeCheckAndUnPackData("Rssi_Usr_52", currentByte, 300, 35),
        //        Rssi_Usr_53 = PackedTypeCheckAndUnPackData("Rssi_Usr_53", currentByte, 335, 35),

        //        Rssi_Usr_54 = PackedTypeCheckAndUnPackData("Rssi_Usr_54", currentByte, 370, 1),
        //        Rssi_Usr_55 = PackedTypeCheckAndUnPackData("Rssi_Usr_55", currentByte, 371, 1),

        //        Rssi_Usr_56 = PackedTypeCheckAndUnPackData("Rssi_Usr_56", currentByte, 372, 1),
        //        Rssi_Usr_57 = PackedTypeCheckAndUnPackData("Rssi_Usr_57", currentByte, 373, 1),

        //        Rssi_Usr_58 = PackedTypeCheckAndUnPackData("Rssi_Usr_58", currentByte, 374, 1),
        //        Rssi_Usr_59 = PackedTypeCheckAndUnPackData("Rssi_Usr_59", currentByte, 375, 1),

        //        Rssi_Usr_60 = PackedTypeCheckAndUnPackData("Rssi_Usr_60", currentByte, 376, 1),
        //        Rssi_Usr_61 = PackedTypeCheckAndUnPackData("Rssi_Usr_61", currentByte, 377, 1),

        //        Rssi_Usr_62 = PackedTypeCheckAndUnPackData("Rssi_Usr_62", currentByte, 378, 1),
        //        Rssi_Usr_63 = PackedTypeCheckAndUnPackData("Rssi_Usr_63", currentByte, 379, 1),

        //        Rssi_Usr_64 = PackedTypeCheckAndUnPackData("Rssi_Usr_64", currentByte, 380, 1),
        //        Rssi_Usr_65 = PackedTypeCheckAndUnPackData("Rssi_Usr_65", currentByte, 381, 1),

        //        Rssi_Usr_66 = PackedTypeCheckAndUnPackData("Rssi_Usr_66", currentByte, 382, 1),
        //        Rssi_Usr_67 = PackedTypeCheckAndUnPackData("Rssi_Usr_67", currentByte, 383, 1),

        //        Rssi_Usr_68 = PackedTypeCheckAndUnPackData("Rssi_Usr_68", currentByte, 384, 1),
        //        Rssi_Usr_69 = PackedTypeCheckAndUnPackData("Rssi_Usr_69", currentByte, 385, 1),

        //        Rssi_Usr_70 = PackedTypeCheckAndUnPackData("Rssi_Usr_70", currentByte, 386, 1),
        //        Rssi_Usr_71 = PackedTypeCheckAndUnPackData("Rssi_Usr_71", currentByte, 387, 1),

        //        Rssi_Usr_72 = PackedTypeCheckAndUnPackData("Rssi_Usr_72", currentByte, 388, 1),
        //        Rssi_Usr_73 = PackedTypeCheckAndUnPackData("Rssi_Usr_73", currentByte, 389, 1),

        //        Rssi_Usr_74 = PackedTypeCheckAndUnPackData("Rssi_Usr_74", currentByte, 390, 2),
        //        Rssi_Usr_75 = PackedTypeCheckAndUnPackData("Rssi_Usr_75", currentByte, 392, 2),

        //        Rssi_Usr_76 = PackedTypeCheckAndUnPackData("Rssi_Usr_76", currentByte, 394, 2),
        //        Rssi_Usr_77 = PackedTypeCheckAndUnPackData("Rssi_Usr_77", currentByte, 396, 2),

        //        Rssi_Usr_78 = PackedTypeCheckAndUnPackData("Rssi_Usr_78", currentByte, 398, 2),
        //        Rssi_Usr_79 = PackedTypeCheckAndUnPackData("Rssi_Usr_79", currentByte, 400, 2),

        //        Rssi_Usr_80 = PackedTypeCheckAndUnPackData("Rssi_Usr_80", currentByte, 402, 2),
        //        Rssi_Usr_81 = PackedTypeCheckAndUnPackData("Rssi_Usr_81", currentByte, 404, 2),

        //        Rssi_Usr_82 = PackedTypeCheckAndUnPackData("Rssi_Usr_82", currentByte, 406, 2),
        //        Rssi_Usr_83 = PackedTypeCheckAndUnPackData("Rssi_Usr_83", currentByte, 408, 2),

        //        Rssi_Usr_84 = PackedTypeCheckAndUnPackData("Rssi_Usr_84", currentByte, 410, 2),
        //        Rssi_Usr_85 = PackedTypeCheckAndUnPackData("Rssi_Usr_85", currentByte, 412, 2),

        //        Rssi_Usr_86 = PackedTypeCheckAndUnPackData("Rssi_Usr_86", currentByte, 414, 2),
        //        Rssi_Usr_87 = PackedTypeCheckAndUnPackData("Rssi_Usr_87", currentByte, 416, 2),

        //        Rssi_Usr_88 = PackedTypeCheckAndUnPackData("Rssi_Usr_88", currentByte, 418, 2),
        //        Rssi_Usr_89 = PackedTypeCheckAndUnPackData("Rssi_Usr_89", currentByte, 420, 2),

        //        Rssi_Usr_90 = PackedTypeCheckAndUnPackData("Rssi_Usr_90", currentByte, 422, 2),
        //        Rssi_Usr_91 = PackedTypeCheckAndUnPackData("Rssi_Usr_91", currentByte, 424, 2),

        //        Rssi_Usr_92 = PackedTypeCheckAndUnPackData("Rssi_Usr_92", currentByte, 426, 2),
        //        Rssi_Usr_93 = PackedTypeCheckAndUnPackData("Rssi_Usr_93", currentByte, 428, 2),

        //        Rssi_Usr_94 = PackedTypeCheckAndUnPackData("Rssi_Usr_94", currentByte, 430, 6),
        //        Rssi_Usr_95 = PackedTypeCheckAndUnPackData("Rssi_Usr_95", currentByte, 436, 6),

        //        Rssi_Usr_96 = PackedTypeCheckAndUnPackData("Rssi_Usr_96", currentByte, 442, 6),
        //        Rssi_Usr_97 = PackedTypeCheckAndUnPackData("Rssi_Usr_97", currentByte, 448, 6),

        //        Rssi_Usr_98 = PackedTypeCheckAndUnPackData("Rssi_Usr_98", currentByte, 454, 6),
        //        Rssi_Usr_99 = PackedTypeCheckAndUnPackData("Rssi_Usr_99", currentByte, 460, 6),

        //        Rssi_Usr_100 = PackedTypeCheckAndUnPackData("Rssi_Usr_100", currentByte, 466, 6),
        //        Rssi_Usr_101 = PackedTypeCheckAndUnPackData("Rssi_Usr_101", currentByte, 472, 6),

        //        Rssi_Usr_102 = PackedTypeCheckAndUnPackData("Rssi_Usr_102", currentByte, 478, 6),
        //        Rssi_Usr_103 = PackedTypeCheckAndUnPackData("Rssi_Usr_103", currentByte, 484, 6),

        //        Rssi_Usr_104 = PackedTypeCheckAndUnPackData("Rssi_Usr_104", currentByte, 490, 6),
        //        Rssi_Usr_105 = PackedTypeCheckAndUnPackData("Rssi_Usr_105", currentByte, 496, 6),

        //        Rssi_Usr_106 = PackedTypeCheckAndUnPackData("Rssi_Usr_106", currentByte, 502, 6),
        //        Rssi_Usr_107 = PackedTypeCheckAndUnPackData("Rssi_Usr_107", currentByte, 508, 6),

        //        Rssi_Usr_108 = PackedTypeCheckAndUnPackData("Rssi_Usr_108", currentByte, 514, 6),
        //        Rssi_Usr_109 = PackedTypeCheckAndUnPackData("Rssi_Usr_109", currentByte, 520, 6),

        //        Rssi_Usr_110 = PackedTypeCheckAndUnPackData("Rssi_Usr_110", currentByte, 526, 6),
        //        Rssi_Usr_111 = PackedTypeCheckAndUnPackData("Rssi_Usr_111", currentByte, 532, 6),

        //        Rssi_Usr_112 = PackedTypeCheckAndUnPackData("Rssi_Usr_112", currentByte, 538, 6),
        //        Rssi_Usr_113 = PackedTypeCheckAndUnPackData("Rssi_Usr_113", currentByte, 544, 10),

        //        Rssi_Usr_114 = PackedTypeCheckAndUnPackData("Rssi_Usr_114", currentByte, 554, 10),
        //        Rssi_Usr_115 = PackedTypeCheckAndUnPackData("Rssi_Usr_115", currentByte, 564, 10),

        //        Rssi_Usr_116 = PackedTypeCheckAndUnPackData("Rssi_Usr_116", currentByte, 574, 10),
        //        Rssi_Usr_117 = PackedTypeCheckAndUnPackData("Rssi_Usr_117", currentByte, 584, 10),

        //        Rssi_Usr_118 = PackedTypeCheckAndUnPackData("Rssi_Usr_118", currentByte, 594, 10),
        //        Rssi_Usr_119 = PackedTypeCheckAndUnPackData("Rssi_Usr_119", currentByte, 604, 10),

        //        Rssi_Usr_120 = PackedTypeCheckAndUnPackData("Rssi_Usr_120", currentByte, 614, 10),
        //        Rssi_Usr_121 = PackedTypeCheckAndUnPackData("Rssi_Usr_121", currentByte, 624, 10),

        //        Rssi_Usr_122 = PackedTypeCheckAndUnPackData("Rssi_Usr_122", currentByte, 634, 10),
        //        Rssi_Usr_123 = PackedTypeCheckAndUnPackData("Rssi_Usr_123", currentByte, 644, 10),

        //        Rssi_Usr_124 = PackedTypeCheckAndUnPackData("Rssi_Usr_124", currentByte, 654, 10),
        //        Rssi_Usr_125 = PackedTypeCheckAndUnPackData("Rssi_Usr_125", currentByte, 664, 10),

        //        Rssi_Usr_126 = PackedTypeCheckAndUnPackData("Rssi_Usr_126", currentByte, 674, 10),
        //        Rssi_Usr_127 = PackedTypeCheckAndUnPackData("Rssi_Usr_127", currentByte, 684, 10),

        //        Rssi_Usr_128 = PackedTypeCheckAndUnPackData("Rssi_Usr_128", currentByte, 694, 10),
        //        Rssi_Usr_129 = PackedTypeCheckAndUnPackData("Rssi_Usr_129", currentByte, 704, 10),

        //        Rssi_Usr_130 = PackedTypeCheckAndUnPackData("Rssi_Usr_130", currentByte, 714, 10),
        //        Rssi_Usr_131 = PackedTypeCheckAndUnPackData("Rssi_Usr_131", currentByte, 724, 10),

        //        Rssi_Usr_132 = PackedTypeCheckAndUnPackData("Rssi_Usr_132", currentByte, 734, 10),
        //        Rssi_Usr_133 = PackedTypeCheckAndUnPackData("Rssi_Usr_133", currentByte, 744, 15),

        //        Rssi_Usr_134 = PackedTypeCheckAndUnPackData("Rssi_Usr_134", currentByte, 759, 15),
        //        Rssi_Usr_135 = PackedTypeCheckAndUnPackData("Rssi_Usr_135", currentByte, 774, 15),

        //        Rssi_Usr_136 = PackedTypeCheckAndUnPackData("Rssi_Usr_136", currentByte, 789, 15),
        //        Rssi_Usr_137 = PackedTypeCheckAndUnPackData("Rssi_Usr_137", currentByte, 804, 15),

        //        Rssi_Usr_138 = PackedTypeCheckAndUnPackData("Rssi_Usr_138", currentByte, 819, 15),
        //        Rssi_Usr_139 = PackedTypeCheckAndUnPackData("Rssi_Usr_139", currentByte, 834, 15),

        //        Rssi_Usr_140 = PackedTypeCheckAndUnPackData("Rssi_Usr_140", currentByte, 849, 15),
        //        Rssi_Usr_141 = PackedTypeCheckAndUnPackData("Rssi_Usr_141", currentByte, 864, 15),

        //        Rssi_Usr_142 = PackedTypeCheckAndUnPackData("Rssi_Usr_142", currentByte, 879, 15),
        //        Rssi_Usr_143 = PackedTypeCheckAndUnPackData("Rssi_Usr_143", currentByte, 894, 15),

        //        Rssi_Usr_144 = PackedTypeCheckAndUnPackData("Rssi_Usr_144", currentByte, 909, 15),
        //        Rssi_Usr_145 = PackedTypeCheckAndUnPackData("Rssi_Usr_145", currentByte, 924, 15),

        //        Rssi_Usr_146 = PackedTypeCheckAndUnPackData("Rssi_Usr_146", currentByte, 939, 0),
        //        Rssi_Usr_147 = PackedTypeCheckAndUnPackData("Rssi_Usr_147", currentByte, 954, 15),

        //        Rssi_Usr_148 = PackedTypeCheckAndUnPackData("Rssi_Usr_148", currentByte, 969, 15),
        //        Rssi_Usr_149 = PackedTypeCheckAndUnPackData("Rssi_Usr_149", currentByte, 984, 15),

        //        Rssi_Usr_150 = PackedTypeCheckAndUnPackData("Rssi_Usr_150", currentByte, 999, 15),
        //        Rssi_Usr_151 = PackedTypeCheckAndUnPackData("Rssi_Usr_151", currentByte, 1014, 15),

        //        Rssi_Usr_152 = PackedTypeCheckAndUnPackData("Rssi_Usr_152", currentByte, 1029, 15),
        //        Rssi_Usr_153 = PackedTypeCheckAndUnPackData("Rssi_Usr_153", currentByte, 1044, 35),

        //        Rssi_Usr_154 = PackedTypeCheckAndUnPackData("Rssi_Usr_154", currentByte, 1079, 35),
        //        Rssi_Usr_155 = PackedTypeCheckAndUnPackData("Rssi_Usr_155", currentByte, 1114, 35),

        //        Rssi_Usr_156 = PackedTypeCheckAndUnPackData("Rssi_Usr_156", currentByte, 1149, 35),
        //        Rssi_Usr_157 = PackedTypeCheckAndUnPackData("Rssi_Usr_157", currentByte, 1184, 35),

        //        Rssi_Usr_158 = PackedTypeCheckAndUnPackData("Rssi_Usr_158", currentByte, 1219, 35),
        //        Rssi_Usr_159 = PackedTypeCheckAndUnPackData("Rssi_Usr_159", currentByte, 1254, 35),

        //        Rssi_Usr_160 = PackedTypeCheckAndUnPackData("Rssi_Usr_160", currentByte, 1289, 35),
        //        Rssi_Usr_161 = PackedTypeCheckAndUnPackData("Rssi_Usr_161", currentByte, 1324, 35),

        //        Rssi_Usr_162 = PackedTypeCheckAndUnPackData("Rssi_Usr_162", currentByte, 1359, 35),
        //        Rssi_Usr_163 = PackedTypeCheckAndUnPackData("Rssi_Usr_163", currentByte, 1394, 35),

        //        Rssi_Usr_164 = PackedTypeCheckAndUnPackData("Rssi_Usr_164", currentByte, 1429, 35),
        //        Rssi_Usr_165 = PackedTypeCheckAndUnPackData("Rssi_Usr_165", currentByte, 1464, 35),

        //        Rssi_Usr_166 = PackedTypeCheckAndUnPackData("Rssi_Usr_166", currentByte, 1499, 35),
        //        Rssi_Usr_167 = PackedTypeCheckAndUnPackData("Rssi_Usr_167", currentByte, 1534, 35),

        //        Rssi_Usr_168 = PackedTypeCheckAndUnPackData("Rssi_Usr_168", currentByte, 1569, 35),
        //        Rssi_Usr_169 = PackedTypeCheckAndUnPackData("Rssi_Usr_169", currentByte, 1604, 35),

        //        Rssi_Usr_170 = PackedTypeCheckAndUnPackData("Rssi_Usr_170", currentByte, 1639, 35),
        //        Rssi_Usr_171 = PackedTypeCheckAndUnPackData("Rssi_Usr_171", currentByte, 1674, 35),

        //        Rssi_Usr_172 = PackedTypeCheckAndUnPackData("Rssi_Usr_172", currentByte, 1709, 35),
        //        Rssi_Usr_173 = PackedTypeCheckAndUnPackData("Rssi_Usr_173", currentByte, 1744, 60),

        //        Rssi_Usr_174 = PackedTypeCheckAndUnPackData("Rssi_Usr_174", currentByte, 1804, 60),
        //        Rssi_Usr_175 = PackedTypeCheckAndUnPackData("Rssi_Usr_175", currentByte, 1864, 60),

        //        Rssi_Usr_176 = PackedTypeCheckAndUnPackData("Rssi_Usr_176", currentByte, 1924, 60),
        //        Rssi_Usr_177 = PackedTypeCheckAndUnPackData("Rssi_Usr_177", currentByte, 1984, 60),

        //        Rssi_Usr_178 = PackedTypeCheckAndUnPackData("Rssi_Usr_178", currentByte, 2044, 60),
        //        Rssi_Usr_179 = PackedTypeCheckAndUnPackData("Rssi_Usr_179", currentByte, 2104, 60),

        //        Rssi_Usr_180 = PackedTypeCheckAndUnPackData("Rssi_Usr_180", currentByte, 2164, 60),
        //        Rssi_Usr_181 = PackedTypeCheckAndUnPackData("Rssi_Usr_181", currentByte, 2224, 60),

        //        Rssi_Usr_182 = PackedTypeCheckAndUnPackData("Rssi_Usr_182", currentByte, 2284, 60),
        //        Rssi_Usr_183 = PackedTypeCheckAndUnPackData("Rssi_Usr_183", currentByte, 2344, 60),

        //        Rssi_Usr_184 = PackedTypeCheckAndUnPackData("Rssi_Usr_184", currentByte, 2404, 60),
        //        Rssi_Usr_185 = PackedTypeCheckAndUnPackData("Rssi_Usr_185", currentByte, 2464, 60),

        //        Rssi_Usr_186 = PackedTypeCheckAndUnPackData("Rssi_Usr_186", currentByte, 2524, 60),
        //        Rssi_Usr_187 = PackedTypeCheckAndUnPackData("Rssi_Usr_187", currentByte, 2584, 60),

        //        Rssi_Usr_188 = PackedTypeCheckAndUnPackData("Rssi_Usr_188", currentByte, 2644, 60),
        //        Rssi_Usr_189 = PackedTypeCheckAndUnPackData("Rssi_Usr_189", currentByte, 2704, 60),

        //        Rssi_Usr_190 = PackedTypeCheckAndUnPackData("Rssi_Usr_190", currentByte, 2764, 60),
        //        Rssi_Usr_191 = PackedTypeCheckAndUnPackData("Rssi_Usr_191", currentByte, 2824, 60),

        //        Rssi_Usr_192 = PackedTypeCheckAndUnPackData("Rssi_Usr_192", currentByte, 2884, 60),
        //        Rssi_Usr_193 = PackedTypeCheckAndUnPackData("Rssi_Usr_193", currentByte, 2944, 75),

        //        Rssi_Usr_194 = PackedTypeCheckAndUnPackData("Rssi_Usr_194", currentByte, 3019, 75),
        //        Rssi_Usr_195 = PackedTypeCheckAndUnPackData("Rssi_Usr_195", currentByte, 3094, 1),

        //        Rssi_Usr_196 = PackedTypeCheckAndUnPackData("Rssi_Usr_196", currentByte, 3095, 1),
        //        Rssi_Usr_197 = PackedTypeCheckAndUnPackData("Rssi_Usr_197", currentByte, 3096, 1),

        //        Rssi_Usr_198 = PackedTypeCheckAndUnPackData("Rssi_Usr_198", currentByte, 3097, 1),
        //        Rssi_Usr_199 = PackedTypeCheckAndUnPackData("Rssi_Usr_199", currentByte, 3098, 1),

        //        Rssi_Usr_200 = PackedTypeCheckAndUnPackData("Rssi_Usr_200", currentByte, 3099, 1),
        //        Rssi_Usr_201 = PackedTypeCheckAndUnPackData("Rssi_Usr_201", currentByte, 3100, 1),

        //        Rssi_Usr_202 = PackedTypeCheckAndUnPackData("Rssi_Usr_202", currentByte, 3101, 1),
        //        Rssi_Usr_203 = PackedTypeCheckAndUnPackData("Rssi_Usr_203", currentByte, 3102, 1),

        //        Rssi_Usr_204 = PackedTypeCheckAndUnPackData("Rssi_Usr_204", currentByte, 3103, 1),
        //        Rssi_Usr_205 = PackedTypeCheckAndUnPackData("Rssi_Usr_205", currentByte, 3104, 1),

        //        Rssi_Usr_206 = PackedTypeCheckAndUnPackData("Rssi_Usr_206", currentByte, 3105, 1),
        //        Rssi_Usr_207 = PackedTypeCheckAndUnPackData("Rssi_Usr_207", currentByte, 3106, 1),

        //        Rssi_Usr_208 = PackedTypeCheckAndUnPackData("Rssi_Usr_208", currentByte, 3107, 1),
        //        Rssi_Usr_209 = PackedTypeCheckAndUnPackData("Rssi_Usr_209", currentByte, 3108, 1),

        //        Rssi_Usr_210 = PackedTypeCheckAndUnPackData("Rssi_Usr_210", currentByte, 3109, 1),
        //        Rssi_Usr_211 = PackedTypeCheckAndUnPackData("Rssi_Usr_211", currentByte, 3110, 1),

        //        Rssi_Usr_212 = PackedTypeCheckAndUnPackData("Rssi_Usr_212", currentByte, 3111, 1),
        //        Rssi_Usr_213 = PackedTypeCheckAndUnPackData("Rssi_Usr_213", currentByte, 3112, 1),

        //        Rssi_Usr_214 = PackedTypeCheckAndUnPackData("Rssi_Usr_214", currentByte, 3113, 1),
        //        Rssi_Usr_215_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_215_PackedData", currentByte, 3114, 2),

        //        Rssi_Usr_216_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_216_PackedData", currentByte, 3116, 2),
        //        Rssi_Usr_217_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_217_PackedData", currentByte, 3118, 2),

        //        Rssi_Usr_218_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_218_PackedData", currentByte, 3120, 2),
        //        Rssi_Usr_219_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_219_PackedData", currentByte, 3122, 2),

        //        Rssi_Usr_220_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_220_PackedData", currentByte, 3124, 2),
        //        Rssi_Usr_221_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_221_PackedData", currentByte, 3126, 2),

        //        Rssi_Usr_222_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_222_PackedData", currentByte, 3128, 2),
        //        Rssi_Usr_223_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_223_PackedData", currentByte, 3130, 2),

        //        Rssi_Usr_224_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_224_PackedData", currentByte, 3132, 2),
        //        Rssi_Usr_225_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_225_PackedData", currentByte, 3134, 2),

        //        Rssi_Usr_226_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_226_PackedData", currentByte, 3136, 2),
        //        Rssi_Usr_227_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_227_PackedData", currentByte, 3138, 2),

        //        Rssi_Usr_228_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_228_PackedData", currentByte, 3140, 2),
        //        Rssi_Usr_229_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_229_PackedData", currentByte, 3142, 2),

        //        Rssi_Usr_230_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_230_PackedData", currentByte, 3144, 2),
        //        Rssi_Usr_231_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_231_PackedData", currentByte, 3146, 2),

        //        Rssi_Usr_232_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_232_PackedData", currentByte, 3148, 2),
        //        Rssi_Usr_233_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_233_PackedData", currentByte, 3150, 2),

        //        Rssi_Usr_234_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_234_PackedData", currentByte, 3152, 2),
        //        Rssi_Usr_235_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_235_PackedData", currentByte, 3154, 4),

        //        Rssi_Usr_236_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_236_PackedData", currentByte, 3158, 4),
        //        Rssi_Usr_237_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_237_PackedData", currentByte, 3162, 4),

        //        Rssi_Usr_238_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_238_PackedData", currentByte, 3166, 4),
        //        Rssi_Usr_239_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_239_PackedData", currentByte, 3170, 4),

        //        Rssi_Usr_240_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_240_PackedData", currentByte, 3174, 4),
        //        Rssi_Usr_241_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_241_PackedData", currentByte, 3178, 4),

        //        Rssi_Usr_242_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_242_PackedData", currentByte, 3182, 4),
        //        Rssi_Usr_243_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_243_PackedData", currentByte, 3186, 4),

        //        Rssi_Usr_244_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_244_PackedData", currentByte, 3190, 4),
        //        Rssi_Usr_245_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_245_PackedData", currentByte, 3194, 4),

        //        Rssi_Usr_246_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_246_PackedData", currentByte, 3198, 4),
        //        Rssi_Usr_247_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_247_PackedData", currentByte, 3202, 4),

        //        Rssi_Usr_248_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_248_PackedData", currentByte, 3206, 4),
        //        Rssi_Usr_249_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_249_PackedData", currentByte, 3210, 4),

        //        Rssi_Usr_250_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_250_PackedData", currentByte, 3214, 4),
        //        Rssi_Usr_251_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_251_PackedData", currentByte, 3218, 4),

        //        Rssi_Usr_252_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_252_PackedData", currentByte, 3222, 4),
        //        Rssi_Usr_253_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_253_PackedData", currentByte, 3226, 4),

        //        Rssi_Usr_254_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_254_PackedData", currentByte, 3230, 4),
        //        Rssi_Usr_255_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_255_PackedData", currentByte, 3234, 6),

        //        Rssi_Usr_256_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_256_PackedData", currentByte, 3240, 6),
        //        Rssi_Usr_257_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_257_PackedData", currentByte, 3246, 6),

        //        Rssi_Usr_258_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_258_PackedData", currentByte, 3252, 6),
        //        Rssi_Usr_259_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_259_PackedData", currentByte, 3258, 6),

        //        Rssi_Usr_260_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_260_PackedData", currentByte, 3264, 6),
        //        Rssi_Usr_261_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_261_PackedData", currentByte, 3270, 6),

        //        Rssi_Usr_262_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_262_PackedData", currentByte, 3276, 6),
        //        Rssi_Usr_263_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_263_PackedData", currentByte, 3282, 6),

        //        Rssi_Usr_264_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_264_PackedData", currentByte, 3288, 6),
        //        Rssi_Usr_265_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_265_PackedData", currentByte, 3294, 6),

        //        Rssi_Usr_266_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_266_PackedData", currentByte, 3300, 6),
        //        Rssi_Usr_267_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_267_PackedData", currentByte, 3306, 6),

        //        Rssi_Usr_268_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_268_PackedData", currentByte, 3312, 6),
        //        Rssi_Usr_269_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_269_PackedData", currentByte, 3318, 6),

        //        Rssi_Usr_270_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_270_PackedData", currentByte, 3324, 6),
        //        Rssi_Usr_271_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_271_PackedData", currentByte, 3330, 6),

        //        Rssi_Usr_272_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_272_PackedData", currentByte, 3336, 6),
        //        Rssi_Usr_273_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_273_PackedData", currentByte, 3342, 6),

        //        Rssi_Usr_274_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_274_PackedData", currentByte, 3348, 6),
        //        Rssi_Usr_275_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_275_PackedData", currentByte, 3354, 4, 2),

        //        Rssi_Usr_276_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_276_PackedData", currentByte, 3358, 4, 2),
        //        Rssi_Usr_277_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_277_PackedData", currentByte, 3362, 4, 2),

        //        Rssi_Usr_278_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_278_PackedData", currentByte, 3366, 4, 2),
        //        Rssi_Usr_279_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_279_PackedData", currentByte, 3370, 4, 2),

        //        Rssi_Usr_280_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_280_PackedData", currentByte, 3374, 4, 2),
        //        Rssi_Usr_281_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_281_PackedData", currentByte, 3378, 4, 2),

        //        Rssi_Usr_282_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_282_PackedData", currentByte, 3382, 4, 2),
        //        Rssi_Usr_283_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_283_PackedData", currentByte, 3386, 4, 2),

        //        Rssi_Usr_284_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_284_PackedData", currentByte, 3390, 4, 2),
        //        Rssi_Usr_285_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_285_PackedData", currentByte, 3394, 4, 2),

        //        Rssi_Usr_286_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_286_PackedData", currentByte, 3398, 4, 2),
        //        Rssi_Usr_287_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_287_PackedData", currentByte, 3402, 4, 2),

        //        Rssi_Usr_288_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_288_PackedData", currentByte, 3406, 4, 2),
        //        Rssi_Usr_289_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_289_PackedData", currentByte, 3410, 4, 2),

        //        Rssi_Usr_290_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_290_PackedData", currentByte, 3414, 4, 2),
        //        Rssi_Usr_291_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_291_PackedData", currentByte, 3418, 4, 2),

        //        Rssi_Usr_292_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_292_PackedData", currentByte, 3422, 4, 2),
        //        Rssi_Usr_293_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_293_PackedData", currentByte, 3426, 4, 2),

        //        Rssi_Usr_294_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_294_PackedData", currentByte, 3430, 4, 2),
        //        Rssi_Usr_295_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_295_PackedData", currentByte, 3434, 5, 2),

        //        Rssi_Usr_296_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_296_PackedData", currentByte, 3439, 5, 2),
        //        Rssi_Usr_297_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_297_PackedData", currentByte, 3444, 5, 2),

        //        Rssi_Usr_298_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_298_PackedData", currentByte, 3449, 5, 2),
        //        Rssi_Usr_299_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_299_PackedData", currentByte, 3454, 5, 2),

        //        Rssi_Usr_300_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_300_PackedData", currentByte, 3459, 5, 2),
        //        Rssi_Usr_301_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_301_PackedData", currentByte, 3464, 5, 2),

        //        Rssi_Usr_302_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_302_PackedData", currentByte, 3469, 5, 2),
        //        Rssi_Usr_303_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_303_PackedData", currentByte, 3474, 5, 2),

        //        Rssi_Usr_304_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_304_PackedData", currentByte, 3479, 5, 2),
        //        Rssi_Usr_305_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_305_PackedData", currentByte, 3484, 5, 2),

        //        Rssi_Usr_306_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_306_PackedData", currentByte, 3489, 5, 2),
        //        Rssi_Usr_307_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_307_PackedData", currentByte, 3494, 5, 2),

        //        Rssi_Usr_308_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_308_PackedData", currentByte, 3499, 5, 2),
        //        Rssi_Usr_309_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_309_PackedData", currentByte, 3504, 5, 2),

        //        Rssi_Usr_310_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_310_PackedData", currentByte, 3509, 5, 2),
        //        Rssi_Usr_311_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_311_PackedData", currentByte, 3514, 5, 2),

        //        Rssi_Usr_312_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_312_PackedData", currentByte, 3519, 5, 2),
        //        Rssi_Usr_313_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_313_PackedData", currentByte, 3524, 5, 2),

        //        Rssi_Usr_314_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_314_PackedData", currentByte, 3529, 5, 2),
        //        Rssi_Usr_315_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_315_PackedData", currentByte, 3534, 6, 2),

        //        Rssi_Usr_316_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_316_PackedData", currentByte, 3540, 6, 2),
        //        Rssi_Usr_317_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_317_PackedData", currentByte, 3546, 6, 2),

        //        Rssi_Usr_318_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_318_PackedData", currentByte, 3552, 6, 2),
        //        Rssi_Usr_319_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_319_PackedData", currentByte, 3558, 6, 2),

        //        Rssi_Usr_320_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_320_PackedData", currentByte, 3564, 6, 2),
        //        Rssi_Usr_321_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_321_PackedData", currentByte, 3570, 6, 2),

        //        Rssi_Usr_322_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_322_PackedData", currentByte, 3576, 6, 2),
        //        Rssi_Usr_323_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_323_PackedData", currentByte, 3582, 6, 2),

        //        Rssi_Usr_324_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_324_PackedData", currentByte, 3588, 6, 2),
        //        Rssi_Usr_325_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_325_PackedData", currentByte, 3594, 6, 2),

        //        Rssi_Usr_326_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_326_PackedData", currentByte, 3600, 6, 2),
        //        Rssi_Usr_327_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_327_PackedData", currentByte, 3606, 6, 2),

        //        Rssi_Usr_328_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_328_PackedData", currentByte, 3612, 6, 2),
        //        Rssi_Usr_329_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_329_PackedData", currentByte, 3618, 6, 2),

        //        Rssi_Usr_330_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_330_PackedData", currentByte, 3624, 6, 2),
        //        Rssi_Usr_331_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_331_PackedData", currentByte, 3630, 6, 2),

        //        Rssi_Usr_332_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_332_PackedData", currentByte, 3636, 6, 2),
        //        Rssi_Usr_333_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_333_PackedData", currentByte, 3642, 6, 2),

        //        Rssi_Usr_334_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_334_PackedData", currentByte, 3648, 6, 2),
        //        Rssi_Usr_335_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_335_PackedData", currentByte, 3654, 7, 2),

        //        Rssi_Usr_336_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_336_PackedData", currentByte, 3661, 7, 2),
        //        Rssi_Usr_337_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_337_PackedData", currentByte, 3668, 7, 2),

        //        Rssi_Usr_338_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_338_PackedData", currentByte, 3675, 7, 2),
        //        Rssi_Usr_339_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_339_PackedData", currentByte, 3682, 7, 2),

        //        Rssi_Usr_340_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_340_PackedData", currentByte, 3689, 7, 2),
        //        Rssi_Usr_341_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_341_PackedData", currentByte, 3696, 7, 2),

        //        Rssi_Usr_342_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_342_PackedData", currentByte, 3703, 7, 2),
        //        Rssi_Usr_343_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_343_PackedData", currentByte, 3710, 7, 2),

        //        Rssi_Usr_344_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_344_PackedData", currentByte, 3717, 7, 2),
        //        Rssi_Usr_345_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_345_PackedData", currentByte, 3724, 7, 2),

        //        Rssi_Usr_346_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_346_PackedData", currentByte, 3731, 7, 2),
        //        Rssi_Usr_347_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_347_PackedData", currentByte, 3738, 7, 2),

        //        Rssi_Usr_348_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_348_PackedData", currentByte, 3745, 7, 2),
        //        Rssi_Usr_349_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_349_PackedData", currentByte, 3752, 7, 2),

        //        Rssi_Usr_350_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_350_PackedData", currentByte, 3759, 7, 2),
        //        Rssi_Usr_351_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_351_PackedData", currentByte, 3766, 7, 2),

        //        Rssi_Usr_352_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_352_PackedData", currentByte, 3773, 7, 2),
        //        Rssi_Usr_353_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_353_PackedData", currentByte, 3780, 7, 2),

        //        Rssi_Usr_354_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_354_PackedData", currentByte, 3787, 4, 5),
        //        Rssi_Usr_355_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_355_PackedData", currentByte, 3791, 4, 5),

        //        Rssi_Usr_356_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_356_PackedData", currentByte, 3795, 4, 5),
        //        Rssi_Usr_357_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_357_PackedData", currentByte, 3799, 4, 5),

        //        Rssi_Usr_358_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_358_PackedData", currentByte, 3803, 4, 5),
        //        Rssi_Usr_359_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_359_PackedData", currentByte, 3807, 4, 5),

        //        Rssi_Usr_360_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_360_PackedData", currentByte, 3811, 4, 5),
        //        Rssi_Usr_361_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_361_PackedData", currentByte, 3815, 4, 5),

        //        Rssi_Usr_362_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_362_PackedData", currentByte, 3819, 4, 5),
        //        Rssi_Usr_363_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_363_PackedData", currentByte, 3823, 4, 5),

        //        Rssi_Usr_364_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_364_PackedData", currentByte, 3827, 4, 5),
        //        Rssi_Usr_365_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_365_PackedData", currentByte, 3831, 4, 5),

        //        Rssi_Usr_366_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_366_PackedData", currentByte, 3835, 4, 5),
        //        Rssi_Usr_367_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_367_PackedData", currentByte, 3839, 4, 5),

        //        Rssi_Usr_368_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_368_PackedData", currentByte, 3843, 4, 5),
        //        Rssi_Usr_369_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_369_PackedData", currentByte, 3847, 4, 5),

        //        Rssi_Usr_370_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_370_PackedData", currentByte, 3851, 4, 5),
        //        Rssi_Usr_371_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_371_PackedData", currentByte, 3855, 4, 5),

        //        Rssi_Usr_372_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_372_PackedData", currentByte, 3859, 4, 5),
        //        Rssi_Usr_373_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_373_PackedData", currentByte, 3863, 4, 5),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 3867, 144),

        //    };
        //}

        //// L Multiple Lockbox Record. One record per loan if applicable.
        //public void GetMultiLockboxRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.MultiLockboxRecordModel = new MultiLockboxRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Il_Lkbx_Id_Data = PackedTypeCheckAndUnPackData("Rssi_Il_Lkbx_Id_Data", currentByte, 20, 1),
        //        Rssi_Il_Lkbx_Addr_1 = PackedTypeCheckAndUnPackData("Rssi_Il_Lkbx_Addr_1", currentByte, 21, 35),

        //        Rssi_Il_Lkbx_Addr_2 = PackedTypeCheckAndUnPackData("Rssi_Il_Lkbx_Addr_2", currentByte, 56, 35),
        //        Rssi_Il_Lkbx_City = PackedTypeCheckAndUnPackData("Rssi_Il_Lkbx_City", currentByte, 91, 20),

        //        Rssi_Il_Lkbx_State = PackedTypeCheckAndUnPackData("Rssi_Il_Lkbx_State", currentByte, 111, 2),
        //        Rssi_Il_Lkbx_Zip = PackedTypeCheckAndUnPackData("Rssi_Il_Lkbx_Zip", currentByte, 113, 10),

        //    };
        //}

        //// R Rate Reduction Record. One record per loan if applicable.
        //public void GetRateReductionRecord(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.RateReductionRecordModel = new RateReductionRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Loan_Plan_Nbr = PackedTypeCheckAndUnPackData("Rssi_Loan_Plan_Nbr", currentByte, 20, 6),
        //        Rssi_Loan_Status = PackedTypeCheckAndUnPackData("Rssi_Loan_Status", currentByte, 26, 1),

        //        Rssi_Tot_Red_To_Date = PackedTypeCheckAndUnPackData("Rssi_Tot_Red_To_Date", currentByte, 27, 7, 5),
        //        Rssi_Tot_Tiers_Comp = PackedTypeCheckAndUnPackData("Rssi_Tot_Tiers_Comp", currentByte, 34, 2),

        //        Rssi_Tier_Status = PackedTypeCheckAndUnPackData("Rssi_Tier_Status", currentByte, 36, 1),
        //        Rssi_Disql_Dt = PackedTypeCheckAndUnPackData("Rssi_Disql_Dt", currentByte, 37, 8),

        //        Rssi_Disql_Due_Dt = PackedTypeCheckAndUnPackData("Rssi_Disql_Due_Dt", currentByte, 45, 8),
        //        Rssi_Cpltn_Date = PackedTypeCheckAndUnPackData("Rssi_Cpltn_Date", currentByte, 53, 8),

        //        Rssi_Cpltn_Due_Dt = PackedTypeCheckAndUnPackData("Rssi_Cpltn_Due_Dt", currentByte, 61, 8),
        //        Rssi_Reql_Dt = PackedTypeCheckAndUnPackData("Rssi_Reql_Dt", currentByte, 69, 8),

        //        Rssi_Reql_Due_Dt = PackedTypeCheckAndUnPackData("Rssi_Reql_Due_Dt", currentByte, 77, 8),
        //        Rssi_Total_Rq = PackedTypeCheckAndUnPackData("Rssi_Total_Rq", currentByte, 85, 3),

        //        Rssi_Ot_Pmts_Ctr = PackedTypeCheckAndUnPackData("Rssi_Ot_Pmts_Ctr", currentByte, 88, 2),
        //        Rssi_Rem_Pmts_Ctr = PackedTypeCheckAndUnPackData("Rssi_Rem_Pmts_Ctr", currentByte, 90, 2),

        //        Rssi_New_Rate = PackedTypeCheckAndUnPackData("Rssi_New_Rate", currentByte, 92, 7, 5),
        //        Rssi_New_Pmt = PackedTypeCheckAndUnPackData("Rssi_New_Pmt", currentByte, 99, 7, 2),

        //        Rssi_New_Eff_Dt = PackedTypeCheckAndUnPackData("Rssi_New_Eff_Dt", currentByte, 106, 8),
        //        Rssi_New_Pmt_Diff = PackedTypeCheckAndUnPackData("Rssi_New_Pmt_Diff", currentByte, 114, 9, 2),

        //        Rssi_Reset_Date = PackedTypeCheckAndUnPackData("Rssi_Reset_Date", currentByte, 123, 8),
        //        Rssi_Reset_Due_Dt = PackedTypeCheckAndUnPackData("Rssi_Reset_Due_Dt", currentByte, 131, 8),

        //        Rssi_Beg_Due_Dt = PackedTypeCheckAndUnPackData("Rssi_Beg_Due_Dt", currentByte, 139, 8),
        //        Rssi_Reduct_Amt = PackedTypeCheckAndUnPackData("Rssi_Reduct_Amt", currentByte, 147, 7, 5),


        //    };
        //}

        //// E Escrow Payee Data Record. Multiple records per loan if applicable.
        //public void GetEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{

        //    var escrowRecordModel = new EscrowRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
        //        Rssi_Acnt_Rem = PackedTypeCheckAndUnPackData("Rssi_Acnt_Rem", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
        //        Rssi_Esc_Type = PackedTypeCheckAndUnPackData("Rssi_Esc_Type", currentByte, 20, 2),
        //        Rssi_Ins_Co = PackedTypeCheckAndUnPackData("Rssi_Ins_Co", currentByte, 22, 4),
        //        Rssi_Ins_Ag = PackedTypeCheckAndUnPackData("Rssi_Ins_Ag", currentByte, 26, 5),
        //        Rssi_Payee_Name = PackedTypeCheckAndUnPackData("Rssi_Payee_Name", currentByte, 31, 35),
        //        Rssi_Payee_Phone = PackedTypeCheckAndUnPackData("Rssi_Payee_Phone", currentByte, 66, 11),
        //        Rssi_Prod_Name = PackedTypeCheckAndUnPackData("Rssi_Prod_Name", currentByte, 77, 35),
        //        Rssi_Pymt_Due = PackedTypeCheckAndUnPackData("Rssi_Pymt_Due", currentByte, 112, 11, 2),
        //        Rssi_Num_Due = PackedTypeCheckAndUnPackData("Rssi_Num_Due", currentByte, 123, 2),
        //        Rssi_Esc_Expir_Dt = PackedTypeCheckAndUnPackData("Rssi_Esc_Expir_Dt", currentByte, 125, 6),

        //    };
        //    acc.EscrowRecordModel.Add(escrowRecordModel);
        //}

        //// O Optional Items/Escrow Record. Multiple records per loan if applicable.
        //public void GetOptionalItemEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{

        //    var optionalItemEscrowRecordModel = new OptionalItemEscrowRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
        //        Rssi_Acnt_Rem = PackedTypeCheckAndUnPackData("Rssi_Acnt_Rem", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
        //        Rssi_Oed_Prod_Name = PackedTypeCheckAndUnPackData("Rssi_Oed_Prod_Name", currentByte, 20, 35),
        //        Rssi_Oed_Cur_Amt = PackedTypeCheckAndUnPackData("Rssi_Oed_Cur_Amt", currentByte, 55, 11, 2),
        //        Rssi_Oed_Pend_Amt = PackedTypeCheckAndUnPackData("Rssi_Oed_Pend_Amt", currentByte, 66, 11, 2),
        //        Rssi_Oed_Pend_Date = PackedTypeCheckAndUnPackData("Rssi_Oed_Pend_Date", currentByte, 77, 4),
        //        Rssi_Oed_Prod_Type = PackedTypeCheckAndUnPackData("Rssi_Oed_Prod_Type", currentByte, 81, 2),
        //        Rssi_Oed_Tot_Prem_Due = PackedTypeCheckAndUnPackData("Rssi_Oed_Tot_Prem_Due", currentByte, 83, 7, 2),
        //        Rssi_Oed_Filler = PackedTypeCheckAndUnPackData("Rssi_Oed_Filler", currentByte, 90, 11),

        //    };
        //    acc.OptionalItemEscrowRecordModel.Add(optionalItemEscrowRecordModel);
        //}

        //// F Fee Record. Multiple records per loan if applicable.
        //public void GetFeeRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    var feeRecordModel = new FeeRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acnt_Rem = PackedTypeCheckAndUnPackData("Rssi_Acnt_Rem", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Fd_Fee_Type = PackedTypeCheckAndUnPackData("Rssi_Fd_Fee_Type", currentByte, 20, 3),
        //        Rssi_Fd_Fee_Desc = PackedTypeCheckAndUnPackData("Rssi_Fd_Fee_Desc", currentByte, 23, 23),

        //        Rssi_Fd_Fee_Amort_Pymt = PackedTypeCheckAndUnPackData("Rssi_Fd_Fee_Amort_Pymt", currentByte, 46, 7, 2),
        //        Rssi_Fd_Prev_Fee_Bal = PackedTypeCheckAndUnPackData("Rssi_Fd_Prev_Fee_Bal", currentByte, 53, 7, 2),

        //        Rssi_Fd_Assess_Amt = PackedTypeCheckAndUnPackData("Rssi_Fd_Assess_Amt", currentByte, 60, 7, 2),
        //        Rssi_Fd_Assess_Date = PackedTypeCheckAndUnPackData("Rssi_Fd_Assess_Date", currentByte, 67, 7),

        //        Rssi_Fd_Coll_Assess = PackedTypeCheckAndUnPackData("Rssi_Fd_Coll_Assess", currentByte, 74, 9, 2),
        //        Rssi_Fd_Coll_Non_Assess = PackedTypeCheckAndUnPackData("Rssi_Fd_Coll_Non_Assess", currentByte, 83, 7, 2),

        //        Rssi_Fd_Waived = PackedTypeCheckAndUnPackData("Rssi_Fd_Waived", currentByte, 90, 7, 2),
        //        Rssi_Fd_Curr_Fee_Bal = PackedTypeCheckAndUnPackData("Rssi_Fd_Curr_Fee_Bal", currentByte, 97, 7, 2),

        //        Rssi_Fd_Coll_Date = PackedTypeCheckAndUnPackData("Rssi_Fd_Coll_Date", currentByte, 104, 7),
        //        Rssi_Fd_Waived_Date = PackedTypeCheckAndUnPackData("Rssi_Fd_Waived_Date", currentByte, 111, 7),

        //        Rssi_Fd_Recur_Total_Due = PackedTypeCheckAndUnPackData("Rssi_Fd_Recur_Total_Due", currentByte, 118, 9, 2),
        //        Rssi_Fd_Recur_Pmts_Past_Due = PackedTypeCheckAndUnPackData("Rssi_Fd_Recur_Pmts_Past_Due", currentByte, 127, 2),

        //        Rssi_Fd_Filler2 = PackedTypeCheckAndUnPackData("Rssi_Fd_Filler2", currentByte, 129, 4),
        //        Rssi_Expi_Type = PackedTypeCheckAndUnPackData("Rssi_Expi_Type", currentByte, 133, 1),

        //        Rssi_Expi_Po_No = PackedTypeCheckAndUnPackData("Rssi_Expi_Po_No", currentByte, 134, 12),
        //        Rssi_Expi_Amt_Billed_PackedData = PackedTypeCheckAndUnPackData("Rssi_Expi_Amt_Billed_PackedData", currentByte, 146, 4, 2),

        //        Rssi_Expi_Amt_Paid_PackedData = PackedTypeCheckAndUnPackData("Rssi_Expi_Amt_Paid_PackedData", currentByte, 150, 4, 2),
        //        Rssi_Expi_Rec_Or_Nonrec = PackedTypeCheckAndUnPackData("Rssi_Expi_Rec_Or_Nonrec", currentByte, 154, 1),

        //        Rssi_Expi_Invoice_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Expi_Invoice_Date_PackedData", currentByte, 155, 4),
        //        Rssi_Fee2_Inv_Paid_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fee2_Inv_Paid_Date_PackedData", currentByte, 159, 4),

        //        Rssi_Expi_Vend = PackedTypeCheckAndUnPackData("Rssi_Expi_Vend", currentByte, 163, 7),
        //        Rssi_Expi_Vend_Resp_Cd = PackedTypeCheckAndUnPackData("Rssi_Expi_Vend_Resp_Cd", currentByte, 170, 2),

        //        Rssi_Cinv_Exp_Code_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cinv_Exp_Code_PackedData", currentByte, 172, 2),
        //        Rssi_Cinv_Inv_No = PackedTypeCheckAndUnPackData("Rssi_Cinv_Inv_No", currentByte, 174, 15),

        //        Rssi_Cinv_Area = PackedTypeCheckAndUnPackData("Rssi_Cinv_Area", currentByte, 189, 5),
        //        Rssi_Fd_Filler = PackedTypeCheckAndUnPackData("Rssi_Fd_Filler", currentByte, 194, 207),

        //    };

        //    acc.FeeRecordModel.Add(feeRecordModel);
        //}

        //// S Solicitation Record. One record per loan if applicable.
        //public void GetSolicitationRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.SolicitationRecordModel = new SolicitationRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
        //        Rssi_Campgn_Id = PackedTypeCheckAndUnPackData("Rssi_Campgn_Id", currentByte, 20, 5),
        //        Rssi_Campgncntl = PackedTypeCheckAndUnPackData("Rssi_Campgncntl", currentByte, 25, 3),
        //        Rssi_Campgnmeth = PackedTypeCheckAndUnPackData("Rssi_Campgnmeth", currentByte, 28, 3),

        //    };
        //}

        //// T Transaction Record. Multiple records per loan if applicable.
        //public void GetTransactionRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
            
        //    var transactionRecordModel = new TransactionRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        //Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Acct_No_Packeddata = PackedTypeCheckAndUnPackData("Rssi_Acct_No_Packeddata", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Log_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Log_Date_PackedData", currentByte, 20, 4),
        //        Rssi_Log_Time_PackedData = PackedTypeCheckAndUnPackData("Rssi_Log_Time_PackedData", currentByte, 24, 4),

        //        Rssi_Tr_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Date_PackedData", currentByte, 28, 4),
        //        Rssi_Log_Ptrn = PackedTypeCheckAndUnPackData("Rssi_Log_Ptrn", currentByte, 32, 8),

        //        Rssi_Tr_Fill_01 = PackedTypeCheckAndUnPackData("Rssi_Tr_Fill_01", currentByte, 40, 1),
        //        Rssi_Log_Tran = PackedTypeCheckAndUnPackData("Rssi_Log_Tran", currentByte, 41, 4),

        //        Rssi_Tr_Fill_02 = PackedTypeCheckAndUnPackData("Rssi_Tr_Fill_02", currentByte, 45, 1),
        //        Rssi_Tr_Store_Ovride = PackedTypeCheckAndUnPackData("Rssi_Tr_Store_Ovride", currentByte, 46, 1),

        //        Rssi_Tr_Fill_03 = PackedTypeCheckAndUnPackData("Rssi_Tr_Fill_03", currentByte, 47, 1),
        //        Rssi_Tr_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_PackedData", currentByte, 48, 8, 2),

        //        Rssi_Tr_Cash_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Cash_Amt_PackedData", currentByte, 56, 8, 2),
        //        Rssi_Tr_Teller_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Teller_PackedData", currentByte, 64, 3),

        //        Rssi_Tr_Unap_Cd_Before = PackedTypeCheckAndUnPackData("Rssi_Tr_Unap_Cd_Before", currentByte, 67, 5),
        //        Rssi_Tr_Unap_Cd_After = PackedTypeCheckAndUnPackData("Rssi_Tr_Unap_Cd_After", currentByte, 72, 5),

        //        Rssi_Tr_Amt_To_Prin_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Prin_PackedData", currentByte, 77, 6, 2),
        //        Rssi_Tr_Amt_To_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Int_PackedData", currentByte, 83, 6, 2),

        //        Rssi_Tr_Amt_To_Esc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Esc_PackedData", currentByte, 89, 5, 2),
        //        Rssi_Tr_Amt_To_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Lc_PackedData", currentByte, 94, 5, 2),

        //        Rssi_Tr_Amt_To_Pvar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Pvar_PackedData", currentByte, 99, 5, 2),
        //        Rssi_Tr_Amt_To_Ivar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Ivar_PackedData", currentByte, 104, 4, 2),

        //        Rssi_Tr_Amt_To_Evar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_PackedData", currentByte, 109, 5, 2),
        //        Rssi_Tr_Amt_To_Lvar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Lvar_PackedData", currentByte, 114, 5, 2),

        //        Rssi_Tr_Amt_To_Lip_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Lip_PackedData", currentByte, 119, 5, 2),
        //        Rssi_Tr_Pymt_Ctr_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Pymt_Ctr_PackedData", currentByte, 124, 2),

        //        Rssi_Tr_Amt_To_Cr_Ins_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Cr_Ins_PackedData", currentByte, 126, 5, 2),
        //        Rssi_Tr_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Prin_Bal_PackedData", currentByte, 131, 6, 2),

        //        Rssi_Tr_Esc_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Bal_PackedData", currentByte, 137, 6, 2),
        //        Rssi_Tr_Pd_To_Date_PackedData = (PackedTypeCheckAndUnPackData("Rssi_Tr_Pd_To_Date_PackedData", currentByte, 143, 4)!=null && PackedTypeCheckAndUnPackData("Rssi_Tr_Pd_To_Date_PackedData", currentByte, 143, 4)!= "0000000")? Convert.ToString(CommonHelper.GetDateTime(PackedTypeCheckAndUnPackData("Rssi_Tr_Pd_To_Date_PackedData", currentByte, 143, 4))): "0",

        //        Rssi_Tr_Esc_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Pymt_PackedData", currentByte, 147, 5, 2),
        //        Rssi_Tr_Prn_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Prn_Var_PackedData", currentByte, 152, 5, 2),

        //        Rssi_Tr_Uncoll_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Uncoll_Int_PackedData", currentByte, 157, 6, 2),
        //        Rssi_Tr_Esc_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Var_PackedData", currentByte, 163, 5, 2),

        //        Rssi_Tr_Uncoll_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Uncoll_Lc_PackedData", currentByte, 168, 5, 2),
        //        Rssi_Tr_Dla_PackedData = (PackedTypeCheckAndUnPackData("Rssi_Tr_Dla_PackedData", currentByte, 173, 4)!=null && PackedTypeCheckAndUnPackData("Rssi_Tr_Dla_PackedData", currentByte, 173, 4) != "0000000") ? Convert.ToString(CommonHelper.GetDateTime(PackedTypeCheckAndUnPackData("Rssi_Tr_Dla_PackedData", currentByte, 173, 4))): "0",

        //        Rssi_Tr_Lip_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Lip_Bal_PackedData", currentByte, 177, 5, 2),
        //        Rssi_Tr_Lip_La_Date_PackedData = (PackedTypeCheckAndUnPackData("Rssi_Tr_Lip_La_Date_PackedData", currentByte, 182, 4) !=null && PackedTypeCheckAndUnPackData("Rssi_Tr_Lip_La_Date_PackedData", currentByte, 182, 4)!= "0000000")? Convert.ToString(CommonHelper.GetDateTime(PackedTypeCheckAndUnPackData("Rssi_Tr_Lip_La_Date_PackedData", currentByte, 182, 4))) : "0",

        //        Rssi_Tr_Pre_Int_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Pre_Int_Amt_PackedData", currentByte, 186, 6, 2),
        //        Rssi_Tr_Pre_Int_Date = PackedTypeCheckAndUnPackData("Rssi_Tr_Pre_Int_Date", currentByte, 192, 4),

        //        Rssi_Tr_Amt_To_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Fees_PackedData", currentByte, 196, 6, 2),
        //        Rssi_Tr_Fee_Code = PackedTypeCheckAndUnPackData("Rssi_Tr_Fee_Code", currentByte, 202, 3),

        //        Rssi_Tr_Fee_Desc = PackedTypeCheckAndUnPackData("Rssi_Tr_Fee_Desc", currentByte, 205, 23),
        //        Rssi_Tr_Amt_Negam_Tak_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_Negam_Tak_PackedData", currentByte, 228, 6, 2),

        //        Rssi_Tr_Amt_Negam_Pd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_Negam_Pd_PackedData", currentByte, 234, 6, 2),
        //        Rssi_Tr_Esc_Pay_Id = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Pay_Id", currentByte, 240, 2),

        //        Rssi_Tr_Amort_Fee_Pymt = PackedTypeCheckAndUnPackData("Rssi_Tr_Amort_Fee_Pymt", currentByte, 242, 7, 2),
        //        Rssi_Tr_Amt_To_Evar_2 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_2", currentByte, 249, 9, 2),

        //        Rssi_Tr_Amt_To_Evar_3 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_3", currentByte, 258, 9, 2),
        //        Rssi_Tr_Amt_To_Evar_4 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_4", currentByte, 267, 9, 2),

        //        Rssi_Tr_Amt_To_Evar_5 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_5", currentByte, 276, 9, 2),
        //        Rssi_Tr_Exp_Fee_Code = PackedTypeCheckAndUnPackData("Rssi_Tr_Exp_Fee_Code", currentByte, 285, 3),

        //        Rssi_Tr_Exp_Fee_Desc = PackedTypeCheckAndUnPackData("Rssi_Tr_Exp_Fee_Desc", currentByte, 288, 30),
        //        Rssi_Tr_Exp_Fee_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Exp_Fee_Amt_PackedData", currentByte, 318, 6, 2),

        //        Rssi_Tr_Amt_To_Pi_Shrtg = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Pi_Shrtg", currentByte, 324, 9, 2),
        //        Rssi_Tr_Amt_To_Esc_Short = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Esc_Short", currentByte, 333, 9, 2),

        //        Rssi_Tr_Amt_To_Acrd_Inctv = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Acrd_Inctv", currentByte, 342, 7, 2),
        //        Rssi_Tr_Amt_To_Pra_Remain = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Pra_Remain", currentByte, 349, 11, 2),

        //        Rssi_Tr_Amt_To_Def_Prin_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Prin_PackedData", currentByte, 360, 6, 2),
        //        Rssi_Tr_Def_Prin_Bal_After_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Prin_Bal_After_PackedData", currentByte, 366, 6, 2),

        //        Rssi_Tr_Amt_To_Def_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Int_PackedData", currentByte, 372, 6, 2),
        //        Rssi_Tr_Def_Int_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Int_Bal_Aft_PackedData", currentByte, 378, 6, 2),

        //        Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData", currentByte, 384, 5, 2),
        //        Rssi_Tr_Def_Lt_Chg_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Lt_Chg_Bal_Aft_PackedData", currentByte, 389, 6, 2),

        //        Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData", currentByte, 395, 5, 2),
        //        Rssi_Tr_Def_Esc_Adv_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Esc_Adv_Bal_Aft_PackedData", currentByte, 400, 6, 2),

        //        Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData", currentByte, 406, 6, 2),
        //        Rssi_Tr_Def_Pd_Exp_Adv_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Pd_Exp_Adv_Bal_Aft_PackedData", currentByte, 412, 6, 2),

        //        Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData", currentByte, 418, 6, 2),
        //        Rssi_Tr_Def_Unpexp_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Unpexp_Bal_Aft_PackedData", currentByte, 424, 6, 2),

        //        Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData", currentByte, 430, 6, 2),
        //        Rssi_Tr_Def_Admin_Fees_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Admin_Fees_Bal_Aft_PackedData", currentByte, 436, 6, 2),

        //        Rssi_Tr_Amt_To_Def_Optins_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Optins_PackedData", currentByte, 442, 5, 2),
        //        Rssi_Tr_Def_Optins_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Optins_Bal_Aft_PackedData", currentByte, 447, 6, 2),

        //        Rssi_Tr_Amt_To_Esc_Nt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Esc_Nt_PackedData", currentByte, 453, 6, 2),
        //        Filler_459_1500 = PackedTypeCheckAndUnPackData("Filler_459_1500", currentByte, 459, 1042),

        //    };
        //    acc.TransactionRecordModelList.Add(transactionRecordModel);
        //}

        //// C Foreign Information Record. One record per loan if applicable.
        //public void GetForeignInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.ForeignInformationRecordModel = new ForeignInformationRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Prim_Id_Number = PackedTypeCheckAndUnPackData("Rssi_Prim_Id_Number", currentByte, 20, 15),
        //        Rssi_Primary_Borr_Prefix = PackedTypeCheckAndUnPackData("Rssi_Primary_Borr_Prefix", currentByte, 35, 6),

        //        Rssi_Primary_Borr_Suffix = PackedTypeCheckAndUnPackData("Rssi_Primary_Borr_Suffix", currentByte, 41, 6),
        //        Rssi_Attention = PackedTypeCheckAndUnPackData("Rssi_Attention", currentByte, 47, 35),

        //        Rssi_Prim_Mail_Country = PackedTypeCheckAndUnPackData("Rssi_Prim_Mail_Country", currentByte, 82, 35),
        //        Rssi_Prim_Zip_Code = PackedTypeCheckAndUnPackData("Rssi_Prim_Zip_Code", currentByte, 117, 10),

        //        Rssi_Prim_Home_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Home_Ph_Co", currentByte, 127, 3),
        //        Rssi_Prim_Home_Ph1 = PackedTypeCheckAndUnPackData("Rssi_Prim_Home_Ph1", currentByte, 130, 15),

        //        Rssi_Prim_Work_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Work_Ph_Co", currentByte, 145, 3),
        //        Rssi_Prim_Work_Ph1 = PackedTypeCheckAndUnPackData("Rssi_Prim_Work_Ph1", currentByte, 148, 15),

        //        Rssi_Prim_Fax_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Fax_Ph_Co", currentByte, 163, 3),
        //        Rssi_Prim_Fax_Phone = PackedTypeCheckAndUnPackData("Rssi_Prim_Fax_Phone", currentByte, 166, 15),

        //        Rssi_Prim_Cell_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Cell_Ph_Co", currentByte, 181, 3),
        //        Rssi_Prim_Cell_Ph = PackedTypeCheckAndUnPackData("Rssi_Prim_Cell_Ph", currentByte, 184, 15),

        //        Rssi_Appl_Country = PackedTypeCheckAndUnPackData("Rssi_Appl_Country", currentByte, 199, 35),
        //        Rssi_Appl_Zip_Cd = PackedTypeCheckAndUnPackData("Rssi_Appl_Zip_Cd", currentByte, 234, 10),

        //        Rssi_Altr_Cntry = PackedTypeCheckAndUnPackData("Rssi_Altr_Cntry", currentByte, 244, 35),
        //        Rssi_Altr_Zip_Cd = PackedTypeCheckAndUnPackData("Rssi_Altr_Zip_Cd", currentByte, 279, 10),
        //        Filler_289_500 = PackedTypeCheckAndUnPackData("Filler_289_500", currentByte, 289, 212),

        //    };
        //}

        //// D Blended Rate Information Record. One record per loan if applicable.
        //public void GetBlendedRateInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.BlendedRateInformationRecordModel = new BlendedRateInformationRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_C_Alt_Type_Id = PackedTypeCheckAndUnPackData("Rssi_C_Alt_Type_Id", currentByte, 20, 1),
        //        Rssi_Ml_Alt_Typ_Id = PackedTypeCheckAndUnPackData("Rssi_Ml_Alt_Typ_Id", currentByte, 21, 1),

        //        Rssi_Alt_Chg_Amt1_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt1_PackedData", currentByte, 22, 6, 2),
        //        Rssi_Alt_Chg_Amt2_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt2_PackedData", currentByte, 28, 6, 2),

        //        Rssi_Alt_Chg_Amt3_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt3_PackedData", currentByte, 34, 6, 2),
        //        Rssi_Alt_Chg_Amt4_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt4_PackedData", currentByte, 40, 6, 2),

        //        Rssi_Alt_Pymt1_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt1_PackedData", currentByte, 46, 6, 2),
        //        Rssi_Alt_Pymt2_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt2_PackedData", currentByte, 52, 6, 2),

        //        Rssi_Alt_Pymt3_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt3_PackedData", currentByte, 58, 6, 2),
        //        Rssi_Alt_Pymt4_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt4_PackedData", currentByte, 64, 6, 2),

        //        Rssi_Alt_B_A_Rt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_A_Rt_PackedData", currentByte, 70, 4, 5),
        //        Rssi_Alt_B_F_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_F_Rate_PackedData", currentByte, 74, 4, 5),

        //        Rssi_Alt_Ar_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Ar_Rate_PackedData", currentByte, 78, 4, 5),
        //        Rssi_Alt_Fr_Rate = PackedTypeCheckAndUnPackData("Rssi_Alt_Fr_Rate_PackedData", currentByte, 82, 4, 5),

        //        Rssi_Alt_B_Rate_Flag = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Rate_Flag", currentByte, 86, 1),
        //        Rssi_Alt_B_Rt_Mgn_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Rt_Mgn_PackedData", currentByte, 87, 4, 5),

        //        Rssi_Alt_B_Rt_Term_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Rt_Term_PackedData", currentByte, 91, 2),
        //        Rssi_Alt_Adj_Pct_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Adj_Pct_PackedData", currentByte, 93, 4, 5),

        //        Rssi_Alt_Fix_Pct_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Fix_Pct_PackedData", currentByte, 97, 4, 5),
        //        Rssi_Alt_B_Opt_Flag = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Opt_Flag", currentByte, 101, 1),

        //        Rssi_Alt_B_Opt_Curr_Fix = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Opt_Curr_Fix", currentByte, 102, 11, 2),
        //        Rssi_Alt_B_Curr_Adj = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Curr_Adj", currentByte, 113, 11, 2),
        //        FILLER_124_400 = PackedTypeCheckAndUnPackData("FILLER_124_400", currentByte, 124, 277),
        //    };
        //}


        ////  I Co-borrower Record. One record per loan if applicable.
        //public void GetCoBorrowerRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.CoBorrowerRecordModel = new CoBorrowerRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Cb_Cbwr1_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_F", currentByte, 20, 35),
        //        Rssi_Cb_Cbwr1_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Adrs1", currentByte, 55, 35),

        //        Rssi_Cb_Cbwr1_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Adrs2", currentByte, 90, 35),
        //        Rssi_Cb_Cbwr1_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_City", currentByte, 125, 21),

        //        Rssi_Cb_Cbwr1_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_State", currentByte, 146, 2),
        //        Rssi_Cb_Cbwr1_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Zip", currentByte, 148, 10),

        //        Rssi_Cb_Cbwr1_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Bill_Stmnt", currentByte, 158, 1),
        //        Rssi_Cb_Cbwr2_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_F", currentByte, 159, 35),

        //        Rssi_Cb_Cbwr2_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Adrs1", currentByte, 194, 35),
        //        Rssi_Cb_Cbwr2_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Adrs2", currentByte, 229, 35),

        //        Rssi_Cb_Cbwr2_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_City", currentByte, 264, 21),
        //        Rssi_Cb_Cbwr2_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_State", currentByte, 285, 2),

        //        Rssi_Cb_Cbwr2_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Zip", currentByte, 287, 10),
        //        Rssi_Cb_Cbwr2_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Bill_Stmnt", currentByte, 297, 1),

        //        Rssi_Cb_Cbwr3_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_F", currentByte, 298, 35),
        //        Rssi_Cb_Cbwr3_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Adrs1", currentByte, 333, 35),

        //        Rssi_Cb_Cbwr3_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Adrs2", currentByte, 368, 35),
        //        Rssi_Cb_Cbwr3_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_City", currentByte, 403, 21),

        //        Rssi_Cb_Cbwr3_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_State", currentByte, 424, 2),
        //        Rssi_Cb_Cbwr3_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Zip", currentByte, 426, 10),

        //        Rssi_Cb_Cbwr3_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Bill_Stmnt", currentByte, 436, 1),
        //        Rssi_Cb_Cbwr4_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_F", currentByte, 437, 35),

        //        Rssi_Cb_Cbwr4_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Adrs1", currentByte, 472, 35),
        //        Rssi_Cb_Cbwr4_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Adrs2", currentByte, 507, 35),

        //        Rssi_Cb_Cbwr4_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_City", currentByte, 542, 21),
        //        Rssi_Cb_Cbwr4_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_State", currentByte, 563, 2),

        //        Rssi_Cb_Cbwr4_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Zip", currentByte, 565, 10),
        //        Rssi_Cb_Cbwr4_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Bill_Stmnt", currentByte, 575, 1),

        //        Rssi_Cb_Cbwr5_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_F", currentByte, 576, 35),
        //        Rssi_Cb_Cbwr5_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Adrs1", currentByte, 611, 35),

        //        Rssi_Cb_Cbwr5_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Adrs2", currentByte, 646, 35),
        //        Rssi_Cb_Cbwr5_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_City", currentByte, 681, 21),

        //        Rssi_Cb_Cbwr5_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_State", currentByte, 702, 2),
        //        Rssi_Cb_Cbwr5_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Zip", currentByte, 704, 10),

        //        Rssi_Cb_Cbwr5_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Bill_Stmnt", currentByte, 714, 1),
        //        Rssi_Cb_Cbwr6_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_F", currentByte, 715, 35),

        //        Rssi_Cb_Cbwr6_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Adrs1", currentByte, 750, 35),
        //        Rssi_Cb_Cbwr6_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Adrs2", currentByte, 785, 35),

        //        Rssi_Cb_Cbwr6_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_City", currentByte, 820, 21),
        //        Rssi_Cb_Cbwr6_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_State", currentByte, 841, 2),

        //        Rssi_Cb_Cbwr6_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Zip", currentByte, 843, 10),
        //        Rssi_Cb_Cbwr6_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Bill_Stmnt", currentByte, 853, 1),

        //        Rssi_Cb_Cbwr7_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_F", currentByte, 854, 35),
        //        Rssi_Cb_Cbwr7_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Adrs1", currentByte, 889, 35),

        //        Rssi_Cb_Cbwr7_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Adrs2", currentByte, 924, 35),
        //        Rssi_Cb_Cbwr7_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_City", currentByte, 959, 21),

        //        Rssi_Cb_Cbwr7_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_State", currentByte, 980, 2),
        //        Rssi_Cb_Cbwr7_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Zip", currentByte, 982, 10),

        //        Rssi_Cb_Cbwr7_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Bill_Stmnt", currentByte, 992, 1),
        //        Rssi_Cb_Cbwr8_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_F", currentByte, 993, 35),

        //        Rssi_Cb_Cbwr8_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Adrs1", currentByte, 1028, 35),
        //        Rssi_Cb_Cbwr8_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Adrs2", currentByte, 1063, 35),

        //        Rssi_Cb_Cbwr8_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_City", currentByte, 1098, 21),
        //        Rssi_Cb_Cbwr8_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_State", currentByte, 1119, 2),

        //        Rssi_Cb_Cbwr8_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Zip", currentByte, 1121, 10),
        //        Rssi_Cb_Cbwr8_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Bill_Stmnt", currentByte, 1131, 1),

        //        Rssi_Cb_Cbwr9_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_F", currentByte, 1132, 35),
        //        Rssi_Cb_Cbwr9_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Adrs1", currentByte, 1167, 35),

        //        Rssi_Cb_Cbwr9_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Adrs2", currentByte, 1202, 35),
        //        Rssi_Cb_Cbwr9_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_City", currentByte, 1237, 21),

        //        Rssi_Cb_Cbwr9_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_State", currentByte, 1258, 2),
        //        Rssi_Cb_Cbwr9_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Zip", currentByte, 1260, 10),

        //        Rssi_Cb_Cbwr9_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Bill_Stmnt", currentByte, 1270, 1),
        //        Rssi_Cb_Cbwr10_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_F", currentByte, 1271, 35),

        //        Rssi_Cb_Cbwr10_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Adrs1", currentByte, 1306, 35),
        //        Rssi_Cb_Cbwr10_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Adrs2", currentByte, 1341, 35),

        //        Rssi_Cb_Cbwr10_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_City", currentByte, 1376, 21),
        //        Rssi_Cb_Cbwr10_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_State", currentByte, 1397, 2),

        //        Rssi_Cb_Cbwr10_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Zip", currentByte, 1399, 10),
        //        Rssi_Cb_Cbwr10_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Bill_Stmnt", currentByte, 1409, 1),

        //        Rssi_Cb_Cbwr1_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Corr_Flag", currentByte, 1410, 1),
        //        Rssi_Cb_Cbwr2_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Corr_Flag", currentByte, 1411, 1),

        //        Rssi_Cb_Cbwr3_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Corr_Flag", currentByte, 1412, 1),
        //        Rssi_Cb_Cbwr4_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Corr_Flag", currentByte, 1413, 1),

        //        Rssi_Cb_Cbwr5_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Corr_Flag", currentByte, 1414, 1),
        //        Rssi_Cb_Cbwr6_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Corr_Flag", currentByte, 1415, 1),

        //        Rssi_Cb_Cbwr7_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Corr_Flag", currentByte, 1416, 1),
        //        Rssi_Cb_Cbwr8_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Corr_Flag", currentByte, 1417, 1),

        //        Rssi_Cb_Cbwr9_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Corr_Flag", currentByte, 1418, 1),
        //        Rssi_Cb_Cbwr10_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Corr_Flag", currentByte, 1419, 1),

        //        Rssi_Cb_Cbwr1_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Typ", currentByte, 1420, 1),
        //        Rssi_Csii_Cbwr1_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr1_Verified", currentByte, 1421, 1),

        //        Rssi_Cb_Cbwr2_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Typ", currentByte, 1422, 1),
        //        Rssi_Csii_Cbwr2_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr2_Verified", currentByte, 1423, 1),

        //        Rssi_Cb_Cbwr3_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Typ", currentByte, 1424, 1),
        //        Rssi_Csii_Cbwr3_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr3_Verified", currentByte, 1425, 1),

        //        Rssi_Cb_Cbwr4_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Typ", currentByte, 1426, 1),
        //        Rssi_Csii_Cbwr4_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr4_Verified", currentByte, 1427, 1),

        //        Rssi_Cb_Cbwr5_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Typ", currentByte, 1428, 1),
        //        Rssi_Csii_Cbwr5_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr5_Verified", currentByte, 1429, 1),

        //        Rssi_Cb_Cbwr6_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Typ", currentByte, 1430, 1),
        //        Rssi_Csii_Cbwr6_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr6_Verified", currentByte, 1431, 1),

        //        Rssi_Cb_Cbwr7_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Typ", currentByte, 1432, 1),
        //        Rssi_Csii_Cbwr7_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr7_Verified", currentByte, 1433, 1),

        //        Rssi_Cb_Cbwr8_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Typ", currentByte, 1434, 1),
        //        Rssi_Csii_Cbwr8_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr8_Verified", currentByte, 1435, 1),

        //        Rssi_Cb_Cbwr9_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Typ", currentByte, 1436, 1),
        //        Rssi_Csii_Cbwr9_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr9_Verified", currentByte, 1437, 1),

        //        Rssi_Cb_Cbwr10_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Typ", currentByte, 1438, 1),
        //        Rssi_Csii_Cbwr10_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr10_Verified", currentByte, 1439, 1),

        //        Rssi_Cb_Cbwr_Email_Bill_Ind_1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_1", currentByte, 1440, 1),
        //        Rssi_Cb_Cbwr_Email_Bill_Ind_2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_2", currentByte, 1441, 1),

        //        Rssi_Cb_Cbwr_Email_Bill_Ind_3 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_3", currentByte, 1442, 1),
        //        Rssi_Cb_Cbwr_Email_Bill_Ind_4 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_4", currentByte, 1443, 1),

        //        Rssi_Cb_Cbwr_Email_Bill_Ind_5 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_5", currentByte, 1444, 1),
        //        Rssi_Cb_Cbwr_Email_Bill_Ind_6 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_6", currentByte, 1445, 1),

        //        Rssi_Cb_Cbwr_Email_Bill_Ind_7 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_7", currentByte, 1446, 1),
        //        Rssi_Cb_Cbwr_Email_Bill_Ind_8 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_8", currentByte, 1447, 1),

        //        Rssi_Cb_Cbwr_Email_Bill_Ind_9 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_9", currentByte, 1448, 1),
        //        Rssi_Cb_Cbwr_Email_Bill_Ind_10 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_10", currentByte, 1449, 1),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 1450, 2561),

        //    };
        //}

        //// < Late Charge Information Record. One record per loan if applicable.
        //public void GetLateChargeInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.LateChargeInformationRecordModel = new LateChargeInformationRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Lci_Pymt_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Pymt_Due_Dt_PackedData", currentByte, 20, 4),
        //        Rssi_Lci_Code = PackedTypeCheckAndUnPackData("Rssi_Lci_Code", currentByte, 24, 1),

        //        Rssi_Lci_Ind = PackedTypeCheckAndUnPackData("Rssi_Lci_Ind", currentByte, 25, 1),
        //        Rssi_Lci_Ptd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Ptd_PackedData", currentByte, 26, 4),

        //        Rssi_Lci_Coll_Meth = PackedTypeCheckAndUnPackData("Rssi_Lci_Coll_Meth", currentByte, 30, 1),
        //        Rssi_Lci_Factor_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Factor_PackedData", currentByte, 31, 3, 2),

        //        Rssi_Lci_Assess_Meth = PackedTypeCheckAndUnPackData("Rssi_Lci_Assess_Meth", currentByte, 34, 1),
        //        Rssi_Lci_Max_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Max_PackedData", currentByte, 35, 4, 2),

        //        Rssi_Lci_Min_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Min_PackedData", currentByte, 39, 4, 2),
        //        Rssi_Lci_Max_Annual_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Max_Annual_PackedData", currentByte, 43, 5, 2),

        //        Rssi_Lci_Max_Life_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Max_Life_PackedData", currentByte, 48, 5, 2),
        //        Rssi_Lci_Counter_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Counter_PackedData", currentByte, 53, 2),

        //        Rssi_Lci_Freeze_To_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Freeze_To_Dt_PackedData", currentByte, 55, 4),
        //        Rssi_Lci_Freeze_From_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Freeze_From_Dt_PackedData", currentByte, 59, 4),

        //        Rssi_Lci_Freeze_Dt_Type = PackedTypeCheckAndUnPackData("Rssi_Lci_Freeze_Dt_Type", currentByte, 63, 1),
        //        Rssi_Lci_Year_Type_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Year_Type_PackedData", currentByte, 64, 2),

        //        Rssi_Lci_Assesed_Lfe_To_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Assesed_Lfe_To_Dt_PackedData", currentByte, 66, 5, 2),
        //        Rssi_Lci_Assessed_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Assessed_Ytd_PackedData", currentByte, 71, 5, 2),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 76, 130),

        //    };
        //}

        //// - Late Charge Detail Record.One record per loan if applicable.
        //public void GetLateChargeDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.LateChargeDetailRecordModel = new LateChargeDetailRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Lcd_Pymt_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Pymt_Due_Dt_PackedData", currentByte, 20, 4),
        //        Rssi_Lcd_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Due_Dt_PackedData", currentByte, 24, 4),

        //        Rssi_Lcd_Calc_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Calc_Dt_PackedData", currentByte, 28, 4),
        //        Rssi_Lcd_Amt_For_Lc_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Amt_For_Lc_Due_Dt_PackedData", currentByte, 32, 5, 2),

        //        Rssi_Lcd_Pd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Pd_Dt_PackedData", currentByte, 37, 4),
        //        Rssi_Lcd_Factor_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Factor_PackedData", currentByte, 41, 3, 3),

        //        Rssi_Lcd_Calc_Meth = PackedTypeCheckAndUnPackData("Rssi_Lcd_Calc_Meth", currentByte, 44, 1),
        //        Rssi_Lcd_Waiver_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Waiver_Dt_PackedData", currentByte, 45, 4),

        //        Rssi_Lcd_Waiver_Cd = PackedTypeCheckAndUnPackData("Rssi_Lcd_Waiver_Cd", currentByte, 49, 1),
        //        Rssi_Lcd_Rev_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Rev_Dt_PackedData", currentByte, 50, 4),

        //        Rssi_Lcd_Paid_Amt = PackedTypeCheckAndUnPackData("Rssi_Lcd_Paid_Amt", currentByte, 54, 5, 2),
        //        Rssi_Lcd_Waive_Amt = PackedTypeCheckAndUnPackData("Rssi_Lcd_Waive_Amt", currentByte, 59, 5, 2),

        //        Rssi_Lcd_Rev_Amt = PackedTypeCheckAndUnPackData("Rssi_Lcd_Rev_Amt", currentByte, 64, 5, 2),
        //        Rssi_Lcd_Lc_Adj_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Lc_Adj_Dt_PackedData", currentByte, 69, 4),
        //        Rssi_Lcd_Lc_Adj_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Lc_Adj_Amt_PackedData", currentByte, 73, 5, 2),

        //        Rssi_Lcd_Rem_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Rem_Bal_PackedData", currentByte, 78, 5, 2),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 83, 123),

        //    };
        //}

        //// J Active Bankruptcy Information Record. One record per loan if applicable.
        //public void GetActiveBankruptcyInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.ActiveBankruptcyInformationRecordModel = new ActiveBankruptcyInformationRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_B_Type = PackedTypeCheckAndUnPackData("Rssi_B_Type", currentByte, 20, 1),
        //        Rssi_B_Chap = PackedTypeCheckAndUnPackData("Rssi_B_Chap", currentByte, 21, 2),

        //        Rssi_B_Case_No = PackedTypeCheckAndUnPackData("Rssi_B_Case_No", currentByte, 23, 12),
        //        Rssi_B_Filed_By = PackedTypeCheckAndUnPackData("Rssi_B_Filed_By", currentByte, 35, 1),

        //        Rssi_B_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_Debtor", currentByte, 36, 35),
        //        Rssi_B_Co_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_Co_Debtor", currentByte, 71, 35),

        //        Rssi_B_Filed_Cbwr1_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr1_Id", currentByte, 106, 1),
        //        Rssi_B_Filed_Cbwr2_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr2_Id", currentByte, 107, 1),

        //        Rssi_B_Filed_Cbwr3_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr3_Id", currentByte, 108, 1),
        //        Rssi_B_Filed_Cbwr4_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr4_Id", currentByte, 109, 1),

        //        Rssi_B_Filed_Cbwr5_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr5_Id", currentByte, 110, 1),
        //        Rssi_B_Filed_Cbwr6_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr6_Id", currentByte, 111, 1),

        //        Rssi_B_Filed_Cbwr7_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr7_Id", currentByte, 112, 1),
        //        Rssi_B_Filed_Cbwr8_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr8_Id", currentByte, 113, 1),

        //        Rssi_B_Filed_Cbwr9_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr9_Id", currentByte, 114, 1),
        //        Rssi_B_Filed_Cbwr10_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr10_Id", currentByte, 115, 1),

        //        Rssi_B_Filed_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Dt_PackedData", currentByte, 116, 4),
        //        Rssi_B_Conv_1_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Conv_1_Date_PackedData", currentByte, 120, 4),

        //        Rssi_B_Reaffirm_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Reaffirm_Dt_PackedData", currentByte, 124, 4),
        //        Rssi_B_Dschg_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Dschg_Dt_PackedData", currentByte, 128, 4),

        //        Rssi_B_Dsmsd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Dsmsd_Dt_PackedData", currentByte, 132, 4),
        //        Rssi_B_Relief_1_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Relief_1_Dt_PackedData", currentByte, 136, 4),

        //        Rssi_B_C_Type = PackedTypeCheckAndUnPackData("Rssi_B_C_Type", currentByte, 140, 1),
        //        Rssi_B_C_Chap = PackedTypeCheckAndUnPackData("Rssi_B_C_Chap", currentByte, 141, 2),

        //        Rssi_B_C_Case_No = PackedTypeCheckAndUnPackData("Rssi_B_C_Case_No", currentByte, 143, 12),
        //        Rssi_B_C_Filed_By = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_By", currentByte, 155, 1),

        //        Rssi_B_C_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_C_Debtor", currentByte, 156, 25),
        //        Rssi_B_C_Co_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_C_Co_Debtor", currentByte, 181, 25),

        //        Rssi_B_C_Filed_Cbwr1_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr1_Id", currentByte, 206, 1),
        //        Rssi_B_C_Filed_Cbwr2_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr2_Id", currentByte, 207, 1),

        //        Rssi_B_C_Filed_Cbwr3_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr3_Id", currentByte, 208, 1),
        //        Rssi_B_C_Filed_Cbwr4_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr4_Id", currentByte, 209, 1),

        //        Rssi_B_C_Filed_Cbwr5_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr5_Id", currentByte, 210, 1),
        //        Rssi_B_C_Filed_Cbwr6_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr6_Id", currentByte, 211, 1),

        //        Rssi_B_C_Filed_Cbwr7_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr7_Id", currentByte, 212, 1),
        //        Rssi_B_C_Filed_Cbwr8_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr8_Id", currentByte, 213, 1),

        //        Rssi_B_C_Filed_Cbwr9_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr9_Id", currentByte, 214, 1),
        //        Rssi_B_C_Filed_Cbwr10_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr10_Id", currentByte, 215, 1),

        //        Rssi_B_C_Filed_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Dt_PackedData", currentByte, 216, 4),
        //        Rssi_B_C_Conv_1_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Conv_1_Date_PackedData", currentByte, 220, 4),

        //        Rssi_B_C_Reaffirm_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Reaffirm_Dt_PackedData", currentByte, 224, 4),
        //        Rssi_B_C_Dschg_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Dschg_Dt_PackedData", currentByte, 228, 4),

        //        Rssi_B_C_Dsmsd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Dsmsd_Dt_PackedData", currentByte, 232, 4),
        //        Rssi_B_C_Relf_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Relf_Dt_PackedData", currentByte, 236, 4),

        //        Rssi_Poc_Post_Amt_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Amt_Due_PackedData", currentByte, 240, 6, 2),
        //        Rssi_Poc_Post_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Lc_PackedData", currentByte, 246, 5, 2),

        //        Rssi_Poc_Total_Rec_Bkr_Pre_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Total_Rec_Bkr_Pre_PackedData", currentByte, 251, 5, 2),
        //        Rssi_Poc_Post_Pet_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Pet_Fees_PackedData", currentByte, 256, 5, 2),

        //        Rssi_Poc_Amt_Paid_By_Pet_Last_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Amt_Paid_By_Pet_Last_PackedData", currentByte, 261, 5, 2),
        //        Rssi_Poc_Pre_Pet_Arrearage_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Pet_Arrearage_PackedData", currentByte, 266, 5, 2),

        //        Rssi_Poc_Statement_Flag = PackedTypeCheckAndUnPackData("Rssi_Poc_Statement_Flag", currentByte, 271, 1),
        //        Rssi_Vend_Name1 = PackedTypeCheckAndUnPackData("Rssi_Vend_Name1", currentByte, 272, 35),

        //        Rssi_Vend_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Vend_Adrs1", currentByte, 307, 35),
        //        Rssi_Vend_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Vend_Adrs2", currentByte, 342, 35),

        //        Rssi_Vend_City = PackedTypeCheckAndUnPackData("Rssi_Vend_City", currentByte, 377, 21),
        //        Rssi_Vend_State = PackedTypeCheckAndUnPackData("Rssi_Vend_State", currentByte, 398, 2),

        //        Rssi_Vend_Zip = PackedTypeCheckAndUnPackData("Rssi_Vend_Zip", currentByte, 400, 10),
        //        Rssi_Poc_Pre_Suspense_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Suspense_PackedData", currentByte, 410, 6, 2),

        //        Rssi_Poc_Post_Suspense_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Suspense_PackedData", currentByte, 416, 6, 2),
        //        Rssi_Brpy_Unapp_Paid_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Unapp_Paid_PackedData", currentByte, 422, 6, 2),

        //        Rssi_Brpy_Plan_Next_Pmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Plan_Next_Pmt_PackedData", currentByte, 428, 5, 2),
        //        Rssi_Brpy_Plan_Due_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Plan_Due_Date_PackedData", currentByte, 433, 4),

        //        Rssi_Fbr_B_Cramdown_Flag = PackedTypeCheckAndUnPackData("Rssi_Fbr_B_Cramdown_Flag", currentByte, 437, 1),
        //        Rssi_Poc_Post_Pet_Unpaid_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Pet_Unpaid_PackedData", currentByte, 438, 5, 2),

        //        Rssi_Poc_Bk_Discharged = PackedTypeCheckAndUnPackData("Rssi_Poc_Bk_Discharged", currentByte, 443, 1),
        //        Rssi_Poc_Post_Shortfall_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Shortfall_PackedData", currentByte, 444, 6, 2),

        //        Rssi_Brpy_Short_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Short_Bal_PackedData", currentByte, 450, 6, 2),
        //        Rssi_Poc_Pre_Due_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Due_Date_PackedData", currentByte, 456, 4),

        //        Rssi_Poc_Pre_Payment_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Payment_PackedData", currentByte, 460, 6, 2),
        //        Rssi_Poc_Plan_Shortfall_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Plan_Shortfall_PackedData", currentByte, 466, 6, 2),

        //        Rssi_Poc_Post_Due_Date = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Due_Date", currentByte, 472, 8),
        //        Rssi_Poc_Post_Payment_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Payment_PackedData", currentByte, 480, 6, 2),

        //        Rssi_Post_Lc_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Post_Lc_Amt_PackedData", currentByte, 486, 4, 2),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 490, 511),

        //    };
        //}

        //// K Archived Bankruptcy Information Record. Multiple records per loan if applicable.
        //public void GetArchivedBankruptcyDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    var archivedBankruptcyDetailRecordModel = new ArchivedBankruptcyDetailRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
        //        Rssi_K_B_Type = PackedTypeCheckAndUnPackData("Rssi_K_B_Type", currentByte, 20, 1),
        //        Rssi_K_B_Chap = PackedTypeCheckAndUnPackData("Rssi_K_B_Chap", currentByte, 21, 2),
        //        Rssi_K_B_Case_No = PackedTypeCheckAndUnPackData("Rssi_K_B_Case_No", currentByte, 23, 12),
        //        Rssi_K_B_Filed_By = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_By", currentByte, 35, 1),
        //        Rssi_K_B_Debtor = PackedTypeCheckAndUnPackData("Rssi_K_B_Debtor", currentByte, 36, 35),
        //        Rssi_K_B_Co_Debtor = PackedTypeCheckAndUnPackData("Rssi_K_B_Co_Debtor", currentByte, 71, 35),
        //        Rssi_K_B_Filed_Cbwr1_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr1_Id", currentByte, 106, 1),
        //        Rssi_K_B_Filed_Cbwr2_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr2_Id", currentByte, 107, 1),
        //        Rssi_K_B_Filed_Cbwr3_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr3_Id", currentByte, 108, 1),
        //        Rssi_K_B_Filed_Cbwr4_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr4_Id", currentByte, 109, 1),
        //        Rssi_K_B_Filed_Cbwr5_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr5_Id", currentByte, 110, 1),
        //        Rssi_K_B_Filed_Cbwr6_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr6_Id", currentByte, 111, 1),
        //        Rssi_K_B_Filed_Cbwr7_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr7_Id", currentByte, 112, 1),
        //        Rssi_K_B_Filed_Cbwr8_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr8_Id", currentByte, 113, 1),
        //        Rssi_K_B_Filed_Cbwr9_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr9_Id", currentByte, 114, 1),
        //        Rssi_K_B_Filed_Cbwr10_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr10_Id", currentByte, 115, 1),
        //        Rssi_K_B_Filed_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Dt_PackedData", currentByte, 116, 4),
        //        Rssi_K_B_Conv_1_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Conv_1_Date_PackedData", currentByte, 120, 4),
        //        Rssi_K_B_Reaffirm_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Reaffirm_Dt_PackedData", currentByte, 124, 4),
        //        Rssi_K_B_Dschg_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Dschg_Dt_PackedData", currentByte, 128, 4),
        //        Rssi_K_B_Dsmsd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Dsmsd_Dt_PackedData", currentByte, 132, 4),
        //        Rssi_K_B_Relief_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Relief_Dt_PackedData", currentByte, 136, 4),
        //        Rssi_K_Poc_Statement_Flag = PackedTypeCheckAndUnPackData("Rssi_K_Poc_Statement_Flag", currentByte, 140, 1),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 141, 160),

        //    };
        //    acc.ArchivedBankruptcyDetailRecordModel.Add(archivedBankruptcyDetailRecordModel);
        //}

        //// X Email Addresses Record
        //public void GetEmailAddressRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.EmailAddressRecordModel = new EmailAddressRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
        //        Rssi_Info_Primary_Email_Adr = PackedTypeCheckAndUnPackData("Rssi_Info_Primary_Email_Adr", currentByte, 20, 60),
        //        Rssi_Info_Scnd_Email_Adr = PackedTypeCheckAndUnPackData("Rssi_Info_Scnd_Email_Adr", currentByte, 80, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_1 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_1", currentByte, 140, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_2 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_2", currentByte, 200, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_3 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_3", currentByte, 260, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_4 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_4", currentByte, 320, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_5 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_5", currentByte, 380, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_6 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_6", currentByte, 440, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_7 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_7", currentByte, 500, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_8 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_8", currentByte, 560, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_9 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_9", currentByte, 620, 60),
        //        Rssi_Info_E_Stmt_Email_Adr_10 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_10", currentByte, 680, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_1", currentByte, 740, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_2", currentByte, 800, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_3 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_3", currentByte, 860, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_4 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_4", currentByte, 920, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_5 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_5", currentByte, 980, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_6 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_6", currentByte, 1040, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_7 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_7", currentByte, 1100, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_8 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_8", currentByte, 1160, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_9 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_9", currentByte, 1220, 60),
        //        Rssi_Cb_Cbwr_Email_Adr_10 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_10", currentByte, 1280, 60),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 1340, 2671),

        //    };
        //}

        //// 3 Disaster Tracking Record
        //public void GetDisasterTrackingRecordModel(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.DisasterTrackingRecordModel = new DisasterTrackingRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Dstr_Occ_Num = PackedTypeCheckAndUnPackData("Rssi_Dstr_Occ_Num", currentByte, 20, 3),
        //        Rssi_Dstr_Status = PackedTypeCheckAndUnPackData("Rssi_Dstr_Status", currentByte, 23, 1),

        //        Rssi_Dstr_Disaster_Name = PackedTypeCheckAndUnPackData("Rssi_Dstr_Disaster_Name", currentByte, 24, 35),
        //        Rssi_Dstr_Type = PackedTypeCheckAndUnPackData("Rssi_Dstr_Type", currentByte, 59, 2),

        //        Rssi_Dstr_Desig_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Desig_Dt_PackedData", currentByte, 61, 4),
        //        Rssi_Dstr_End_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_End_Dt_PackedData", currentByte, 65, 4),

        //        Rssi_Dstr_Extended_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Extended_Dt_PackedData", currentByte, 69, 4),
        //        Rssi_Dstr_Ddn = PackedTypeCheckAndUnPackData("Rssi_Dstr_Ddn", currentByte, 73, 10),

        //        Rssi_Dstr_Aplcnt_Nbr = PackedTypeCheckAndUnPackData("Rssi_Dstr_Aplcnt_Nbr", currentByte, 83, 10),
        //        Rssi_Dstr_Prop_Impact_Determine = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Impact_Determine", currentByte, 93, 1),

        //        Rssi_Dstr_Prop_Determine_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Determine_Dt_PackedData", currentByte, 94, 4),
        //        Rssi_Dstr_Prop_Resolution_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Resolution_Dt_PackedData", currentByte, 98, 4),

        //        Rssi_Dstr_Prop_Impact_Severity = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Impact_Severity", currentByte, 102, 1),
        //        Rssi_Dstr_Wrkp_Impact_Determine = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Impact_Determine", currentByte, 103, 1),

        //        Rssi_Dstr_Wrkp_Determine_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Determine_Dt_PackedData", currentByte, 104, 4),
        //        Rssi_Dstr_Wrkp_Resolution_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Resolution_Dt_PackedData", currentByte, 108, 4),

        //        Rssi_Dstr_Wrkp_Impact_Severity = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Impact_Severity", currentByte, 112, 1),
        //        Rssi_Dstr_Attempt_Contact = PackedTypeCheckAndUnPackData("Rssi_Dstr_Attempt_Contact", currentByte, 113, 1),

        //        Rssi_Dstr_Attempt_Contact_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Attempt_Contact_Dt_PackedData", currentByte, 114, 4),
        //        Rssi_Dstr_Contact_Made = PackedTypeCheckAndUnPackData("Rssi_Dstr_Contact_Made", currentByte, 118, 1),

        //        Rssi_Dstr_Contact_Made_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Dstr_Contact_Made_Dt_PackedData", currentByte, 119, 4),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 123, 78),
        //    };
        //}

        //// 4 RHCDS Only Record(Only created if RHCDS Option (DB-2: I-RHCDS-OPT) =‘Y’)
        //public void GetRHCDRecords(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.RHCDSOnlyRecordModel = new RHCDSOnlyRecordModel()
        //    {
        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Rhcds_Aa_Expir_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Aa_Expir_Date_PackedData", currentByte, 20, 4),
        //        Rssi_Subsidy_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Subsidy_Paid_Ytd_PackedData", currentByte, 24, 5, 2),

        //        Rssi_Rhcds_Morat_Eff_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Morat_Eff_Dt_PackedData", currentByte, 29, 4),
        //        Rssi_Rhcds_Morat_Flag = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Morat_Flag", currentByte, 33, 1),

        //        Rssi_Rhcds_Morat_Expir_St_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Morat_Expir_St_PackedData", currentByte, 34, 4),
        //        Rssi_Ml_Notice_Ctl = PackedTypeCheckAndUnPackData("Rssi_Ml_Notice_Ctl", currentByte, 38, 1),

        //        Rssi_Ml_Pend_Start_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ml_Pend_Start_Dt_PackedData", currentByte, 39, 4),
        //        Rssi_Ml_Bnkrpt_Flg = PackedTypeCheckAndUnPackData("Rssi_Ml_Bnkrpt_Flg", currentByte, 43, 1),

        //        Rssi_Ml_Bankrupt_Code = PackedTypeCheckAndUnPackData("Rssi_Ml_Bankrupt_Code", currentByte, 44, 1),
        //        Rssi_Ml_Repay_Status_Flg = PackedTypeCheckAndUnPackData("Rssi_Ml_Repay_Status_Flg", currentByte, 45, 1),

        //        Rssi_Ml_Repay_Cancel_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ml_Repay_Cancel_Dt_PackedData", currentByte, 46, 4),
        //        Rssi_Rpmt_Add_Pmt_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Add_Pmt_Amt_PackedData", currentByte, 50, 5, 2),

        //        Rssi_Rpmt_Plan_Term_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Plan_Term_PackedData", currentByte, 55, 2),
        //        Rssi_Rpmt_Creation_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Creation_Dt_PackedData", currentByte, 57, 4),

        //        Rssi_Rpmt_Rhcds_Down_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Rhcds_Down_Pymt_PackedData", currentByte, 61, 5, 2),
        //        Rssi_Rpmt_Start_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Start_Dt_PackedData", currentByte, 66, 4),

        //        Rssi_Ffssd119_Dwa_Delq_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ffssd119_Dwa_Delq_PackedData", currentByte, 70, 4, 2),
        //        Rssi_Poc_Post_Plan_Source = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Plan_Source", currentByte, 74, 1),
        //        Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 75, 126),

        //    };
        //}

        //// Z Trailer. One record per file.
        //public void GetTrailerRecords(byte[] currentByte, ref AccountsModel acc)
        //{
        //    acc.TrailerRecordModel = new TrailerRecordModel()
        //    {

        //        Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
        //        Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

        //        Rssi_Acct_Np = PackedTypeCheckAndUnPackData("Rssi_Acct_Np", currentByte, 5, 10),
        //        Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

        //        Rssi_Total_B_Records = PackedTypeCheckAndUnPackData("Rssi_Total_B_Records", currentByte, 20, 1),
        //        Rssi_Total_A_Records = PackedTypeCheckAndUnPackData("Rssi_Total_A_Records", currentByte, 21, 9),

        //        Rssi_Total_R_Records = PackedTypeCheckAndUnPackData("Rssi_Total_R_Records", currentByte, 30, 9),
        //        Rssi_Total_E_Records = PackedTypeCheckAndUnPackData("Rssi_Total_E_Records", currentByte, 39, 15),

        //        Rssi_Total_T_Records = PackedTypeCheckAndUnPackData("Rssi_Total_T_Records", currentByte, 54, 15),
        //        Rssi_Total_O_Records = PackedTypeCheckAndUnPackData("Rssi_Total_O_Records", currentByte, 69, 9),

        //        Rssi_Total_F_Records = PackedTypeCheckAndUnPackData("Rssi_Total_F_Records", currentByte, 78, 9),
        //        Rssi_Total_U_Records = PackedTypeCheckAndUnPackData("Rssi_Total_U_Records", currentByte, 87, 9),

        //        Rssi_Total_2_Records = PackedTypeCheckAndUnPackData("Rssi_Total_2_Records", currentByte, 96, 9),
        //        Rssi_Total_P_Records = PackedTypeCheckAndUnPackData("Rssi_Total_P_Records", currentByte, 105, 9),

        //        Rssi_Total_L_Records = PackedTypeCheckAndUnPackData("Rssi_Total_L_Records", currentByte, 114, 9),
        //        Rssi_Total_S_Records = PackedTypeCheckAndUnPackData("Rssi_Total_S_Records", currentByte, 123, 9),

        //        Rssi_Total_Fr_Records = PackedTypeCheckAndUnPackData("Rssi_Total_Fr_Records", currentByte, 132, 9),
        //        Rssi_Total_Records = PackedTypeCheckAndUnPackData("Rssi_Total_Records", currentByte, 141, 15),

        //        Rssi_Total_Loans = PackedTypeCheckAndUnPackData("Rssi_Total_Loans", currentByte, 156, 9),

        //    };
        //}

        //public void GenerateCRL30File()
        //{
        //    //List<AccountsModel> account = new List<AccountsModel>();
        //    //Logger.Trace("Creating NCP Header records...");


        //    //Logger.Trace("Creating NCP Institution records...");
        //    //Logger.Trace("Starting Account records process...");
        //    // var line = new StringBuilder();


        //    //foreach (var account in account)
        //    //{
        //    //    Logger.Trace("Creating NCP10 records for Account" + account.MasterFileDataPart_1Model.AccountNumber);
        //    //    //account.MasterFileDataPart_1Model.AccountNumber;
        //    //    line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.CityName);

        //    //}
        //}

        ////public string PackedTypeCheckAndUnPackData(string propertyName, byte[] data, int start, int length, int decimalPlaces = 0, bool hasSign = true)
        ////{
        ////    try
        ////    {
        ////        return NewPackedTypeCheckAndUnPackData(propertyName, data, start, length, decimalPlaces, hasSign);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Logger.Error(ex, "Data not at Position = " + start);
        ////        return "";
        ////    }
        ////}
        //public string PackedTypeCheckAndUnPackData(string propertyName, byte[] data, int start, int length, int decimalPlaces = 0, bool hasSign = true)
        //{
        //    if(propertyName == "Rssi_Tr_Amt_To_Evar_2_PackedData")
        //    {

        //    }
        //    try
        //    {
        //        if (propertyName.Contains("PackedData") && propertyName != null)
        //        {
        //            //if(propertyName.EndsWith("State_PackedData"))
        //            //    return NewPackedTypeCheckAndUnPackData(propertyName, data, start, length, decimalPlaces, hasSign);
        //            var buffer = new byte[length];
        //            Array.Copy(data, start - 1, buffer, 0, length);
        //            string output = string.Empty;
        //            string sign = string.Empty;
        //            int upperBound = length - 1;

        //            for (int i = 0; i < length; i++)
        //            {
        //                var left = (buffer[i] & 0xF0) >> 4;
        //                var right = buffer[i] & 0x0F;

        //                output += left.ToString(CultureInfo.InvariantCulture);

        //                if (i == upperBound && hasSign)
        //                {
        //                    sign = right == 0x0D ? "-" : string.Empty;
        //                }
        //                else
        //                {
        //                    output += right.ToString(CultureInfo.InvariantCulture);
        //                }
        //            }

        //            if (decimalPlaces > 0)
        //            {
        //                int index = output.Length - decimalPlaces;
        //                output = output.Insert(index, ".");
        //            }

        //            if (hasSign)
        //            {
        //                output = output.Insert(0, sign);
        //            }

        //            return output;
        //        }
        //        else
        //        {
        //            return GetPositionData(data, start, length, decimalPlaces, propertyName);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Data not at Position = " + start);
        //        return "";
        //    }
        //}

        //public string GetPositionData(byte[] currentByte, int startPos, int fieldLength, int decimalPlaces, string propertyName)
        //{
        //    try
        //    {
        //        string output = Encoding.Default.GetString(currentByte, startPos - 1, fieldLength);

        //        if (decimalPlaces > 0)
        //        {
        //            int index = output.Length - decimalPlaces;
        //            output = output.Insert(index, ".");
        //        }
        //        return output;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Data not at Position " + startPos);
        //        return "";
        //    }
        //}

        ///// <summary>
        ///// This will set the path values of Econcent and Suppliment file
        ///// </summary>
        //private void SetFilePath()
        //{
        //    string[] allFiles = Directory.GetFiles(ConfigHelper.Model.InputFilePathLocation_Local);
        //    foreach (string file in allFiles)
        //    {
        //        if (file.Contains("CMS_BILLINPUT"))
        //        {
        //            supplimentFilePath = file;
        //        }
        //        else if (file.Contains("Carrington_Econsent"))
        //        {
        //            EConsentFilePath = file;
        //        }
        //    }

        //}

        //public string NewPackedTypeCheckAndUnPackData(string propertyName, byte[] data, int start, int length, int decimalPlaces = 0, bool hasSign = true)
        //{
        //    try
        //    {
        //        if (propertyName.Contains("PackedData") && propertyName != null)
        //        {
        //            var buffer = new byte[length];
        //            Array.Copy(data, start - 1, buffer, 0, length);
        //            string output = string.Empty;
        //            var result =  Unpack(buffer, 0, propertyName);
        //            output = Convert.ToString(result);
                    
        //            return output;
        //        }
        //        else
        //        {
        //            return GetPositionData(data, start, length, decimalPlaces, propertyName);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Data not at Position = " + start);
        //        return "";
        //    }
        //}
        //private static Decimal Unpack(byte[] inp, int scale, string propertyName)
        //{
        //    long lo = 0;
        //    long mid = 0;
        //    long hi = 0;
        //    bool isNegative;

        //    // this nybble stores only the sign, not a digit.  
        //    // "C" hex is positive, "D" hex is negative, and "F" hex is unsigned. 
        //    switch (nibble(inp, 0))
        //    {
        //        case 0x0D:
        //            isNegative = true;
        //            break;
        //        case 0x0F:
        //        case 0x0C:
        //            isNegative = false;
        //            break;
        //        default:
        //            throw new Exception("Bad sign nibble");
        //    }
        //    long intermediate;
        //    long carry;
        //    long digit;
        //    for (int j = inp.Length * 2 - 1; j > 0; j--)
        //    {
        //        // multiply by 10
        //        intermediate = lo * 10;
        //        lo = intermediate & 0xffffffff;
        //        carry = intermediate >> 32;
        //        intermediate = mid * 10 + carry;
        //        mid = intermediate & 0xffffffff;
        //        carry = intermediate >> 32;
        //        intermediate = hi * 10 + carry;
        //        hi = intermediate & 0xffffffff;
        //        carry = intermediate >> 32;
        //        // By limiting input length to 14, we ensure overflow will never occur

        //        digit = nibble(inp, j);
        //        if (digit > 9)
        //        {
        //            throw new Exception("Bad digit");
        //        }
        //        intermediate = lo + digit;
        //        lo = intermediate & 0xffffffff;
        //        carry = intermediate >> 32;
        //        if (carry > 0)
        //        {
        //            intermediate = mid + carry;
        //            mid = intermediate & 0xffffffff;
        //            carry = intermediate >> 32;
        //            if (carry > 0)
        //            {
        //                intermediate = hi + carry;
        //                hi = intermediate & 0xffffffff;
        //                carry = intermediate >> 32;
        //                // carry should never be non-zero. Back up with validation
        //            }
        //        }
        //    }
        //    return new Decimal((int)lo, (int)mid, (int)hi, isNegative, (byte)scale);
        //}

        //private static int nibble(byte[] inp, int nibbleNo)
        //{
        //    int b = inp[inp.Length - 1 - nibbleNo / 2];
        //    return (nibbleNo % 2 == 0) ? (b & 0x0000000F) : (b >> 4);
        //}
        #endregion


    }
}

