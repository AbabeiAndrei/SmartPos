using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.GeneralLibrary.Extensions
{
    public static class CollectionEx
    {
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }


        public static IReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> collection)
        {
            return new ReadOnlyCollection<T>(new List<T>(collection));
        }

        public static IReadOnlyList<T> ToReadOnly<T>(this IList<T> list)
        {
            return new List<T>(list);
        }
    }
}
