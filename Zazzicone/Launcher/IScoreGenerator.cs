using System.Collections.Generic;

namespace Launcher
{
    public interface IScoreGenerator<TInput, TOutput>
    {
        TOutput GenerateScore(TInput input);
        List<IRule<TInput, TOutput>> Rules { get; }
        IRulesAggregator<TInput, TOutput> RulesAggregator { get; set; }
        IEnumerable<IRule<TInput, TOutput>> GetApplicableRules(TInput input);
    }
}