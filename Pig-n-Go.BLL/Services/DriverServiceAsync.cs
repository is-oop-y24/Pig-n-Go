using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class DriverServiceAsync : IDriverServiceAsync
    {
        private readonly IDriverRepositoryAsync _driverRepository;
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly ILogger<DriverServiceAsync> _logger;

        public DriverServiceAsync(
            IDriverRepositoryAsync driverRepository,
            IOrderRepositoryAsync orderRepository,
            ILogger<DriverServiceAsync> logger)
        {
            _driverRepository = driverRepository;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<DriverModel> AddAsync(DriverModel model)
        {
            _logger.LogInformation("Add new driver model.");

            return await _driverRepository.AddAsync(model);
        }

        public async Task<DriverModel> FindAsync(Guid id)
        {
            _logger.LogInformation($"Find driver with id {id}");

            return await _driverRepository.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<DriverModel>> GetAllAsync()
        {
            _logger.LogInformation("Return all drivers");

            return await _driverRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<DriverModel>> GetWhereAsync(Func<DriverModel, bool> predicate)
        {
            return await _driverRepository.GetWhereAsync(predicate);
        }

        public async Task UpdateAsync(DriverModel model)
        {
            _logger.LogInformation($"Update driver with id {model.Id}");

            await _driverRepository.UpdateAsync(model);
        }

        public async Task RemoveAsync(Guid id)
        {
            _logger.LogInformation($"Remove driver with id {id}");

            DriverModel driver = await _driverRepository.FindAsync(id);
            await _driverRepository.RemoveAsync(driver);
        }

        public async Task UpdateLocation(Guid driverId, CartesianLocationUnit locationUnit)
        {
            // Do we need to know about all the updates?
            // _logger.LogInformation($"Update location of driver with id {driverId}");
            DriverModel driver = await _driverRepository.FindAsync(driverId);

            driver.Location = locationUnit;
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task UpdateRating(Guid driverId, Guid orderId)
        {
            _logger.LogInformation($"Update rating of driver with id {driverId}");

            DriverModel driver = await _driverRepository.FindAsync(driverId);
            OrderModel order = await _orderRepository.FindAsync(orderId);

            driver.DriverRating.RatingHistory.Add(order.Rating);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task GoOnline(Guid driverId)
        {
            _logger.LogInformation($"Set driver with id {driverId} online");

            DriverModel driver = await _driverRepository.FindAsync(driverId);
            await _driverRepository.GoOnline(driver);
        }

        public async Task GoOffline(Guid driverId)
        {
            _logger.LogInformation($"Set driver with id {driverId} offline");

            DriverModel driver = await _driverRepository.FindAsync(driverId);
            await _driverRepository.GoOffline(driver);
        }
    }
}
