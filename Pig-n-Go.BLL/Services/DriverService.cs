using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Core.Services
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
