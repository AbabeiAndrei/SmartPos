using System;
using System.Linq;

using SmartPos.DomainModel.Entities;
using SmartPos.GeneralLibrary.Extensions;

namespace SmartPos.DomainModel.Extensions
{
    public static class OrderExtensions
    {
        public static decimal CalculateTotal(this Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return order.Items?.Select(oi => oi.CalculateTotal()).DefaultIfEmpty(0m).Sum() ?? 0m;
        }
        
        public static decimal CalculateTotal(this OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            return orderItem.UnitPrice.CalculateTotalPrice(orderItem.Quantity);
        }
    }
}
