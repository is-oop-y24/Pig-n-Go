using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;

namespace Pig_n_Go.BLL.Services
{
    public class DriverService : IDriverService
    {
        public DriverModel UpdateLocation(DriverModel driver, CartesianLocationUnit locationUnit)
        {
            driver.Location = locationUnit;
            return driver;
        }

        public DriverModel UpdateRating(DriverModel driverModel, OrderModel orderModel)
        {
            driverModel.DriverRating.RatingHistory.Add(orderModel.Rating);
            return driverModel;
        }
    }
}
