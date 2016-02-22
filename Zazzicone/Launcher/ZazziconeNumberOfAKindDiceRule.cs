using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Launcher
{
    [DebuggerDisplay("{" + nameof(_number) + "} of a kind.")]
    public class ZazziconeNumberOfAKindDiceRule : IRule<IEnumerable<int>, int>
    {
        readonly int _number;
        readonly Func<IEnumerable<int>, int> _calculateResult;

        public ZazziconeNumberOfAKindDiceRule(int number, Func<IEnumerable<int>, int> calculateResult)
        {
            _number = number;
            _calculateResult = calculateResult;
        }

        public int Apply(IEnumerable<int> dicesValues)
        {
            var nOfAKind = from diceValue in dicesValues
                           group diceValue by diceValue into groups
                           orderby groups.Key
                           where groups.Count() >= _number
                           select groups.Key;

            return _calculateResult(nOfAKind);
        }

        public bool IsApplicable(IEnumerable<int> dicesValues)
        {
            var nOfAKind = from diceValue in dicesValues
                           group diceValue by diceValue into groups
                           orderby groups.Key
                           where groups.Count() >= _number
                           select groups.Key;

            return nOfAKind.Any();
        }
    }
}