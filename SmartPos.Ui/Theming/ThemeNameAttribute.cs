using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
