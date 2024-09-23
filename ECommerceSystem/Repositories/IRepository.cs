using System.Collections.Generic;

namespace ECommerceSystem.Repositories
{
    /// <summary>
    /// This interface defines the standard CRUD operations for a repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
