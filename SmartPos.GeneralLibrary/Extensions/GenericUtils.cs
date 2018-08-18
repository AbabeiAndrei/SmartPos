using System.Collections.Generic;

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

        public static T As<T>(this object obj) where T : class => obj as T;
    }
}
