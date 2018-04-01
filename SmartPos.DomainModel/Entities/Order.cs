using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using SmartPos.DomainModel.Base;
using SmartPos.DomainModel.Metadata;

namespace SmartPos.DomainModel.Entities
{
    public enum OrderState : short
    {
        Opened = 0, 
        Active = 1,
        Closed = 2
    }
    
    public class Order : MetadataEntity<OrderMetadata>, ISoftDeletable
    {
        [Required]
        public int Number { get; set; }
        
        [Required]
        [References(typeof(Table))]
        public int TableId { get; set; }
        
        [Required]
        [References(typeof(User))]
        public int UserId { get; set; }
        
        [Required]
        public OrderState State { get; set; }
        
        [Required]
        [Default(OrmLiteVariables.SystemUtc)]
        public DateTime Created { get; set; }

        public override string Metadata { get; set; }
        
        [Default(typeof(bool), "0")]
        public bool Deleted { get; set; }

        [Reference]
        public Table Table { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }
}
