using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using ServiceStack.OrmLite;

using SmartPos.DomainModel.Interfaces;

namespace SmartPos.DomainModel.Extensions
{
    public static class DbExtensions
    {
        public static T FirstOrDefault<T>(this IDbContext context, Expression<Func<T, bool>> predicate)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return context.Connection.Single(predicate);
        }

        public static IEnumerable<T> Select<T>(this IDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return context.Connection.Select<T>();
        }

        public static IEnumerable<T> Where<T>(this IDbContext context, Expression<Func<T, bool>> predicate)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if(predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return context.Connection.Select(predicate);
        }
    }
}
