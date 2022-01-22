using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pig_n_Go.DAL.Repositories
{
    public interface IRepositoryAsync<TModel>
        where TModel : class
    {
        Task<TModel> AddAsync(TModel model);
        Task<TModel> FindAsync(Guid id);
        Task<IReadOnlyCollection<TModel>> GetAllAsync();
        Task<IReadOnlyCollection<TModel>> GetWhereAsync(Func<TModel, bool> predicate);
        Task RemoveAsync(TModel model);
        Task UpdateAsync(TModel model);
    }
}