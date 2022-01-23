using System;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.Common.Tariff;

namespace Pig_n_Go.Common.Driver
{
    public class DriverDto
    {
        public Guid Id { get; init; }
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
        public DriverRating DriverRating { get; set; }
        public TariffDto Tariff { get; set; }
    }
}