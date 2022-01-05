using System;
using System.Threading.Tasks;
using Pig_n_Go.Order;

namespace Pig_n_Go
{
    public class DrOrderRepositoryAsync : IOrderRepositoryAsync
    {
        public Task Add(OrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(OrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task Update(OrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}