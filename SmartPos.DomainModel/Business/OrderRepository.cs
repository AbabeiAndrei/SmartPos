using System;
using System.Linq;

using SmartPos.DomainModel.Business.Exceptions;
using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Extensions;
using SmartPos.DomainModel.Interfaces;

namespace SmartPos.DomainModel.Business
{
    public class OrderRepository : ICrudRepositotry<Order>
    {
        #region Fields

        private readonly IDbContext _context;

        #endregion

        #region Constructors

        public OrderRepository(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Implementation of ICrudRepositotry<Order>
        
        public void Add(Order entity)
        {
            if (entity.Id != 0)
                throw new EntityNotNewException();

            entity.State = OrderState.Active;
            entity.Created = DateTime.Now;

            _context.Insert(entity);

            foreach (var item in entity.Items)
            {
                item.OrderId = entity.Id;
                item.CretedBy = entity.UserId;
                item.CreatedAt = DateTime.Now;

                _context.Insert(item);
            }
        }
        
        public void Save(Order entity)
        {
            if (entity.Id == 0)
                throw new EntityIsNewException();

            _context.Update(entity);

            foreach (var item in entity.Items)
                if (item.Id == 0)
                {
                    item.OrderId = entity.Id;
                    item.CretedBy = entity.UserId;
                    item.CreatedAt = DateTime.Now;

                    _context.Insert(item);
                }
                else 
                    _context.Update(item);

            if (entity.Items.Count(i => !i.Deleted) == 0)
                Delete(entity);
        }
        
        public void Delete(Order entity)
        {
            entity.State = OrderState.Closed;

            _context.Delete(entity);

            foreach (var item in entity.Items)
                _context.Delete(item);
        }
        
        public Order GetById(int id)
        {
            var order = _context.FirstOrDefault<Order>(o => o.Id == id);

            if (order == null)
                return null;

            order.Items = _context.Where<OrderItem>(oi => oi.OrderId == id);

            return order;
        }

        #endregion
    }
}
