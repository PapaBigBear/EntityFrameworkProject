using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetOrderItemsByOrderId(Guid orderId);
    }
}
