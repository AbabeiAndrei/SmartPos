using System;
using System.Runtime.Serialization;

using SmartPos.GeneralLibrary.Exceptions;

namespace SmartPos.Ui.Theming
{
    public class ThemeNotFoundException : PosException
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