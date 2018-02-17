using System;
using System.Runtime.Serialization;

namespace SmartPos.Ui.Theming
{
    public class ThemeNotFoundException : Exception
    {
        public string ThemeName { get; }

        public ThemeNotFoundException(string themeName)
        {
            ThemeName = themeName;
        }

        public ThemeNotFoundException(string themeName, string message) : base(message)
        {
            ThemeName = themeName;
        }

        public ThemeNotFoundException(string themeName, string message, Exception innerException) : base(message, innerException)
        {
            ThemeName = themeName;
        }

        protected ThemeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}