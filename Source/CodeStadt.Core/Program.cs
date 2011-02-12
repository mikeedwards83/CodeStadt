using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Driven.Metrics.Reporting;
using Driven.Metrics.metrics;

namespace CodeStadt.Core
{
    class Program
    {
        static void Main(string[] args)
        {
           var something =  new Driven.Metrics.DrivenMetrics.Factory().Create(
                new string[] { "CodeStadt.Core.exe" },
                new IMetricCalculator[]{
                    new NumberOfLinesCalculator(300),
                    new ILCyclomicComplextityCalculator(4)},
                    "TestReport",
                    new DrivenMetrics.Reporting.ResultOutput());
           
            something.RunAllMetricsAndGenerateReport();

            DrivenMetrics.Reporting.ResultOutput results = something.Report.As<DrivenMetrics.Reporting.ResultOutput>();

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
