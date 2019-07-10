using System.Linq;
using DomainLayer.Models;
using Queries.Persistence;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;
using RepositoryLayer.Repositories;
using System;

namespace DataAccessLayer.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(CMDContext context) : base(context)
        {
        
        }

        public override bool Exist(Guid itemId)
        {
            return context.Items.Any(x => x.ItemId == itemId);
        }

        public override Item GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
