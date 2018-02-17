using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPos.GeneralLibrary;

namespace SmartPos.DomainModel
{
    public enum UserRank
    {
        Regular,
        Manager,
        Administrator
    }

    public class User : IIdentity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserRank Rank { get; set; }

        public IEnumerable<UserAccessRight> Rights { get; set; }
    }
}
