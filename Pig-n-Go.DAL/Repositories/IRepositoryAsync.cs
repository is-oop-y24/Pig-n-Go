using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pig_n_Go.DAL.Repositories
{
    public interface IRepositoryAsync<TModel>
        where TModel : class
    {
        Task AddAsync(TModel model);
        Task<TModel> FindAsync(Guid id);
        Task<IReadOnlyCollection<TModel>> GetAll();
        Task<IReadOnlyCollection<TModel>> GetWhere(Func<TModel, bool> predicate);
        Task RemoveAsync(TModel model);
        Task UpdateAsync(TModel model);
    }
}