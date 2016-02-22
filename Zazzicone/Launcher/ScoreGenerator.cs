using System.Collections.Generic;
using System.Linq;

namespace Launcher
{
    public class ScoreGenerator<TInput, TOutput> : IScoreGenerator<TInput, TOutput>
    {
        public List<IRule<TInput, TOutput>> Rules { get; } = new List<IRule<TInput, TOutput>>();
        public IRulesAggregator<TInput, TOutput> RulesAggregator { get; set; }

        public ScoreGenerator(IRulesAggregator<TInput, TOutput> rulesAggregator)
        {
            RulesAggregator = rulesAggregator;
        }

        public IEnumerable<IRule<TInput, TOutput>> GetApplicableRules(TInput input) => Rules.Where(rule => rule.IsApplicable(input));

        // TODO: Keep history of applied rules and when one is applied, return it
        public TOutput GenerateScore(TInput input)
        {
            var dictionary = new Dictionary<IRule<TInput, TOutput>, TOutput>();

            foreach (var rule in Rules)
            {
                var output = rule.Apply(input);

                dictionary.Add(rule, output);
            }

            return RulesAggregator.Aggregate(dictionary);
        }
    }
}