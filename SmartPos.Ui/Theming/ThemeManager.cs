using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace SmartPos.Ui.Theming
{
    public static class ThemeManager
    {
        #region Constants

        private const string NAMESPACE_THEMES = "SmartPos.Ui.Theming.Themes";

        #endregion

        #region Fiedls

        private static readonly IEnumerable<Type> _themeTypes;

        #endregion

        #region Constructors

        static ThemeManager()
        {
            _themeTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(t => t.IsClass && t.Namespace == NAMESPACE_THEMES);
        }

        #endregion

        #region Publicm methods

        public static ITheme GetTheme(string themeName)
        {
            var themeType = _themeTypes.FirstOrDefault(t => ThemeHaveName(t, themeName)) ?? 
                            _themeTypes.FirstOrDefault(t => ThemeHaveName(t, themeName, false));

            if (themeType == null)
                throw new ThemeNotFoundException(themeName);

            return (ITheme) Activator.CreateInstance(themeType);
        }

        #endregion

        #region Private methods

        private static bool ThemeHaveName(MemberInfo type, string name, bool useAttribute = true)
        {
            return useAttribute
                       ? type.GetCustomAttributes(typeof(ThemeNameAttribute))
                             .OfType<ThemeNameAttribute>()
                             .Any(a => a.Name == name)
                       : type.Name.StartsWith(name);
        }

        #endregion
    }
}
