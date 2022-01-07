using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class TaxiServiceAsync : ITaxiServiceAsync
    {
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IPassengerRepositoryAsync _passengerRepository;
        private readonly IDriverRepositoryAsync _driverRepository;

        public TaxiServiceAsync(IDriverRepositoryAsync driverRepository, IPassengerRepositoryAsync passengerRepository, IOrderRepositoryAsync orderRepository)
        {
            _driverRepository = driverRepository;
            _passengerRepository = passengerRepository;
            _orderRepository = orderRepository;
        }

        public async Task HandleOrderAsync(Guid orderId)
        {
            throw new System.NotImplementedException();
        }

        public async Task StopSearchAsync(Guid orderId)
        {
            throw new System.NotImplementedException();
        }

        public async Task FinishOrderAsync(Guid orderId)
        {
            throw new System.NotImplementedException();
        }

        public async Task EsteemDriverAsync(Guid orderId)
        {
            throw new System.NotImplementedException();
        }

        private Task<List<DriverModel>> FindClosestDrivers(CartesianLocationUnit location)
        {
            throw new NotImplementedException();
        }

        private Task NotifyPassenger(PassengerModel passengerModel)
        {
            throw new NotImplementedException();
        }

        private Task MakePayment(OrderModel order)
        {
            throw new NotImplementedException();
        }

        private Task AskDriver(OrderModel order, DriverModel driver)
        {
            throw new NotImplementedException();
        }
    }
}