using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Launcher
{
    [DebuggerDisplay("Sequence of {" + nameof(_sequenceSize) + "}, scores {" + nameof(_totalScores) + "}.")]
    public class ZazziconeStraightDiceRule : IRule<IEnumerable<int>, int>
    {
        readonly int _sequenceSize;
        readonly int _totalScores;

        public ZazziconeStraightDiceRule(int sequenceSize, int totalScores)
        {
            _sequenceSize = sequenceSize;
            _totalScores = totalScores;
        }

        public int Apply(IEnumerable<int> input) => IsApplicable(input) ? _totalScores : 0;

        public bool IsApplicable(IEnumerable<int> input)
        {
            var orderedDicesValues = input.ToArray();

            var maxSequenceStart = orderedDicesValues.Max() - _sequenceSize + 1;

            for (var sequenceStart = orderedDicesValues.Min(); sequenceStart <= maxSequenceStart; sequenceStart++)
            {
                var range = Enumerable.Range(sequenceStart, _sequenceSize);

                if (!range.Except(orderedDicesValues).Any())
                    return true;
            }

            return false;
        }
    }
}