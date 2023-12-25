using Crypto.Domain.Models.EntityModels;

namespace Crypto.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task SaveAsync();
    }
}
