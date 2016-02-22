using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Launcher
{
    [DebuggerDisplay("Two of a kind and three of another.")]
    class ZazziconeFullHouseDiceRule : IRule<IEnumerable<int>, int>
    {
        public int Apply(IEnumerable<int> dicesValues) => IsApplicable(dicesValues) ? 25 : 0;

        public bool IsApplicable(IEnumerable<int> dicesValues)
        {
            var nOfAKind = (from diceValue in dicesValues
                            group diceValue by diceValue into groups
                            orderby groups.Key
                            where groups.Count() >= 2
                            select groups.Count()).ToArray();

            return nOfAKind.Any(arg => arg == 3) && nOfAKind.Any(arg => arg == 2);
        }
    }
}