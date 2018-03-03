using System;

namespace SmartPos.Ui.Theming
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ThemeNameAttribute : Attribute
    {
        public string Name { get; }

        public ThemeNameAttribute(string name)
        {
            Name = name;
        }
    }
}
