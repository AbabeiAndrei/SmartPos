using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
    }
}
