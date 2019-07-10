using Queries.Persistence;
using RepositoryLayer.Interfaces;
using System;

namespace RepositoryLayer.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CMDContext context;

        public Repository(CMDContext context)
        {
            this.context = context;
        }

        public abstract bool Exist(Guid id);
        public abstract T GetById(Guid id);

        public void Add(T entity)
        {
            context.Add(entity);
        }

        public void Remove(T entity)
        {
            context.Remove(entity);
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}
