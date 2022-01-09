using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IDistanceMeter _distanceMeter;
        private readonly decimal _maxDriverDistance;

        public OrderServiceAsync(IOrderRepositoryAsync orderRepository, IDriverRepositoryAsync driverRepository, IDistanceMeter distanceMeter, decimal maxDriverDistance)
        {
            _orderRepository = orderRepository;
            _driverRepository = driverRepository;
            _distanceMeter = distanceMeter;
            _maxDriverDistance = maxDriverDistance;
        }
        
        public async Task AddAsync(OrderModel model)
        {
            await _orderRepository.AddAsync(model);
        }
        
        public async Task<OrderModel> FindAsync(Guid id)
        {
            return await _orderRepository.FindAsync(id);
        }
        
        public async Task<IReadOnlyCollection<OrderModel>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }
        
        public async Task<IReadOnlyCollection<OrderModel>> GetWhereAsync(Func<OrderModel, bool> predicate)
        {
            return await _orderRepository.GetWhereAsync(predicate);
        }
        
        public async Task UpdateAsync(OrderModel model)
        {
            await _orderRepository.UpdateAsync(model);
        }
        
        public async Task RemoveAsync(Guid id)
        {
            OrderModel order = await _orderRepository.FindAsync(id);
            await _orderRepository.RemoveAsync(order);
        }

        public async Task HandleOrderAsync(OrderModel order)
        {
            if (order == null)
                throw new NullReferenceException(nameof(order));
            if (order.Status != OrderStatus.Created)
                throw new TaxiException($"Order status must be {OrderStatus.Created}");
            order.Status = OrderStatus.Search;
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
            if (order.Status != OrderStatus.Search)
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
            return new List<DriverModel>(await _driverRepository.GetWhereAsync(driver =>
                _distanceMeter.GetDistance(driver.Location, locationUnit) < _maxDriverDistance));
        }

        private async Task<OrderModel> GetOrderAsync(Guid orderId)
        {
            return await FindAsync(orderId) ?? 
                   throw new TaxiException("Order doesn't exist.");
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
