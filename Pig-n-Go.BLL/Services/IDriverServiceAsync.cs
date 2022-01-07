using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;

namespace Pig_n_Go.BLL.Services
{
    public interface IDriverServiceAsync : IServiceAsync<DriverModel>
    {
        Task UpdateLocation(Guid driverId, Guid locationUnitId);
        Task UpdateRating(Guid driverId, Guid orderId);

        Task Login(Guid driverId);
        Task Logout(Guid driverId);
    }
}
