using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

using SmartPos.DomainModel.Base;

namespace SmartPos.DomainModel.Entities
{
    public enum OrderItemState : short
    {
        Active = 0,
        Added = 1,
        Storno = 2,
        Void = 3
    }

    public class OrderItem : Entity, ISoftDeletable
    {
        [Required]
        [References(typeof(Order))]
        public int OrderId { get; set; }

        [Required]
        [References(typeof(Product))]
        public int ProductId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [CustomField("DECIMAL(10,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public float Quantity { get; set; }

        [Required]
        [References(typeof(User))]
        public int CretedBy { get; set; }

        [Required]
        [Default(OrmLiteVariables.SystemUtc)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Default((int) OrderItemState.Active)]
        public OrderItemState State { get; set; }

        #region Implementation of ISoftDeletable

        /// <inheritdoc />
        [Default(typeof(bool), "0")]
        public bool Deleted { get; set; }

        #endregion
    }

    public static class OrderItemUtils
    {
        public static bool IsValidForOrder(this OrderItemState state)
        {
            return state == OrderItemState.Active || state == OrderItemState.Added;
        }
    }
}
