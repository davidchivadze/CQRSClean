using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Repository;
using Crypto.Infrastructure.Store;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Crypto.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly CryptoContext _CryptoContext;
        public readonly DbSet<T> _DbSet;
        public BaseRepository(CryptoContext cryptoContext)
        {

           _CryptoContext = cryptoContext;
            _DbSet = cryptoContext.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            await _DbSet.AddAsync(entity);
            return entity;

        }
        public async Task<T> AddAsync(T entity)
        {
            await _DbSet.AddAsync(entity);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _DbSet.AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _DbSet.Remove(entity);

        }

        public void Update(T entity)
        {
            _CryptoContext.Update(entity);
          // _CryptoContext.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
             _CryptoContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _CryptoContext.SaveChangesAsync();
        }
    }
}
