using Pig_n_Go.Common.Tariff;
using Pig_n_Go.Core.Driver;

namespace Pig_n_Go.Common.Driver
{
    public class DriverCreationArguments
    {
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
        public TariffCreationArguments Tariff { get; set; }
    }
}