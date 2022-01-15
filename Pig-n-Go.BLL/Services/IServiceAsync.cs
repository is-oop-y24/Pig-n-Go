using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pig_n_Go.BLL.Services
{
    public interface IServiceAsync<TModel>
        where TModel : class
    {
        Task AddAsync(TModel model);
        Task<TModel> FindAsync(Guid id);
        Task<IReadOnlyCollection<TModel>> GetAllAsync();
        Task<IReadOnlyCollection<TModel>> GetWhereAsync(Func<TModel, bool> predicate);
        Task UpdateAsync(TModel model);
        Task RemoveAsync(Guid id);
    }
}
