using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Tariffs;
using Pig_n_Go.Driver;

namespace Pig_n_Go.Core.DTO.Driver
{
    public class DriverCreateArguments
    {
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
        public DriverRating DriverRating { get; set; }
        public Tariff Tariff { get; set; }
    }
}