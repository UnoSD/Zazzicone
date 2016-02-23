using System;
using System.Collections.Generic;
using System.Linq;

namespace Launcher
{
    static class EnumerableExtensions
    {
        private const string StringCommaSeparator = ", ";

        internal static string ToCommaSeparatedString<T>(this IEnumerable<T> enumerable, Func<T, string> stringSelector)
        {
            enumerable = enumerable.ToArray();

            return !enumerable.Any() ? string.Empty : enumerable.Select(stringSelector).ToCommaSeparatedString();
        }

        internal static string ToCommaSeparatedString(this IEnumerable<string> strings)
        {
            strings = strings.ToArray();

            return !strings.Any() ? string.Empty : strings.Aggregate((left, right) => $"{left}{StringCommaSeparator}{right}");
        }
    }
}