using System.Linq;
using DomainLayer.Models;
using Queries.Persistence;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using RepositoryLayer.Repositories;
using System;

namespace DataAccessLayer.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(CMDContext context) : base(context)
        {
        
        }

        public override bool Exist(Guid orderItemId)
        {
            return context.OrderItems.Any(x => x.OrderItemId == orderItemId);
        }

        public override OrderItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> GetOrderItemsByOrderId(Guid orderId)
        {
            return context.OrderItems.Where(x => x.OrderId == orderId);
        }
    }
}
