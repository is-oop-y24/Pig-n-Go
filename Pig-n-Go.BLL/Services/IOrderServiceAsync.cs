using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.BLL.Services
{
    public interface IOrderServiceAsync : IServiceAsync<OrderModel>
    {
        Task HandleOrderAsync(OrderModel order);
        Task CancelOrderAsync(Guid orderId);
        Task AcceptOrderAsync(Guid orderId, Guid driverId);
        Task DeclineOrderAsync(Guid orderId, Guid driverId);
        Task FinishOrderAsync(Guid orderId);
    }
}
