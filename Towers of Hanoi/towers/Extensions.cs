using System;
using System.Collections.Generic;
using System.Text;

namespace towers
{
    public static class Extensions
    {
        public static IEnumerable<int> IndexesWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int index = 0;
            foreach (T element in source)
            {
                if (predicate(element))
                {
                    yield return index;
                }
                index++;
            }
        }

        public static int IndexWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int index = 0;
            foreach (T element in source)
            {
                if (predicate(element))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}
