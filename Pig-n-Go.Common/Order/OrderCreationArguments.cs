using System;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.Common.Passenger;

namespace Pig_n_Go.Common.Order
{
    public class OrderCreationArguments
    {
        public Route Route { get; init; }
        public PassengerDto Passenger { get; set; }
        public Guid TariffId { get; init; }
    }
}