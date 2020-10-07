
using System;
using System.Timers;
using System.Diagnostics;
using HelocService.Helpers;
using HelocService.BusinessExpert;

namespace HelocService.Services
{
    public class WorkFlowService : IWorkFlowService
    {
        #region Class Members Definitions & Constructor
        public ILogger logger;
        public readonly IConfigHelper configHelper;
        private bool result = default;
        private readonly IWorkFlowExpert workFlowExpert;
        private readonly Timer TimerPurge;
        static System.Timers.Timer _timer; 
        #endregion

        public WorkFlowService(IWorkFlowExpert workFlowExpert, IConfigHelper configHelper, ILogger logger)
        {
            this.workFlowExpert = workFlowExpert;
            this.logger = logger;
            this.configHelper = configHelper;
            TimerPurge = new Timer();
        }

        #region Public Methods

        public bool StartWorkFlowService(string _inputFile,string  _trackingId)
        {
            try
            {
                result = workFlowExpert.StartWorkFlow(_inputFile, _trackingId);

                
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.TargetSite.Name);
                return false;
            }
        }
        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
         
        }
        //private void InitializeServiceTimers()
        //{
        //    TimerPurge.Elapsed += new System.Timers.ElapsedEventHandler(PurgeTimer_Elapsed);
        //    TimerPurge.Enabled = true;
        //    TimerPurge.AutoReset = true;
        //    TimerPurge.Interval = 10000;

        //    TimerPurge.Start();
        //    logger.Trace("Service Processing Timers Initialized");


        //}

        //public void PurgeTimer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 8)
        //    {
        //        result = workFlowExpert.StartWorkFlow();
        //    }
        //    else
        //    {

        //    }
        //    logger.Trace("Service Processing Timers Initialized");
        //}


        #endregion
    }
}