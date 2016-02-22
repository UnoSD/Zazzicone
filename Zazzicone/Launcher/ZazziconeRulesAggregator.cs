using System.Collections.Generic;
using System.Linq;

namespace Launcher
{
    public class ZazziconeRulesAggregator : IRulesAggregator<IEnumerable<int>, int>
    {
        public int Aggregate(IDictionary<IRule<IEnumerable<int>, int>, int> results) => results.Values.Max();
    }
}