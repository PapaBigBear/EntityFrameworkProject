using System;

namespace RepositoryLayer.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        bool Exist(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
