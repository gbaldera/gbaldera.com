using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GBaldera.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GBaldera.Data.Ef
{
    public class EfRepository<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly StorageContext _dbContext;
        private readonly DbSet<TModel> _dbSet;

        public EfRepository(StorageContext storageContext)
        {
            _dbContext = storageContext;
            _dbSet = _dbContext?.Set<TModel>();
        }

        public Task InsertAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetByAsync(Expression<Func<TModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
