using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.GeneralLibrary.Extensions
{
    public static class GenericUtils
    {
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }

        public static decimal CalculateTotalPrice(this decimal unitPrice, float quantity)
        {
            return unitPrice * (decimal) quantity;
        }
    }
}
