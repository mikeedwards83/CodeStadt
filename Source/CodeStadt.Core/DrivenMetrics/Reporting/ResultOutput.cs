using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Driven.Metrics.Reporting;
using Driven.Metrics.Metrics;

namespace CodeStadt.Core.DrivenMetrics.Reporting
{
    public class ResultOutput : IReport
    {

        List<MetricResult> _results;
        public IEnumerable<MetricResult> Results
        {
            get
            {
                return _results;
            }
        }
        
        
        public ResultOutput()
        {
            _results = new List<MetricResult>();
        }
        



        #region IReport Members

        public void Generate(Driven.Metrics.Metrics.MetricResult result)
        {
            _results.Add(result);
        }

        public void Generate(IEnumerable<Driven.Metrics.Metrics.MetricResult> results)
        {
            _results.AddRange(results);
        }

        #endregion
    }
}
