using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Driven.Metrics.metrics;
using Driven.Metrics;
using Driven.Metrics.Reporting;

namespace CodeStadt.Application
{
    class Program
    {

        static void Main(string[] args)
        {

            CommandLineArguments cArgs = new CommandLineArguments(args);

            Configuration config = new Configuration();

            var something = new Driven.Metrics.DrivenMetrics.Factory().Create(
                 cArgs.Assemblies.ToArray(),
                 config.Container.ResolveAll<IMetricCalculator>() ,
                     "TestReport",
                 config.Container.Resolve<IReport>());

            something.RunAllMetricsAndGenerateReport();

            CodeStadt.Core.DrivenMetrics.Reporting.ResultOutput results = something.Report.As<Core.DrivenMetrics.Reporting.ResultOutput>();

            if (results != null)
            {
                results.Results.ForEach(x =>
                {
                    Console.WriteLine("Metric: {0}".Formatted(x.Name));
                    Console.WriteLine("");

                    x.ClassResults.ForEach(y =>
                    {
                        Console.WriteLine("  Class: {0}".Formatted(y.Name));
                        Console.WriteLine("");
                        y.MethodResults.ForEach(z =>
                        {
                            Console.WriteLine("    Method: {0} \n\r    Result: {1}".Formatted(z.Name, z.Result));
                            Console.WriteLine("");

                        });
                    });
                });
            }

            Console.ReadLine();


        }
    }
}
