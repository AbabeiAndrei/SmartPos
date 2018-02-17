using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.Ui.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class AuthorisationAttribute : Attribute
    {
        public abstract bool IsAuthorized();
    }
}
