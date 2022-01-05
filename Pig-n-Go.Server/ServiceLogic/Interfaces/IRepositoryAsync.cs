using System;
using System.Threading.Tasks;

namespace Pig_n_Go
{
    public interface IRepositoryAsync<TModel> where TModel : class
    {
        Task Add(TModel model);
        Task<TModel> Get(Guid id);
        Task Remove(TModel model);
        Task Update(TModel model);
    }
}