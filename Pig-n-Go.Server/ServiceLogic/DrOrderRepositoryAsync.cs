using System;
using System.Threading.Tasks;
using Pig_n_Go.Order;

namespace Pig_n_Go
{
    public class DrOrderRepositoryAsync : IOrderRepositoryAsync
    {
        public Task AddAsync(OrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(OrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}