using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Launcher
{
    [DebuggerDisplay("Sum all the {" + nameof(_value) + "}.")]
    public class ZazziconeSameDiceRule : IRule<IEnumerable<int>, int>
    {
        readonly int _value;

        public ZazziconeSameDiceRule(int value)
        {
            _value = value;
        }

        public int Apply(IEnumerable<int> input) => input.Where(number => number == _value).Sum();

        public bool IsApplicable(IEnumerable<int> input) => input.Any(number => number == _value);
    }
}