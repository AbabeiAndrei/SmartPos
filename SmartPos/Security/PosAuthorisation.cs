using System;
using System.Linq;

using SmartPos.Ui.Security;
using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Security
{
    public class PosAuthorisationAttribute : AuthorisationAttribute
    {
        public override bool IsAuthorized()
        {
            return Application.UserIsLoggedIn;
        }
    }

    public class AllowAnonymusAttribute : PosAuthorisationAttribute
    {
        public override bool IsAuthorized() => true;
    }

    public class PosRankAuthorisationAttribute : PosAuthorisationAttribute
    {
        private readonly UserRank _rank;

        public PosRankAuthorisationAttribute(UserRank required)
        {
            _rank = required;
        }

        public override bool IsAuthorized()
        {
            return base.IsAuthorized() && Application.User.Access >= _rank;
        }
    }

    [Flags]
    public enum AccessType : short
    {
        None = 0,
        Read = 1,
        Create = 2,
        Update = 4,
        Delete = 8,
        All = Create | Read | Update | Delete
    }

    public class PosRightAuthorisationAttribute : PosAuthorisationAttribute
    {
        private readonly string _right;
        private readonly UserRank? _rank;

        public PosRightAuthorisationAttribute(string right, UserRank? rank = null)
        {
            _right = right;
            _rank = rank;
        }

        public override bool IsAuthorized()
        {
            return base.IsAuthorized() && (_rank == null || Application.User.Access == _rank.Value) &&
                   Application.User.Rights.Any(r => r.Right.Name == _right);
        }
    }
}
