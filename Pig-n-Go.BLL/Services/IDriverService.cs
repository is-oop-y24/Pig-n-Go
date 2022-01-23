using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;

namespace Pig_n_Go.BLL.Services
{
    public interface IDriverService
    {
        public DriverModel UpdateLocation(DriverModel driver, CartesianLocationUnit locationUnit);
        public DriverModel UpdateRating(DriverModel driverModel, OrderModel orderModel);
    }
}
