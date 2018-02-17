using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.DomainModel
{
    public enum Access
    {
        Yes,
        OnlyHis,
        No
    }

    public class AccessRight
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ControlName { get; set; }
    }

    public class UserAccessRight
    {
        public AccessRight Right { get; set; }

        public Guid UserId { get; set; }

        public Access Read { get; set; } 

        public Access Create { get; set; }

        public Access Update { get; set; }

        public Access Delete { get; set; }
    }
}
