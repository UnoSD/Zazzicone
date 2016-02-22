using System.Collections.Generic;

namespace Launcher
{
    public interface IRulesAggregator<TInput, TOutput>
    {
        TOutput Aggregate(IDictionary<IRule<TInput, TOutput>, TOutput> results);
    }
}