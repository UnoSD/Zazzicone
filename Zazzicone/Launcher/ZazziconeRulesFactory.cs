using System.Collections.Generic;
using System.Linq;

namespace Launcher
{
    public class ZazziconeRulesFactory : IZazziconeRulesFactory
    {
        int _turn;

        public IEnumerable<IRule<IEnumerable<int>, int>> GetNextRulesSet()
        {
            // TODO: Please, change this shit.
            switch (++_turn)
            {
                case 1:
                //case 2:
                //case 3:
                //case 4:
                //case 5:
                //case 6:
                    return Enumerable.Range(1, 6).Select(number => new ZazziconeSameDiceRule(number));
                //case 7:
                //case 8:
                //case 9:
                //case 10:
                //case 11:
                //case 12:
                //case 13:
                case 2:
                    return Enumerable.Range(3, 3)
                        .Select(number => new ZazziconeNumberOfAKindDiceRule(number, ints => ints.FirstOrDefault() * number))
                        .Union(new IRule<IEnumerable<int>, int>[] { new ZazziconeFullHouseDiceRule(), new ZazziconeStraightDiceRule(4, 30), new ZazziconeStraightDiceRule(5, 40) });
                default:
                    return null;
            }
        }
    }
}