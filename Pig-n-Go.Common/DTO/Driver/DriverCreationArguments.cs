using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Common.DTO.Driver
{
    public class DriverCreationArguments
    {
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
        public TariffModel Tariff { get; set; }
    }
}