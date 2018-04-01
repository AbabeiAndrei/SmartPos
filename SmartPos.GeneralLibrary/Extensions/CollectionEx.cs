using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using SmartPos.GeneralLibrary.Interfaces;

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

        public static void RemoveAll(this IList source, Func<object, bool> predicate)
        {
            RemoveAll<object>(source, predicate);
        }
        
        public static void RemoveAll<T>(this IList source, Func<T, bool> predicate)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            
            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var indexes = source.OfType<T>()
                                .Select((item, index) => (Item: item, Index: index))
                                .Where(t => predicate(t.Item))
                                .Select(t => t.Index)
                                .OrderByDescending(index => index)
                                .ToList();

            foreach (var index in indexes)
                source.RemoveAt(index);
        }

        public static IEnumerable<TSource> Replace<TSource, TKey>(this IEnumerable<TSource> source,
                                                                  IEnumerable<TSource> other,
                                                                  Func<TSource, TKey> selector)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            
            if(other == null)
                throw new ArgumentNullException(nameof(other));

            if(selector == null)
                throw new ArgumentNullException(nameof(selector));

            var lsource = source as IList<TSource> ?? source.ToList();
            var lother = other as IList<TSource> ?? other.ToList();

            foreach (var item in lsource)
            {
                var newItem = lother.FirstOrDefault(o => selector(o).Equals(selector(item)));

                if (newItem != null)
                    yield return newItem;
                else
                    yield return item;
            }

            foreach (var newItem in lother.Unique(lsource, selector))
                yield return newItem;
        }

        public static IEnumerable<TSource> Unique<TSource, TKey>(this IEnumerable<TSource> source,
                                                                 IEnumerable<TSource> other,
                                                                 Func<TSource, TKey> selector)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));
            
            if(other == null)
                throw new ArgumentNullException(nameof(other));

            if(selector == null)
                throw new ArgumentNullException(nameof(selector));

            var itemsInOther = other.Select(selector).ToList();

            return source.Where(sourceItem => !itemsInOther.Contains(selector(sourceItem)));
        }

        public static bool Empty<TSource>(this IEnumerable<TSource> source)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            return !source.Any();
        }

        public static IEnumerable<ITree<TSource>> ToTree<TSource, TKey>(this IEnumerable<TSource> source, 
                                                                        Func<TSource, TKey> keySelector,
                                                                        Func<TSource, TKey> parentKeySelector)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if(keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            if(parentKeySelector == null)
                throw new ArgumentNullException(nameof(parentKeySelector));

            return TreeCollection.CreateTree(source, keySelector, parentKeySelector);
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
