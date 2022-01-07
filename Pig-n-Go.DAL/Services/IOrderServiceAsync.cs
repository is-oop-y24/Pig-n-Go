using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.DAL.Services
{
    public interface IOrderServiceAsync
    {
        Task AddAsync(OrderModel order);
        Task<OrderModel> FindAsync(Guid id);
        Task<IReadOnlyCollection<OrderModel>> GetAllAsync();
        Task RemoveAsync(OrderModel order);
    }
}
