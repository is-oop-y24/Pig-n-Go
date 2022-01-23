using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pig_n_Go.BLL.Services.Tools;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.Core.Tools;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IDriverRepositoryAsync _driverRepository;
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly IDriverDistanceLimit _maxDriverDistance;
        private readonly ILogger<OrderServiceAsync> _logger;

        public OrderServiceAsync(
            IOrderRepositoryAsync orderRepository,
            IDriverRepositoryAsync driverRepository,
            IDistanceCalculator distanceCalculator,
            IDriverDistanceLimit maxDriverDistance,
            ILogger<OrderServiceAsync> logger)
        {
            _orderRepository = orderRepository;
            _driverRepository = driverRepository;
            _distanceCalculator = distanceCalculator;
            _maxDriverDistance = maxDriverDistance;
            _logger = logger;
        }

        public async Task<OrderModel> AddAsync(OrderModel model)
        {
            _logger.LogInformation("Add new order");

            return await _orderRepository.AddAsync(model);
        }

        public async Task<OrderModel> FindAsync(Guid id)
        {
            _logger.LogInformation($"Find order with id {id}");

            return await _orderRepository.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<OrderModel>> GetAllAsync()
        {
            _logger.LogInformation("Return all orders");

            return await _orderRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<OrderModel>> GetWhereAsync(Func<OrderModel, bool> predicate)
        {
            return await _orderRepository.GetWhereAsync(predicate);
        }

        public async Task UpdateAsync(OrderModel model)
        {
            _logger.LogInformation($"Update order with id {model.Id}");

            await _orderRepository.UpdateAsync(model);
        }

        public async Task RemoveAsync(Guid id)
        {
            _logger.LogInformation($"Remove order with id {id}");

            OrderModel order = await _orderRepository.FindAsync(id);
            await _orderRepository.RemoveAsync(order);
        }

        public async Task HandleOrderAsync(OrderModel order)
        {
            _logger.LogInformation("Handle new order");

            if (order is null)
                throw new ArgumentNullException(nameof(order));

            if (order.Status != OrderStatus.Created)
                throw new TaxiException($"Order status must be {OrderStatus.Created}");

            order.Status = OrderStatus.Searching;

            await AddAsync(order);
            List<DriverModel> drivers = await FindClosestDrivers(order.Route.LocationUnits.First());
            IEnumerable<Task> askingTasks = drivers.Select(AskDriver);
            await Task.WhenAll(askingTasks);
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            _logger.LogInformation($"Cancel order with id {orderId}");

            OrderModel order = await GetOrderAsync(orderId);
            order.Status = OrderStatus.Cancelled;
            await UpdateAsync(order);
        }

        public async Task FinishOrderAsync(Guid orderId)
        {
            _logger.LogInformation($"Finish order with id {orderId}");

            OrderModel order = await GetOrderAsync(orderId);
            order.Status = OrderStatus.Finished;
            await UpdateAsync(order);
        }

        public async Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            _logger.LogInformation($"Set order with id {orderId} status to: {newStatus}");

            OrderModel order = await GetOrderAsync(orderId);
            order.Status = newStatus;
            await UpdateAsync(order);
        }

        public async Task AcceptOrderAsync(Guid orderId, Guid driverId)
        {
            _logger.LogInformation($"Accept order. Order: {orderId} Driver: {driverId}");

            OrderModel order = await GetOrderAsync(orderId);
            if (order.Status != OrderStatus.Searching)
                throw new TaxiException("Order isn't active now.");

            DriverModel driverModel = await _driverRepository.FindAsync(driverId)
                                   ?? throw new TaxiException("Driver doesn't exist.");
            order.Driver = driverModel;
            order.Status = OrderStatus.Accepted;
            await Task.WhenAll(NotifyPassenger(order.Passenger), UpdateAsync(order));
        }

        public async Task DeclineOrderAsync(Guid orderId, Guid driverId)
        {
            // Do we need it?
            throw new NotImplementedException();
        }

        private async Task<List<DriverModel>> FindClosestDrivers(CartesianLocationUnit locationUnit)
        {
            _logger.LogInformation($"Find drivers closest to {locationUnit}");

            return new List<DriverModel>(
                await _driverRepository.GetWhereAsync(
                    driver =>
                        _distanceCalculator.GetDistance(driver.Location, locationUnit) < _maxDriverDistance.MaxValue));
        }

        private async Task<OrderModel> GetOrderAsync(Guid orderId)
        {
            _logger.LogInformation($"Return order with id {orderId}");

            return await FindAsync(orderId) ?? throw new TaxiException("Order doesn't exist.");
        }

        private async Task NotifyPassenger(PassengerModel orderPassenger)
        {
            _logger.LogInformation($"Notify passenger with id {orderPassenger.Id}");

            throw new NotImplementedException();
        }

        private async Task AskDriver(DriverModel driver)
        {
            _logger.LogInformation($"Ask driver with id {driver.Id}");

            throw new NotImplementedException();
        }
    }
}
