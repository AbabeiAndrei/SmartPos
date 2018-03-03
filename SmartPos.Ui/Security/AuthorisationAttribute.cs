using System;

namespace SmartPos.Ui.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class AuthorisationAttribute : Attribute
    {
        public abstract bool IsAuthorized();
    }
}
