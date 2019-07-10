using System.Linq;
using DomainLayer.Models;
using Queries.Persistence;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using RepositoryLayer.Repositories;
using System;

namespace DataAccessLayer.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CMDContext context) : base(context)
        {
        
        }

        public override bool Exist(Guid customerId)
        {
            return context.Customers.Any(x => x.CustomerId == customerId);
        }

        public override Customer GetById(Guid id)
        {
            return context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomersByKeyword(string keyword)
        {
            return context.Customers.Where(x => x.CustomerName.Contains(keyword));
        }
    }
}
