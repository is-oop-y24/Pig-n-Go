using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Order;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public interface IServiceAsync<TModel>
        where TModel : class
    {
        public Task AddAsync(TModel model);
        public Task<TModel> FindAsync(Guid id);
        public Task<IReadOnlyCollection<TModel>> GetAllAsync();
        public Task RemoveAsync(Guid id);
    }
}
