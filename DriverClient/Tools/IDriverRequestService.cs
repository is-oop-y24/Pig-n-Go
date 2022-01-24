using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Common.Order;
using Pig_n_Go.Common.Tariff;

namespace DriverClient.Tools
{
    public interface IDriverRequestService
    {
        Task<DriverDto> Register(DriverInfo driverInfo);
        Task<DriverDto> Login(Guid driverId);
        Task<OrderDto> AcceptOrder(Guid driverId, Guid orderId);
        Task FinishOrder(Guid orderId);
        Task<TariffDto[]> GetTariffs();
        Task GoOnline(Guid driverId, Guid tariffId);
    }
}