using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

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

        public static IEnumerable<(string Name, object Value)> GetProperties(this object obj)
        {
            if(obj == null)
                yield break;

            var type = obj.GetType();

            var properties = type.GetProperties();

            foreach (var property in properties)
                yield return (property.Name, property.GetValue(obj));
        }

        public static bool Implements<TInterface>(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.IsSubclassOf(typeof(TInterface));
        }
    }
}
