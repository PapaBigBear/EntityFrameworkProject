using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Queries.Persistence;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMDContext context;

        public ICustomerRepository CustomerRepository { get; internal set; }
        public IOrderRepository OrderRepository { get; internal set; }
        public IOrderItemRepository OrderItemRepository { get; internal set; }
        public IItemRepository ItemRepository { get; internal set; }

        public UnitOfWork(CMDContext context)
        {
            this.context = context;
            this.CustomerRepository = new CustomerRepository(context);
            this.OrderRepository = new OrderRepository(context);
            this.OrderItemRepository = new OrderItemRepository(context);
            this.ItemRepository = new ItemRepository(context);
        }
        
        public void Commit()
        {
            context?.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
