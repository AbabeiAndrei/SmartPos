using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public static IEnumerable<T> CreateEnumerable<T>(this IEnumerator<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.Reset();
            while (source.MoveNext())
                yield return source.Current;
        }
    }

    public class FakeEnumerable<T> : IEnumerable<T> 
    {
        private readonly IEnumerator<T> _enumerator;

        public FakeEnumerable(IEnumerator<T> e) 
        {
            _enumerator = e;
        }

        public IEnumerator<T> GetEnumerator() { 
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
