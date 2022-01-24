using System.Threading.Tasks;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;

namespace Pig_n_Go.BLL.Services
{
    public interface IOrderService
    {
        Task<OrderModel> AcceptOrderAsync(OrderModel order, DriverModel driver);
        Task<OrderModel> DeclineOrderAsync(OrderModel order, DriverModel driver);
        Task<OrderModel> FinishOrderAsync(OrderModel order);
    }
}
