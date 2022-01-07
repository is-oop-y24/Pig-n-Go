using System;
using System.Threading.Tasks;

namespace Pig_n_Go.DAL.Repositories
{
    public interface IRepositoryAsync<TModel>
        where TModel : class
    {
        Task AddAsync(TModel model);
        Task<TModel> FindAsync(Guid id);
        Task RemoveAsync(TModel model);
        Task UpdateAsync(TModel model);
    }
}