using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GBaldera.Data.Abstractions
{
    public interface IRepository<TModel>
    {
        Task InsertAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<TModel> GetAsync(int id);
        Task<TModel> GetByAsync(Expression<Func<TModel, bool>> predicate);
        Task<IEnumerable<TModel>> GetAllAsync();
    }
}
