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

        public async Task<OrderModel> HandleOrderAsync(OrderModel order, List<DriverModel> drivers)
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            if (order.Status != OrderStatus.Created)
                throw new TaxiException($"Order status must be {OrderStatus.Created}");

            order.Status = OrderStatus.Searching;
            IEnumerable<Task> askingTasks = drivers.Select(AskDriver);

            await Task.WhenAll(askingTasks);

            return order;
        }

        public async Task<OrderModel> CancelOrderAsync(OrderModel order)
        {
            order.Status = OrderStatus.Cancelled;
            return await Task.FromResult(order);
        }

        public async Task<OrderModel> FinishOrderAsync(OrderModel order)
        {
            order.Status = OrderStatus.Finished;
            return await Task.FromResult(order);
        }

        public async Task<OrderModel> AcceptOrderAsync(OrderModel order, DriverModel driver)
        {
            if (order.Status != OrderStatus.Searching)
                throw new TaxiException("Order isn't active now.");
            order.Driver = driver;
            order.Status = OrderStatus.Accepted;
            await NotifyPassenger(order.Passenger);

            return order;
        }

        public async Task<OrderModel> DeclineOrderAsync(OrderModel order, DriverModel driver)
        {
            // Do we need it?
            throw new NotImplementedException();
        }

        public async Task<List<DriverModel>> FindClosestDrivers(
            List<DriverModel> drivers,
            CartesianLocationUnit locationUnit)
        {
            var task = Task.Run(
                () =>
                {
                    return drivers.Where(
                                      model => _distanceCalculator.GetDistance(model.Location, locationUnit)
                                             < _maxDriverDistance.MaxValue)
                                  .ToList();
                });

            return await task;
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
