using System;

namespace Pig_n_Go.Driver
{
    public class CarInfo
    {
        public Guid Id { get; init; }
        public string ModelName { get; set; }
        public string CarNumber { get; set; }
        public string Color { get; set; }
    }
}