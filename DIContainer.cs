﻿using Carrington_Service.Agents;
using Carrington_Service.BusinessExpert;
using Carrington_Service.Calculation_Classes;
using Carrington_Service.Helpers;
using Carrington_Service.Infrastructure;
using Carrington_Service.Interfaces;
using Carrington_Service.Services;
using CarringtonMortgage.FlexFields_Calculation;
using ODHS_EDelivery.BusinessExpert;
using SimpleInjector;

namespace Carrington_Service
{
    public static class DIContainer
    {
        private static Container container;
        public static void SetupInjector()
        {
            container = new Container();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            SimpleInjector.Lifestyles.SingletonLifestyle lifestyle = Lifestyle.Singleton;

            container.Register<IWorkFlowExpert, WorkFlowExpert>(lifestyle);
            container.Register<IConfigHelper, ConfigHelper>(lifestyle);
            container.Register<IAgentApi, AgentApi>(lifestyle);
            container.Register<ILogger, Logger>(lifestyle);
            container.Register<IWorkFlowService, WorkFlowService>(lifestyle);
            container.Register<IEmailService, EmailService>(lifestyle);
            container.Register<IChapterThirteenOptionARMStatement, ChapterThirteenOptionARMStatement>(lifestyle);
            container.Register<IChapterSevenBillingStatement, ChapterSevenBillingStatement>(lifestyle);
            container.Register<IChapterThirteenBillingStatement, ChapterThirteenBillingStatement>(lifestyle);
            container.Register<IStandardBillingStatement, StandardBillingStatement>(lifestyle);
            container.Register<IOptionARMBillingStatement, OptionARMBillingStatement>(lifestyle);
            container.Register<ICRL30FileGeneration, CRL30FileGeneration>(lifestyle);
            container.Register<IStatementType, StatementType>(lifestyle);
            container.Register<IChapterSevenOptionARMStatement, ChapterSevenOptionARMStatement>(lifestyle);

        }

        public static WorkFlowService GetWorkFlowServiceInstance()
        {
            return container.GetInstance<WorkFlowService>();
        }
    }
}
