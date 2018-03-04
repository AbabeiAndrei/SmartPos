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

        public static void Foreach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        public static void AddRange<T>(this IList<T> source, IEnumerable<T> items)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if(source is List<T> list)
                list.AddRange(items);
            else
                foreach (var item in items)
                    source.Add(item);
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
