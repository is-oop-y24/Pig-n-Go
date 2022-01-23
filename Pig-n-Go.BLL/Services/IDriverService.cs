using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Core.Services
{
    public interface IDriverService
    {
        public DriverModel UpdateLocation(DriverModel driver, CartesianLocationUnit locationUnit);
        public DriverModel UpdateRating(DriverModel driverModel, OrderModel orderModel);
    }
}
