using System;
using System.Threading.Tasks;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Common.Order;

namespace DriverClient.Tools
{
    public interface IDriverRequestService
    {
        Task<DriverDto> Register(DriverInfo driverInfo);
        Task<DriverDto> Login(Guid driverId);
        Task<OrderDto> AcceptOrder(Guid driverId, Guid orderId);
        Task FinishOrder(Guid orderId);
    }
}