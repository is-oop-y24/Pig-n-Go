using System.Threading.Tasks;
using Pig_n_Go.Order;

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

        public Task HandleOrderAsync(OrderModel order)
        {
            throw new System.NotImplementedException();
        }

        public Task StopSearchAsync(OrderModel order)
        {
            throw new System.NotImplementedException();
        }

        public Task FinishOrderAsync(OrderModel order)
        {
            throw new System.NotImplementedException();
        }

        public Task EsteemDriverAsync(OrderModel order)
        {
            throw new System.NotImplementedException();
        }
    }
}