using HelocService.BillingStatements;
using HelocService.Helpers;
using HelocService.Models.InputCopyBookModels.MortgageLoanBillingModels;
using HelocService.Calculation_Classes;
using Common;
using System;
using System.IO;
using System.Linq;
using System.Text;
using WMS.Framework.Data;
using WMS.Framework.Data.Records.WorkflowRecords;
using HelocService.OptionAssignment;
using HelocService.Helpers;
using HelocService.Models.InputCopyBookModels;
using System.Collections.Generic;
using System.Reflection;
using HelocService.Models;
using Heloc.OptionAssignment;

namespace HelocService.BusinessExpert
{
    public class CRL30FileGeneration : ICRL30FileGeneration
    {
        public ILogger Logger;
        private readonly IOptionAssignmentLogic StatementType;
        private readonly IChapterSevenBillingStatement ChapterSevenBillingStatement;
        private readonly IChapterSevenOptionARMStatement ChapterSevenOptionARMStatement;
        private readonly IChapterThirteenBillingStatement ChapterThirteenBillingStatement;
        private readonly IChapterThirteenOptionARMStatement ChapterThirteenOptionARMStatement;
        private readonly IOptionARMBillingStatement OptionARMBillingStatement;
        private readonly IStandardBillingStatement StandardBillingStatement;
        private readonly IRejectStatement RejectStatement;
        /// <summary>The output file.</summary>
        private const string OutputFile = "output.ncp";

        /// <summary>The output file path and name.</summary>
        private static string _outputFile;

        private const string Ncp05Description = "CARRINGTON MORTGAGE FILE";

        /// <summary>The NCP05 version.</summary>
        private const string Ncp05Version = "01";

        /// <summary>The NCP09 data key category.</summary>
        private const string Ncp09DataKeyCategory = "CLIENT-TRAILER-DATA";

        /// <summary>The ncp 09 data key orders total count.</summary>
        private const string Ncp09DataKeyAccountsTotalCount = "ACCOUNTS-TOTAL-COUNT";

        /// <summary>The NCP10 version.</summary>
        private const string Ncp10Version = "03";

        /// <summary>The delimiter.</summary>
        private const string Delimiter = "|";

        /// <summary>
        /// The Product Number to assign to accounts that are rejected.
        /// </summary>
        private const string RejectProductNumber = "XXXXX";

        /// <summary>
        /// The option number to assign to accounts that are rejected.
        /// </summary>
        private const int RejectOptionNumber = 9999999;

        private static string _accountTypeHold;
        /// <summary>
        /// Cons CRL30 File Generation
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configHelper"></param>
        public CRL30FileGeneration(ILogger logger, IStandardBillingStatement standardBillingStatement, IOptionAssignmentLogic statementType,
            IChapterSevenBillingStatement chapterSevenBillingStatement, IChapterSevenOptionARMStatement chapterSevenOptionARMStatement,
            IChapterThirteenBillingStatement chapterThirteenBillingStatement, IChapterThirteenOptionARMStatement
            chapterThirteenOptionARMStatement, IOptionARMBillingStatement optionARMBillingStatement, IRejectStatement rejectStatement)
        {
            Logger = logger;
            StandardBillingStatement = standardBillingStatement;
            StatementType = statementType;
            ChapterSevenBillingStatement = chapterSevenBillingStatement;
            ChapterSevenOptionARMStatement = chapterSevenOptionARMStatement;
            ChapterThirteenBillingStatement = chapterThirteenBillingStatement;
            ChapterThirteenOptionARMStatement = chapterThirteenOptionARMStatement;
            OptionARMBillingStatement = optionARMBillingStatement;
            RejectStatement = rejectStatement;
        }

        /// <summary>
        /// This method is used for generating CRL30 File. 
        /// </summary>
        /// <param name="mortgageLoanBillingFileModel"></param>
        public void GenerateCRL30File(MortgageLoanBillingFileModel mortgageLoanBillingFileModel, string inputFile)
        {
            try
            {
                // Creating output file path
                CreateOutputPath(inputFile);
                using (var output = new StandardFile())
                {
                    Logger.Info("Creating NCP Header records...");
                    var lineCnt = 3;
                    output.CreateNew(_outputFile, "BHM");
                    var ncp05 = RecordManager.NewInputFileInfoRecord(Ncp05Version);
                    ncp05.Description = Ncp05Description;
                    ncp05.FileReceivedDate = Convert.ToDateTime(CommonHelper.GetFormatedDateTimeWithAmPm(mortgageLoanBillingFileModel.InputFileDate));
                    ncp05.InputFileName = mortgageLoanBillingFileModel.InputFileName; //TODO:Add properties in mortgage model
                    ncp05.InputFileSize = mortgageLoanBillingFileModel.InputFileSize;
                    ncp05.FileNumber = 1;
                    ncp05.TrackingId = Convert.ToInt32(mortgageLoanBillingFileModel.TrackingId);
                    output.AddInputFileInfoRecord(ncp05);
                    lineCnt++;

                    Logger.Info("Creating NCP07 records...");
                    //TODO: Revisit
                    output.AddLogRecord("CONV", "START", "Carrington_Mortgage + CONVERSION STARTED");
                    string InputFiledate = CommonHelper.GetFormatedDateTimeWithAmPm(mortgageLoanBillingFileModel.InputFileDate);
                    output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - FileDate = {InputFiledate}");
                    output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - Institution = {mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Institution_Name}");
                    output.AddLogRecord("CONV", "INFO",
                        mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Inst_Phone != null
                            ? $"LoanBillExtractInfo - Institution Phone = {mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Inst_Phone}"
                            : $"LoanBillExtractInfo - Institution Phone = {mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Alt_Coup_Ph_No_1}");
                    lineCnt += 10;

                    Logger.Info("Creating NCP09 records...");
                    output.AddAttribute(Ncp09DataKeyCategory, Ncp09DataKeyAccountsTotalCount, Convert.ToString(mortgageLoanBillingFileModel.TotalNumberOfAccount));
                    lineCnt++;

                    Logger.Info("Starting Account records process...");
                    var primaryIndex = 1;
                    var line = new StringBuilder();
                    int counter = 0;
                    foreach (var extractAccount in mortgageLoanBillingFileModel.AccountModelList)
                    {
                        counter++;
                        Logger.Info("Account records extracting...: " + counter);
                        //if (extractAccount.MasterFileDataPart_1Model.Rssi_Acct_No == "0000000011")//"0000714479")//"0000905973") //"0000714479")
                        //{

                        //}

                        _accountTypeHold = string.Empty;

                        var account = new CustomerAccount(primaryIndex, 1)
                        {
                            Standard = RecordManager.NewStandardRecord(Ncp10Version),
                            Workflow = new WorkflowRecord_NCP11_2
                            {
                                PrintDelivery = true,
                                ElectronicDelivery = true,
                                ElectronicDeliveryMethod = "A",
                                IMBIndicator = "I",
                                OptionNumber = null
                            }
                        };

                        account.Standard.AccountNumber = extractAccount.MasterFileDataPart_1Model.Rssi_Acct_No;
                        account.Standard.AccountSequenceNumber = primaryIndex;

                        //Mailing address
                        account.Standard.OriginalAddressLine1 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                        account.Standard.OriginalAddressLine2 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                        account.Standard.OriginalAddressLine3 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;

                        //City,State and Zip
                        //account.Standard.OriginalCity = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                        //account.Standard.OriginalState = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                        //account.Standard.OriginalZip4 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                        //account.Standard.OriginalZip5 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;


                        //For Raw Data
                        line = GetRawData(extractAccount);
                        account.AddCustomerRecord(FormatCustomer.BuildRecord("RAW", primaryIndex, line));

                        //Get all the data from input file and create Raw data rows
                        BuildPMRawData(extractAccount, account, primaryIndex);

                        // Check the account for bankrupcy 
                        bool isBankrupt = string.IsNullOrEmpty(extractAccount.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) ? true : false;

                        var borrowerList = new List<BorrowerModel>();

                        if (!isBankrupt)
                        {
                            //Assigning Flex fields for Primary borrower
                            borrowerList = StatementType.GetPrimaryStandardStatement(extractAccount);

                            if (borrowerList.Count > 0)
                            {
                                account.Standard.FlexField1 = borrowerList.FirstOrDefault()?.FlexField1;
                                account.Standard.FlexField2 = borrowerList.FirstOrDefault()?.FlexField2;
                                account.Standard.FlexField3 = borrowerList.FirstOrDefault()?.FlexField3;
                                account.Standard.FlexField4 = borrowerList.FirstOrDefault()?.FlexField4;
                                account.Standard.FlexField5 = borrowerList.FirstOrDefault()?.FlexField5;
                                account.Standard.FlexField6 = borrowerList.FirstOrDefault()?.FlexField6;
                            }
                              

                            account.Standard.SSN = extractAccount.MasterFileDataPart_1Model.Rssi_Primary_Social_Sec;
                            account.Standard.StatementDate = CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Run_Date);
                            account.Standard.PaymentDueDate = CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Due_Date) >
                               CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte) ?
                               CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Due_Date) :
                               CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte);
                            if (extractAccount.LateChargeDetailRecordModel.Rssi_Lcd_Pymt_Due_Dt_PackedData != null)
                            {
                                account.Standard.LatePaymentDueDate = CommonHelper.GetFormatedDateTime(extractAccount.LateChargeDetailRecordModel.Rssi_Lcd_Pymt_Due_Dt_PackedData);
                            }
                            else { account.Standard.LatePaymentDueDate = null; }

                            account.Standard.PaymentAmount = Convert.ToDecimal(ChapterSevenBillingStatement.GetPaymentAmount(extractAccount));

                            account.Standard.LatePaymentAmount = (StandardBillingStatement.GetLatePaymentAmount(extractAccount) != null
                                && StandardBillingStatement.GetLatePaymentAmount(extractAccount) != "N/A") ?
                                Convert.ToDecimal(StandardBillingStatement.GetLatePaymentAmount(extractAccount)) : 0;//TODO: Convert the calling method
                            account.Standard.EmailAddress = extractAccount.MasterFileDataPart_1Model.Rssi_Primary_Email_Adr;
                            account.Standard.FormattedAccount = extractAccount.MasterFileDataPart_1Model.Rssi_Acct_No;
                            account.Standard.TwoDRecordCode = 3;


                            lineCnt++;
                            line.Clear();
                            if (borrowerList.Count > 0)
                            {
                                //Get Statement based on the Flex fields for account
                                switch (borrowerList.FirstOrDefault()?.FlexField2)
                                {

                                    //For Chapter 7 Option ARM Statement
                                    case "A07":
                                        line = ChapterSevenOptionARMStatement.GetFinalChapterSevenOptionARMStatement(extractAccount);
                                        account.AddCustomerRecord(FormatCustomer.BuildRecord("A07", primaryIndex, line));
                                        break;

                                    //For Chapter 13 Option ARM Statement
                                    case "A13":
                                        line = ChapterThirteenOptionARMStatement.GetFinalChapterThirteenOptionARMStatement(extractAccount);
                                        account.AddCustomerRecord(FormatCustomer.BuildRecord("A13", primaryIndex, line));
                                        break;

                                    //For Option ARM Billing  Statement
                                    case "ARM":
                                        line = OptionARMBillingStatement.GetFinalOptionARMBillingStatement(extractAccount);
                                        account.AddCustomerRecord(FormatCustomer.BuildRecord("ARM", primaryIndex, line));
                                        break;

                                    //For Chapter 7 Billing Statement
                                    case "S07":
                                        line = ChapterSevenBillingStatement.GetFinalChapterSevenBillingStatement(extractAccount);
                                        account.AddCustomerRecord(FormatCustomer.BuildRecord("S07", primaryIndex, line));
                                        break;

                                    //For Chapter 13 Billing Statement
                                    case "S13":
                                        line = ChapterThirteenBillingStatement.GetFinalChapterThirteenBillingStatement(extractAccount);
                                        account.AddCustomerRecord(FormatCustomer.BuildRecord("S13", primaryIndex, line));
                                        break;

                                    //For Standard Billing Statement
                                    case "STD":
                                        line = StandardBillingStatement.GetFinalStringStandardBilling(extractAccount);
                                        account.AddCustomerRecord(FormatCustomer.BuildRecord("STD", primaryIndex, line));
                                        break;

                                    default:
                                        break;

                                }

                                                            
                                line.Clear();

                               

                                //Removing the primary borrower from the list leaving co borrower details inside
                                borrowerList.RemoveAt(0);
                            }
                        }

                        //Check if primary account is rejected or not 
                        var primaryAccountRejected = RejectStatement.IsRejectAccount(extractAccount);
                        if (primaryAccountRejected || isBankrupt)
                        {
                            string bankruptcy = string.Empty;
                            if (isBankrupt)
                            {
                                bankruptcy = " - Active Bankruptcy";
                            }
                            RejectAccount(account, "Invalid Account" + bankruptcy);
                        }
                            


                        account.SequenceTransactions();
                        output.AddAccount(account);
                        primaryIndex++;

                        if (borrowerList.Count > 0 && extractAccount.CoBorrowerRecordModel.Rssi_Acct_No != null)
                        {
                            //Add records for Co-Borrower Section 
                            foreach (var borrower in borrowerList)
                            {

                                if (borrower.DistinctAdditionalRecord)
                                {
                                    //Setting FlexFields according to co-borrower conditions
                                    account.Standard.FlexField1 = borrower.FlexField1;
                                    account.Standard.FlexField2 = borrower.FlexField2;
                                    account.Standard.FlexField3 = borrower.FlexField3;
                                    account.Standard.FlexField4 = borrower.FlexField4;
                                    account.Standard.FlexField5 = borrower.FlexField5;
                                    account.Standard.FlexField6 = borrower.FlexField6;

                                    switch (borrower.FlexField2)
                                    {
                                        //For Chapter 7 Option ARM Statement
                                        case "A07":
                                            //Set Mailing address according to the conditions
                                            account.Standard.OriginalAddressLine1 = ChapterSevenOptionARMStatement.GetMailingBKAttorneyAddressLine1(extractAccount, true);
                                            account.Standard.OriginalAddressLine2 = ChapterSevenOptionARMStatement.GetMailingBKAttorneyAddressLine2(extractAccount, true);
                                            string A07_cityStateZip = ChapterSevenOptionARMStatement.GetBorrowerAttorneyMailingCityStateZip(extractAccount, true);
                                            if(!string.IsNullOrEmpty(A07_cityStateZip))
                                            {
                                                var arr = A07_cityStateZip.Split(',');
                                                account.Standard.OriginalCity = arr[0].Trim();
                                                account.Standard.OriginalState = arr[1].Trim();
                                                account.Standard.OriginalZip5 = arr[2].Trim();
                                                account.Standard.OrigCszLength = A07_cityStateZip.Length - 2; // Remove 2 for commas (",")

                                            }
                                            break;

                                        //For Chapter 13 Option ARM Statement
                                        case "A13":
                                            //Set Mailing address according to the conditions
                                            account.Standard.OriginalAddressLine1 = ChapterThirteenOptionARMStatement.GetMailingBKAttorneyAddressLine1(extractAccount, true);
                                            account.Standard.OriginalAddressLine2 = ChapterThirteenOptionARMStatement.GetMailingBKAttorneyAddressLine2(extractAccount, true);
                                            string A13_cityStateZip = ChapterThirteenOptionARMStatement.GetBorrowerAttorneyMailingCityStateZip(extractAccount, true);
                                            if (!string.IsNullOrEmpty(A13_cityStateZip))
                                            {
                                                var arr = A13_cityStateZip.Split(',');
                                                account.Standard.OriginalCity = arr[0].Trim();
                                                account.Standard.OriginalState = arr[1].Trim();
                                                account.Standard.OriginalZip5 = arr[2].Trim();
                                                account.Standard.OrigCszLength = A13_cityStateZip.Length-2;

                                            }
                                            break;

                                        //For Option ARM Billing  Statement
                                        case "ARM":
                                            //Set Mailing address according to the conditions
                                            account.Standard.OriginalAddressLine1 = OptionARMBillingStatement.GetMailingAddressLine1(extractAccount, true);
                                            account.Standard.OriginalAddressLine2 = OptionARMBillingStatement.GetMailingAddressLine2(extractAccount, true);
                                            string ARM_cityStateZip = OptionARMBillingStatement.GetMailingCityStateZip(extractAccount, true);
                                            if (!string.IsNullOrEmpty(ARM_cityStateZip))
                                            {
                                                var arr = ARM_cityStateZip.Split(',');
                                                account.Standard.OriginalCity = arr[0].Trim();
                                                account.Standard.OriginalState = arr[1].Trim();
                                                account.Standard.OriginalZip5 = arr[2].Trim();
                                                account.Standard.OrigCszLength = ARM_cityStateZip.Length-2;
                                            }
                                            break;

                                        //For Chapter 7 Billing Statement
                                        case "S07":
                                            //Set Mailing address according to the conditions
                                            account.Standard.OriginalAddressLine1 = ChapterSevenBillingStatement.GetMailingBKAttorneyAddressLine1(extractAccount, true);
                                            account.Standard.OriginalAddressLine2 = ChapterSevenBillingStatement.GetMailingBKAttorneyAddressLine2(extractAccount, true);
                                            string S07_cityStateZip = ChapterSevenBillingStatement.GetBorrowerAttorneyMailingCityStateZip(extractAccount, true);
                                            if (!string.IsNullOrEmpty(S07_cityStateZip))
                                            {
                                                var arr = S07_cityStateZip.Split(',');
                                                account.Standard.OriginalCity = arr[0].Trim();
                                                account.Standard.OriginalState = arr[1].Trim();
                                                account.Standard.OriginalZip5 = arr[2].Trim();
                                                account.Standard.OrigCszLength = S07_cityStateZip.Length-2;

                                            }
                                            break;

                                        //For Chapter 13 Billing Statement
                                        case "S13":
                                            //Set Mailing address according to the conditions
                                            account.Standard.OriginalAddressLine1 = ChapterThirteenBillingStatement.GetMailingBKAttorneyAddressLine1(extractAccount, true);
                                            account.Standard.OriginalAddressLine2 = ChapterThirteenBillingStatement.GetMailingBKAttorneyAddressLine2(extractAccount, true);
                                            string S13_cityStateZip = ChapterThirteenBillingStatement.GetBorrowerAttorneyMailingCityStateZip(extractAccount, true);
                                            if (!string.IsNullOrEmpty(S13_cityStateZip))
                                            {
                                                var arr = S13_cityStateZip.Split(',');
                                                account.Standard.OriginalCity = arr[0].Trim();
                                                account.Standard.OriginalState = arr[1].Trim();
                                                account.Standard.OriginalZip5 = arr[2].Trim();
                                                account.Standard.OrigCszLength = S13_cityStateZip.Length-2;

                                            }
                                            break;

                                        //For Standard Billing Statement
                                        case "STD":
                                            //Set Mailing address according to the conditions
                                            account.Standard.OriginalAddressLine1 = StandardBillingStatement.GetMailingAddressLine1(extractAccount, true);
                                            account.Standard.OriginalAddressLine2 = StandardBillingStatement.GetMailingAddressLine2(extractAccount, true);
                                            string STD_cityStateZip = StandardBillingStatement.GetMailingCityStateZip(extractAccount, true);
                                            if (!string.IsNullOrEmpty(STD_cityStateZip))
                                            {
                                                var arr = STD_cityStateZip.Split(',');
                                                account.Standard.OriginalCity = arr[0].Trim();
                                                account.Standard.OriginalState = arr[1].Trim();
                                                account.Standard.OriginalZip5 = arr[2].Trim();
                                                account.Standard.OrigCszLength = STD_cityStateZip.Length-2;

                                            }
                                            break;

                                        default:
                                            break;

                                    }

                                    //Reject co-borrower account if the primary account is rejected
                                    if (primaryAccountRejected)
                                        RejectAccount(account, "Invalid Account");


                                    account.SequenceTransactions();

                                    output.AddAccount(account);
                                    primaryIndex++;//TODO: Need to check this when this task is complete                          
                                }
                            }
                        }
                        //Setting to false for other primary accounts
                        primaryAccountRejected = false;
                    }

                    output.CloseFile();
                    Logger.Info($"Lines written: {lineCnt}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GenerateCRL30File Failed :");
            }

        }

        /// <summary>Rejected account</summary>
        /// <param name="account">The account.</param>
        /// <param name="message">The message.</param>
        private static void RejectAccount(CustomerAccount account, string message)
        {
            account.Workflow.IsReject = true;
            account.Workflow.ProductNumber = RejectProductNumber;
            account.Workflow.OptionNumber = RejectOptionNumber;
            account.MarkAsReject(" Carrington_Mortgage", "8888", message);
        }
        /// <summary>
        /// This method is used for creating output file path
        /// </summary>
        private void CreateOutputPath(string inputFile)
        {
            if (string.IsNullOrWhiteSpace(_outputFile))
            {
                var outPath = inputFile.Substring(0, inputFile.LastIndexOf('\\'));
                _outputFile = Path.Combine(outPath, OutputFile);
                Logger.Info($"Output file name: {_outputFile}");
            }
        }

        /// <summary>
        /// Get Raw Data
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        private StringBuilder GetRawData(AccountsModel accountsModel)
        {

            var finalLine = new StringBuilder();
            finalLine.Append(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap + "|");
            finalLine.Append(accountsModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id + "|");
            finalLine.Append(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData + "|");
            finalLine.Append(accountsModel.UserFieldRecordModel.Rssi_Usr_93 + "|");
            finalLine.Append(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag + "|");
            finalLine.Append(accountsModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Acct_No + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Secondary_Name + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2 + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData + "|");
            finalLine.Append(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Dte + "|");
            finalLine.Append(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData + "|");
            finalLine.Append(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt1_PackedData + "|");
            finalLine.Append(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt2_PackedData + "|");
            finalLine.Append(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt3_PackedData + "|");
            finalLine.Append(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData + "|");


            return finalLine;

        }

        /// <summary>
        /// Build file RAW Data
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <param name="account"></param>
        /// <param name="primaryIndex"></param>
        private void BuildPMRawData(AccountsModel accountsModel, CustomerAccount account, int primaryIndex)
        {
            var builder = new StringBuilder();
            //A
            foreach (PropertyInfo propertyInfo in accountsModel.MasterFileDataPart_1Model.GetType().GetProperties())
            {
                if (propertyInfo.Name == "Rssi_Inv_All")
                    continue;
                
                builder.Append(propertyInfo.GetValue(accountsModel.MasterFileDataPart_1Model) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40A", primaryIndex, builder));
            builder.Clear();
            //2
            foreach (PropertyInfo propertyInfo in accountsModel.MasterFileDataPart2Model.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.MasterFileDataPart2Model) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM402", primaryIndex, builder));
            builder.Clear();
            //U
            foreach (PropertyInfo propertyInfo in accountsModel.UserFieldRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.UserFieldRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40U", primaryIndex, builder));
            builder.Clear();
            //L
            foreach (PropertyInfo propertyInfo in accountsModel.MultiLockboxRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.MultiLockboxRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40L", primaryIndex, builder));
            builder.Clear();
            //R
            foreach (PropertyInfo propertyInfo in accountsModel.RateReductionRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.RateReductionRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40R", primaryIndex, builder));
            builder.Clear();
            //E
            foreach (var escrow in accountsModel.EscrowRecordModel)
            {
                foreach (PropertyInfo propertyInfo in escrow.GetType().GetProperties())
                {
                    builder.Append(propertyInfo.GetValue(escrow) + "|");
                }
                account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40E", primaryIndex, builder));
                builder.Clear();
            }
            //O
            foreach (var optionalItemEscrow in accountsModel.OptionalItemEscrowRecordModel)
            {
                foreach (PropertyInfo propertyInfo in optionalItemEscrow.GetType().GetProperties())
                {
                    builder.Append(propertyInfo.GetValue(optionalItemEscrow) + "|");
                }
                account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40O", primaryIndex, builder));
                builder.Clear();
            }
            //F
            foreach (var feeRecordModel in accountsModel.FeeRecordModel)
            {

                foreach (PropertyInfo propertyInfo in feeRecordModel.GetType().GetProperties())
                {
                    builder.Append(propertyInfo.GetValue(feeRecordModel) + "|");
                }
                account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40F", primaryIndex, builder));
                builder.Clear();
            }
            //S
            foreach (PropertyInfo propertyInfo in accountsModel.SolicitationRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.SolicitationRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40S", primaryIndex, builder));
            builder.Clear();
            //T
            foreach (var transactionRecord in accountsModel.TransactionRecordModelList)
            {
                foreach (PropertyInfo propertyInfo in transactionRecord.GetType().GetProperties())
                {
                    if (propertyInfo.Name == "Rssi_Tr_Pre_Int_Date")
                    { 
                    
                    }
                        builder.Append(propertyInfo.GetValue(transactionRecord) + "|");
                }
                account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40T", primaryIndex, builder));
                builder.Clear();
            }

            //C
            foreach (PropertyInfo propertyInfo in accountsModel.ForeignInformationRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.ForeignInformationRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40C", primaryIndex, builder));
            builder.Clear();
            //D
            foreach (PropertyInfo propertyInfo in accountsModel.BlendedRateInformationRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.BlendedRateInformationRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40D", primaryIndex, builder));
            builder.Clear();
            //I
            foreach (PropertyInfo propertyInfo in accountsModel.CoBorrowerRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.CoBorrowerRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40I", primaryIndex, builder));
            builder.Clear();
            //<
            foreach (PropertyInfo propertyInfo in accountsModel.LateChargeInformationRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.LateChargeInformationRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40<", primaryIndex, builder));
            builder.Clear();

            //-
            foreach (PropertyInfo propertyInfo in accountsModel.LateChargeDetailRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.LateChargeDetailRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40-", primaryIndex, builder));
            builder.Clear();

            //J
            foreach (PropertyInfo propertyInfo in accountsModel.ActiveBankruptcyInformationRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.ActiveBankruptcyInformationRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40J", primaryIndex, builder));
            builder.Clear();
            //K
            foreach (var archivedBankruptcyDetailRecordModel in accountsModel.ArchivedBankruptcyDetailRecordModel)
            {
                foreach (PropertyInfo propertyInfo in archivedBankruptcyDetailRecordModel.GetType().GetProperties())
                {
                    builder.Append(propertyInfo.GetValue(archivedBankruptcyDetailRecordModel) + "|");
                }
                account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40K", primaryIndex, builder));
                builder.Clear();
            }
            //X
            foreach (PropertyInfo propertyInfo in accountsModel.EmailAddressRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.EmailAddressRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40X", primaryIndex, builder));
            builder.Clear();
            //3
            foreach (PropertyInfo propertyInfo in accountsModel.DisasterTrackingRecordModel.GetType().GetProperties())
            {
                if (propertyInfo.Name == "Rssi_Dstr_Extended_Dt_PackedData")
                {

                }
                builder.Append(propertyInfo.GetValue(accountsModel.DisasterTrackingRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM403", primaryIndex, builder));
            builder.Clear();
            //4
            foreach (PropertyInfo propertyInfo in accountsModel.RHCDSOnlyRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.RHCDSOnlyRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM404", primaryIndex, builder));
            builder.Clear();
            //Z
            foreach (PropertyInfo propertyInfo in accountsModel.TrailerRecordModel.GetType().GetProperties())
            {
                builder.Append(propertyInfo.GetValue(accountsModel.TrailerRecordModel) + "|");
            }
            account.AddCustomerRecord(FormatCustomer.BuildRecord("PM40Z", primaryIndex, builder));
            builder.Clear();

        }
    }
}
