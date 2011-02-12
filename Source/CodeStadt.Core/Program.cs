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
                    (new ReportFactory()).ResolveReport(ReportType.All, "TestReport"));
           
            something.RunAllMetricsAndGenerateReport();
                    




        }
    }
}
