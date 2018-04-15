using System;
using System.Linq.Expressions;
using System.Collections.Generic;

using ServiceStack.OrmLite;

using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Interfaces;
using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.DomainModel.Extensions
{
    public static class DbExtensions
    {
        public static TEntity FirstOrDefault<TEntity>(this IDbContext context, Expression<Func<TEntity, bool>> predicate)
            where TEntity : Entity
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return context.Connection.Single(predicate);
        }

        public static IEnumerable<TEntity> Select<TEntity>(this IDbContext context)
                where TEntity : Entity
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (typeof(TEntity).Implements<ISoftDeletable>())
                return context.Connection.Select<TEntity>($"{nameof(ISoftDeletable.Deleted)} <> 1");

            return context.Connection.Select<TEntity>();
        }

        public static IEnumerable<TEntity> Where<TEntity>(this IDbContext context, Expression<Func<TEntity, bool>> predicate)
                where TEntity : Entity
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            
            return context.Connection.Select(predicate);
        }

        public static void Delete<TEntity>(this IDbContext context, TEntity entity)
                where TEntity : Entity
        {
            if (entity is ISoftDeletable soft)
            {
                soft.Deleted = true;
                Update(context, entity);
                return;
            }

            Delete<TEntity>(context, entity.Id);
        }

        public static void Delete<TEntity>(this IDbContext context, int id)
                where TEntity : Entity
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Connection.DeleteById<TEntity>(id);
        }

        public static void Insert<TEntity>(this IDbContext context, TEntity entity)
                where TEntity : Entity
        {
            var id = context.Connection.Insert(entity, true);

            entity.Id = (int) id;
        }

        public static void Update<TEntity>(this IDbContext context, TEntity entity)
                where TEntity : Entity
        {
            context.Connection.Update(entity);
        }
    }
}
