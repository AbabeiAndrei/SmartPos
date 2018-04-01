using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Interfaces;
using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.Desktop.Data
{
    public static class SimpleCache
    {
        #region Fields

        private static readonly IDictionary<string, IEnumerable<Entity>> _cache;

        #endregion

        #region Constructors

        static SimpleCache()
        {
            _cache = new ConcurrentDictionary<string, IEnumerable<Entity>>();
        }

        #endregion

        #region Public methods

        public static TEntity Get<TEntity>(int id) 
                where TEntity : Entity
        {
            var type = typeof(TEntity).FullName;

            if(string.IsNullOrWhiteSpace(type))
                throw new TypeAccessException();

            if (!_cache.ContainsKey(type))
                return default;

            return _cache[type].FirstOrDefault(e => e.Id == id) as TEntity;
        }

        public static IEnumerable<TEntity> CheckForUpdates<TEntity>(IEnumerable<TEntity> entities)
                where TEntity : Entity
        {
            var items = entities.ToList();

            if (items.Count <= 0)
                return items;

            var type = items[0].GetType();
            var typeName = type.FullName;
            
            if(string.IsNullOrWhiteSpace(typeName))
                throw new TypeAccessException();

            if (!_cache.ContainsKey(typeName))
                _cache.Add(typeName, items);
            else
                _cache[typeName] = _cache[typeName].Replace(items, entity => entity.Id);
            
            foreach (var cache in items.OfType<IEmbededCacheProperties>())
                CheckForUpdates(cache.GetValues<Entity>());

            return items;
        }

        public static TEntity CheckForUpdates<TEntity>(TEntity entity)
                where TEntity : Entity
        {
            CheckForUpdates(entity.Yield());
            return entity;
        }

        #endregion
    }
}
