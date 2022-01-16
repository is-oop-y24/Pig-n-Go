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

        public async Task<DriverModel> AddAsync(DriverModel model)
        {
            return await _driverRepository.AddAsync(model);
        }

        public async Task<DriverModel> FindAsync(Guid id)
        {
            return await _driverRepository.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<DriverModel>> GetAllAsync()
        {
            return await _driverRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<DriverModel>> GetWhereAsync(Func<DriverModel, bool> predicate)
        {
            return await _driverRepository.GetWhereAsync(predicate);
        }

        public async Task UpdateAsync(DriverModel model)
        {
            await _driverRepository.UpdateAsync(model);
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

        public async Task GoOnline(Guid driverId)
        {
            DriverModel driver = await _driverRepository.FindAsync(driverId);
            await _driverRepository.GoOnline(driver);
        }

        public async Task GoOffline(Guid driverId)
        {
            DriverModel driver = await _driverRepository.FindAsync(driverId);
            await _driverRepository.GoOffline(driver);
        }
    }
}
