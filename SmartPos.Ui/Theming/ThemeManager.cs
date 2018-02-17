using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.Ui.Theming
{
    public static class ThemeManager
    {
        private const string NAMESPACE_THEMES = "SmartPos.Ui.Theming.Themes";
        private static readonly IEnumerable<Type> _themeTypes;

        static ThemeManager()
        {
            _themeTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(t => t.IsClass && t.Namespace == NAMESPACE_THEMES);
        }

        public static ITheme GetTheme(string themeName)
        {
            var themeType = _themeTypes.FirstOrDefault(t => ThemeHaveName(t, themeName)) ?? 
                        _themeTypes.FirstOrDefault(t => ThemeHaveName(t, themeName, false));

            if (themeType == null)
                throw new ThemeNotFoundException(themeName);

            return (ITheme) Activator.CreateInstance(themeType);
        }

        private static bool ThemeHaveName(MemberInfo type, string name, bool useAttribute = true)
        {
            return useAttribute
                       ? type.GetCustomAttributes(typeof(ThemeNameAttribute))
                             .OfType<ThemeNameAttribute>()
                             .Any(a => a.Name == name)
                       : type.Name.StartsWith(name);
        }
    }
}
