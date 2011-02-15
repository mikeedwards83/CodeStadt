using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStadt.Draw.Shapes;
using CodeStadt.Core.DrivenMetrics.Reporting;

namespace CodeStadt.Draw.Builders
{
    public interface ICityBuilder
    {
        IEnumerable<IShape> CreateCity(ResultOutput output);
    }
}
