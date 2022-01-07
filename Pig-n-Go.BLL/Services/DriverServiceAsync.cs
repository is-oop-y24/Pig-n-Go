using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class DriverServiceAsync : IDriverServiceAsync
    {
        private readonly IDriverRepositoryAsync _driverRepository;
        private readonly IOrderRepositoryAsync _orderRepository;

        public DriverServiceAsync(IDriverRepositoryAsync driverRepository, IOrderRepositoryAsync orderRepository)
        {
            _driverRepository = driverRepository;
            _orderRepository = orderRepository;
        }

        public async Task AddAsync(DriverModel order)
        {
            await _driverRepository.AddAsync(order);
        }

        public async Task<DriverModel> FindAsync(Guid id)
        {
            return await _driverRepository.FindAsync(id);
        }

        public Task<IReadOnlyCollection<DriverModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id)
        {
            DriverModel driver = await _driverRepository.FindAsync(id);
            await _driverRepository.RemoveAsync(driver);
        }

        public Task UpdateLocation(Guid driverId, Guid locationUnitId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRating(Guid driverId, Guid orderId)
        {
            DriverModel driver = await _driverRepository.FindAsync(driverId);
            OrderModel order = await _orderRepository.FindAsync(orderId);

            driver.DriverRating.RatingHistory.Add(order.Rating);
            await _driverRepository.UpdateAsync(driver);
        }

        public Task Login(Guid driverId)
        {
            throw new NotImplementedException();
        }

        public Task Logout(Guid driverId)
        {
            throw new NotImplementedException();
        }
    }
}
