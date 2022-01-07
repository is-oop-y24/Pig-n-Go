using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IDriverRepositoryAsync _driverRepository;

        public OrderServiceAsync(IOrderRepositoryAsync orderRepository, IDriverRepositoryAsync driverRepository)
        {
            _orderRepository = orderRepository;
            _driverRepository = driverRepository;
        }

        public async Task AddAsync(OrderModel order)
        {
            await _orderRepository.AddAsync(order);
        }

        public async Task<OrderModel> FindAsync(Guid id)
        {
            return await _orderRepository.FindAsync(id);
        }

        public Task<IReadOnlyCollection<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id)
        {
            OrderModel order = await _orderRepository.FindAsync(id);
            await _orderRepository.RemoveAsync(order);
        }

        public async Task AddDriver(Guid orderId, Guid driverId)
        {
            OrderModel order = await _orderRepository.FindAsync(orderId);
            DriverModel driver = await _driverRepository.FindAsync(driverId);

            order.Driver = driver;
            await _orderRepository.UpdateAsync(order);
        }

        public Task AcceptOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task DeclineOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task FinishOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
