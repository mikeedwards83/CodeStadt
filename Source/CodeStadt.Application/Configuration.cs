using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Driven.Metrics.metrics;
using Driven.Metrics.Reporting;
using CodeStadt.Core.DrivenMetrics.Reporting;

namespace CodeStadt.Application
{

    /// <summary>
    /// Contains the configuration for the application
    /// </summary>
    public class Configuration
    {

        public Configuration()
        {
            Configure();
        }

        public IWindsorContainer Container { get; private set; }

        public void Configure()
        {
            Container = new WindsorContainer();

            ConfigureProperties(Container);
            ConfigureFactility(Container);
            ConfigureComponents(Container);

        }

        private void ConfigureProperties(IWindsorContainer container)
        {
            
                
        }

        private void ConfigureFactility(IWindsorContainer container)
        {

        }

        private void ConfigureComponents(IWindsorContainer container)
        {
            // Metric Registration
            container.Register(
                Component
                .For<IMetricCalculator>()
                .ImplementedBy<NumberOfLinesCalculator>()
                .Named("metrics.linesOfCode")
                .Parameters(
                    Parameter.ForKey("maxLines").Eq("100")
                ),
                Component
                .For<IMetricCalculator>()
                .ImplementedBy<ILCyclomicComplextityCalculator>()
                .Named("metrics.cyclomicComplexity")
                .Parameters(
                    Parameter.ForKey("maxPassValue").Eq("10")
                )
            );

            //Reporting  Registration
            container.Register(
                Component
                .For<IReport>()
                .ImplementedBy<ResultOutput>()
                .Named("reports.resultOutput"));

        }

    }
}
