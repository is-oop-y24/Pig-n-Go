using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Order;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.DAL.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync _repository;
        public Task AddAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
