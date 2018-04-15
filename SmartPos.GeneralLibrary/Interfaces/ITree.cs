using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.GeneralLibrary.Interfaces
{
    public interface ITree<T>
    {
        ITree<T> Parent { get; }
        T Value { get; set; }
        IEnumerable<ITree<T>> Childrens { get; }
        IEnumerable<T> Path { get; }
    }

    public static class TreeCollection
    {
        public static IEnumerable<ITree<TSource>> CreateTree<TSource, TKey>(IEnumerable<TSource> source, 
                                                                            Func<TSource, TKey> keySelector,
                                                                            Func<TSource, TKey> parentKeySelector)
        {
            var lsource = source as IList<TSource> ?? source.ToList();

            foreach (var item in lsource.Where(i => parentKeySelector(i).Equals(default)))
            {
                var tree = new TreeCollection<TSource>(null, item);
                tree.Childrens = CreateTree(tree, lsource, keySelector, parentKeySelector);
                yield return tree;
            }
        }

        private static IEnumerable<ITree<TSource>> CreateTree<TSource, TKey>(ITree<TSource> parent, 
                                                                             IEnumerable<TSource> source, 
                                                                             Func<TSource, TKey> keySelector,
                                                                             Func<TSource, TKey> parentKeySelector)
        {
            var lsource = source as IList<TSource> ?? source.ToList();

            foreach (var item in lsource.Where(item => parentKeySelector(item).Equals(keySelector(parent.Value))))
            {
                var tree = new TreeCollection<TSource>(parent, item);
                tree.Childrens = CreateTree(tree, lsource, keySelector, parentKeySelector);
                yield return tree;
            }
        }
    }

    public class TreeCollection<T> : ITree<T>
    {
        #region Constructors

        public TreeCollection(ITree<T> parent, T value)
            : this(parent, value, Enumerable.Empty<ITree<T>>())
        {
        }

        public TreeCollection(ITree<T> parent, T value, IEnumerable<ITree<T>> childrens)
        {
            Parent = parent;
            Value = value;
            Childrens = childrens;
        }

        #endregion
        
        #region Implementation of ITree<T>

        /// <inheritdoc />
        public ITree<T> Parent { get; }

        /// <inheritdoc />
        public T Value { get; set; }

        /// <inheritdoc />
        public IEnumerable<ITree<T>> Childrens { get; set; }

        /// <inheritdoc />
        public IEnumerable<T> Path => GetTreePath(this).Reverse();

        #endregion

        #region Private methods

        private static IEnumerable<T> GetTreePath(ITree<T> tree)
        {
            while (tree != null)
            {
                yield return tree.Value;

                tree = tree.Parent;
            }
        }

        #endregion
    }
}
