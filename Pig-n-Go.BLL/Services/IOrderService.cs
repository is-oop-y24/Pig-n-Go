using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Core.Services
{
    public interface IOrderService
    {
        Task<OrderModel> HandleOrderAsync(OrderModel order, List<DriverModel> drivers);
        Task<OrderModel> CancelOrderAsync(OrderModel order);
        Task<OrderModel> AcceptOrderAsync(OrderModel order, DriverModel driver);
        Task<OrderModel> DeclineOrderAsync(OrderModel order, DriverModel driver);
        Task<List<DriverModel>> FindClosestDrivers(List<DriverModel> drivers, CartesianLocationUnit locationUnit);
        Task<OrderModel> FinishOrderAsync(OrderModel order);
    }
}
