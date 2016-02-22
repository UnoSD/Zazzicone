using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Launcher
{
    public class Map<TLeft, TRight> : IMap<TLeft, TRight>
    {
        readonly IDictionary<TLeft, TRight> _innerDictionary = new Dictionary<TLeft, TRight>();

        public void Add(TLeft left, TRight right) => _innerDictionary.Add(left, right);

        TLeft IMap<TLeft, TRight>.this[TRight right] => _innerDictionary.Single(pair => pair.Value.Equals(right)).Key;

        TRight IMap<TLeft, TRight>.this[TLeft right] => _innerDictionary[right];

        public IEnumerator<KeyValuePair<TLeft, TRight>> GetEnumerator() => _innerDictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}