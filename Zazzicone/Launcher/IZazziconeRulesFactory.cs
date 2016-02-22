using System.Collections.Generic;

namespace Launcher
{
    public interface IZazziconeRulesFactory
    {
        IEnumerable<IRule<IEnumerable<int>, int>> GetNextRulesSet();
    }
}