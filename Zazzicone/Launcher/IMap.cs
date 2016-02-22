using System.Collections.Generic;

namespace Launcher
{
    // TODO: Find the appropiate name for this data type and see if it's in the framework.
    public interface IMap<TLeft, TRight> : IEnumerable<KeyValuePair<TLeft, TRight>>
    {
        void Add(TLeft left, TRight right);
        TLeft this[TRight right] { get; }
        TRight this[TLeft right] { get; }
    }
}