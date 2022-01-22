using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.Core.Tools;

namespace Pig_n_Go.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly DriverDistanceLimit _maxDriverDistance;

        public OrderService(
            IDistanceCalculator distanceCalculator,
            DriverDistanceLimit maxDriverDistance)
        {
            _distanceCalculator = distanceCalculator;
            _maxDriverDistance = maxDriverDistance;
        }

        public async Task HandleOrderAsync(OrderModel order)
        {
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
            OrderModel order = await GetOrderAsync(orderId);
            order.Status = OrderStatus.Cancelled;
            await UpdateAsync(order);
        }

        public async Task FinishOrderAsync(Guid orderId)
        {
            OrderModel order = await GetOrderAsync(orderId);
            order.Status = OrderStatus.Finished;
            await UpdateAsync(order);
        }

        public async Task AcceptOrderAsync(Guid orderId, Guid driverId)
        {
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
            return new List<DriverModel>(
                await _driverRepository.GetWhereAsync(
                    driver =>
                        _distanceCalculator.GetDistance(driver.Location, locationUnit) < _maxDriverDistance.MaxValue));
        }

        private async Task<OrderModel> GetOrderAsync(Guid orderId)
        {
            return await FindAsync(orderId) ?? throw new TaxiException("Order doesn't exist.");
        }

        private async Task NotifyPassenger(PassengerModel orderPassenger)
        {
            throw new NotImplementedException();
        }

        private async Task AskDriver(DriverModel driver)
        {
            throw new NotImplementedException();
        }
    }
}
