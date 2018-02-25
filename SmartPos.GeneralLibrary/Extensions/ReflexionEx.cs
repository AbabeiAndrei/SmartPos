using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.GeneralLibrary.Extensions
{
    public static class ReflexionEx
    {
        public static IEnumerable<T> GetPublicConstantValues<T>(this Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                       .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T))
                       .Select(x => (T)x.GetRawConstantValue());
        }
    }
}
