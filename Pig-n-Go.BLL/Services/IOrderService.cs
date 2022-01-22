using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Core.Services
{
    public interface IOrderService
    {
        Task HandleOrderAsync(OrderModel order);
        Task CancelOrderAsync(Guid orderId);
        Task AcceptOrderAsync(Guid orderId, Guid driverId);
        Task DeclineOrderAsync(Guid orderId, Guid driverId);
        Task FinishOrderAsync(Guid orderId);
    }
}
