using System.Threading.Tasks;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.BLL.Tariffs;

namespace Pig_n_Go.BLL.Services
{
    public interface IDriverService
    {
        public Task<DriverModel> UpdateLocation(DriverModel driverModel, CartesianLocationUnit locationUnit);
        public Task<DriverModel> UpdateRating(DriverModel driverModel, OrderModel orderModel);
        public Task<DriverModel> GoOnline(DriverModel driverModel, TariffModel tariffModel);
        public Task<DriverModel> GoOffline(DriverModel driverModel);
    }
}
