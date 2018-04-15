using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SmartPos.DomainModel.Entities;

namespace SmartPos.Desktop.Handlers
{
    public delegate Task OrderSentEventHandler(object sender, IOrderSentEventArgs args); 

    public class OrderSentEventArgs : IOrderSentEventArgs
    {
        public Order Order { get; }

        public OrderSentEventArgs(Order order)
        {
            Order = order;
        }
    }

    public interface IOrderSentEventArgs
    {
        Order Order { get; }
    }
}
