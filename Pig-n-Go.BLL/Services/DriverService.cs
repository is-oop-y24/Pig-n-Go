using System.Threading.Tasks;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.BLL.Tariffs;

namespace Pig_n_Go.BLL.Services
{
    public class DriverService : IDriverService
    {
        public Task<DriverModel> UpdateLocation(DriverModel driverModel, CartesianLocationUnit locationUnit)
        {
            driverModel.Location = locationUnit;
            return Task.FromResult(driverModel);
        }

        public Task<DriverModel> UpdateRating(DriverModel driverModel, OrderModel orderModel)
        {
            driverModel.DriverRating.RatingHistory.Add(orderModel.Rating);
            return Task.FromResult(driverModel);
        }

        public Task<DriverModel> GoOnline(DriverModel driverModel, TariffModel tariffModel)
        {
            driverModel.IsOnline = true;
            driverModel.Tariff = tariffModel;
            return Task.FromResult(driverModel);
        }

        public Task<DriverModel> GoOffline(DriverModel driverModel)
        {
            driverModel.IsOnline = false;
            driverModel.Tariff = null;
            return Task.FromResult(driverModel);
        }
    }
}
