using HelocService;
using HelocService.BusinessExpert;
using HelocService.Helpers;

using HelocService.Services;
using System;
using System.IO;

namespace HelocService
{
    public class Program
    {
        private static string _inputFile;
        private static string _inputRecordLength;
        private static string _dataCenter;
        private static string _trackingId;
        public ILogger Logger;


        private static void Main(string[] args)
        {
            DIContainer.SetupInjector();
            WorkFlowService objWFservice = DIContainer.GetWorkFlowServiceInstance();

            try
            {
                objWFservice.logger.Trace("STARTED: Main");
                if (args.Length >= 4)
                {
                    _inputFile = @"C:\Mortgage\WIP\467004\09242020011458.TESTFEBIL09162020101432.680.ETOA";
                    //_inputFile = args[0];
                    _inputRecordLength = args[1];
                    _dataCenter = args[2];
                    _trackingId = args[3];

                    objWFservice.logger.Trace("Input file name: " + _inputFile + "");
                    objWFservice.logger.Trace("Input record length: " + _inputRecordLength);
                    objWFservice.logger.Trace("Data Center:  " + _dataCenter);
                    objWFservice.logger.Trace("Tracking Id:  " + _trackingId);

                    if (!File.Exists(_inputFile))
                    {
                        objWFservice.logger.Trace($"Input file does not exist: {_inputFile}.");
                        throw new FileNotFoundException($"Carrington Mortgage: File not found at location = {_inputFile}");
                    }
                    if (objWFservice.StartWorkFlowService(_inputFile, _trackingId))
                    {
                        //  objWFservice.logger.Trace("SUCCESS: Application succcesfully executed with 0 error.");
                        objWFservice.logger.Trace("ENDED:   Main");
                    }
                    else
                    {
                        objWFservice.logger.Trace("ERROR:   Application aborted with 1 error.");
                    }
                }
                else
                {
                    objWFservice.logger.Trace("Invalid number of parameters supplied.");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                objWFservice.logger.Error(ex, ex.TargetSite.Name);
            }

            //  DIContainer.SetupInjector();
            //  WorkFlowExpert objWFservice = DIContainer.GetWorkFlowServiceInstance();


            //try
            //{
            //    objWFservice.logger.Trace("STARTED: Main");
            //    if (args.Length >= 4)
            //    {
            //        _inputFile = args[0];
            //        _inputRecordLength = args[1];
            //        _dataCenter = args[2];
            //        _trackingId = args[3];

            //        bool status = objWFservice.FileReadingProcess(_inputFile, _trackingId);

            //        Logger.Trace("Input file name: " + _inputFile + "");
            //        Logger.Trace("Input record length: " + _inputRecordLength);
            //        Logger.Trace("Data Center: {0}" + _dataCenter);
            //        Logger.Trace("Tracking Id: {0}" + _trackingId);

            //        if (!File.Exists(_inputFile))
            //        {
            //            objWFservice.logger.Trace($"Input file does not exist: {_inputFile}.");
            //            throw new FileNotFoundException($"FirstTech_HELOC_Mortgage: file {_inputFile}");
            //        }
            //    }
            //    else
            //    {
            //        objWFservice.logger.Trace("Invalid number of parameters supplied.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //  objWFservice.logger.Error(ex, ex.TargetSite.Name);
            //}
        }
        //public void ProcessStart();
        //{
        //     WorkFlowExpert wkl = new WorkFlowExpert(Prog.ConfigHelper, Logger, ApiAgent, EmailService);
        //wkl.FileReadingProcess(_inputFile, _trackingId);

        //}

        //try
        //{
        //    objWFservice.logger.Trace("STARTED: Main");

        //    if (objWFservice.StartWorkFlowService())
        //    {
        //        objWFservice.logger.Trace("SUCCESS: Application succcesfully executed with 0 error."); 
        //        objWFservice.logger.Trace("ENDED:   Main");
        //    }
        //    else
        //    {
        //        objWFservice.logger.Trace("ERROR:   Application aborted with 1 error.");
        //    }
        //    Console.ReadKey();
        //}
        //catch (Exception ex)
        //{
        //    objWFservice.logger.Error(ex, ex.TargetSite.Name);
        //}

    }
}

