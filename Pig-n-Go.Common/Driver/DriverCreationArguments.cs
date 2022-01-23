using Pig_n_Go.BLL.Driver;

namespace Pig_n_Go.Common.Driver
{
    public class DriverCreationArguments
    {
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
    }
}