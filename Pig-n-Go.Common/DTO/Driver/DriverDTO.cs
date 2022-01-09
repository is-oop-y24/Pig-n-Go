using System;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Common.DTO.Driver
{
    public class DriverDTO
    {
        public Guid Id { get; init; }
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
        public DriverRating DriverRating { get; set; }
        public Tariff Tariff { get; set; }
    }
}