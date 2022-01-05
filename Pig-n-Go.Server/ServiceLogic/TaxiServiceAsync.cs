using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Driver;
using Pig_n_Go.Order;
using Pig_n_Go.Passenger;

namespace Pig_n_Go
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

        public async Task HandleOrderAsync(OrderModel order)
        {
            throw new System.NotImplementedException();
        }

        public async Task StopSearchAsync(OrderModel order)
        {
            throw new System.NotImplementedException();
        }

        public async Task FinishOrderAsync(OrderModel order)
        {
            throw new System.NotImplementedException();
        }

        public async Task EsteemDriverAsync(OrderModel order)
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