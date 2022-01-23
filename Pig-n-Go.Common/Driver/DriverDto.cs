using System;
using Pig_n_Go.Common.Tariff;
using Pig_n_Go.Core.Driver;

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