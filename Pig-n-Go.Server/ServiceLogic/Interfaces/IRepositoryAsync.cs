using System;
using System.Threading.Tasks;

namespace Pig_n_Go
{
    public interface IRepositoryAsync<TModel>
        where TModel : class
    {
        Task AddAsync(TModel model);
        Task<TModel> GetAsync(Guid id);
        Task RemoveAsync(TModel model);
        Task UpdateAsync(TModel model);
    }
}