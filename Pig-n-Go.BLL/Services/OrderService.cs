using System.Threading.Tasks;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.BLL.Passenger;
using Pig_n_Go.BLL.Tools;

namespace Pig_n_Go.BLL.Services
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
            order.Status = OrderStatus.Cancelled;
            return await Task.FromResult(order);
        }

        public async Task<OrderModel> FinishOrderAsync(OrderModel order)
        {
            order.Status = OrderStatus.Finished;
            return await Task.FromResult(order);
        }

        private Task NotifyPassenger(PassengerModel orderPassenger)
        {
            return Task.CompletedTask;
        }
    }
}
