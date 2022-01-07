using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.BLL.Services
{
    public interface IOrderServiceAsync : IServiceAsync<OrderModel>
    {
        Task AddDriver(Guid orderId, Guid driverId);

        Task AcceptOrder(Guid orderId);
        Task DeclineOrder(Guid orderId);
        Task FinishOrder(Guid orderId);
    }
}
