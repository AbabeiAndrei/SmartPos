using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Metadata
{
    public class UserMetadata : IMetadata
    {
        public bool IsTemporaryPassword { get; set; }
    }
}
