using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace SmartPos.DomainModel.Base
{
    public abstract class Entity
    {
        [AutoIncrement]  
        public int Id { get; set; }
    }
}
