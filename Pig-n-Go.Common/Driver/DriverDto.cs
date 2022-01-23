using System;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Common.Driver
{
    public class DriverDto
    {
        public Guid Id { get; init; }
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
        public DriverRating DriverRating { get; set; }
        public TariffModel Tariff { get; set; }
    }
}