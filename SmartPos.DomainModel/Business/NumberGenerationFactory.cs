using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using SmartPos.DomainModel.Interfaces;

namespace SmartPos.DomainModel.Business
{
    public static class NumberGenerationFactory
    {
        private static int _lastNumber = -1;
        private static readonly object Lock = new object();

        public static int GenerateNumber(IDbContext context)
        {
            lock (Lock)
            {
                if (_lastNumber <= 0)
                    _lastNumber = context.Connection.ExecuteNonQuery("SELECT MAX(Number) FROM `order`");

                return ++_lastNumber;
            }
        }
    }
}
