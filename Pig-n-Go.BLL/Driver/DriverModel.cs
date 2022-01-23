using System;
using Pig_n_Go.BLL.Tariffs;

namespace Pig_n_Go.BLL.Driver
{
    public class DriverModel
    {
        public Guid Id { get; set; }
        public DriverInfo DriverInfo { get; set; }
        public CarInfo CarInfo { get; set; }
        public CartesianLocationUnit Location { get; set; }
        public DriverRating DriverRating { get; set; }
        public TariffModel Tariff { get; set; }
        public bool IsOnline { get; set; }
    }
}