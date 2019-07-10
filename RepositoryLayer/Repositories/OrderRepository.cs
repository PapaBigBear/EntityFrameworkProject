using System;
using System.Linq;
using DomainLayer.Models;
using Queries.Persistence;
using DataAccessLayer.Interfaces;
using RepositoryLayer.Repositories;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(CMDContext context) : base(context)
        {
        
        }

        public override bool Exist(Guid orderId)
        {
            return context.Orders.Any(x => x.OrderId == orderId);
        }

        public override Order GetById(Guid id)
        {
            return context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
        }
    }
}
