using System;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Common.DTO.Order
{
    public class OrderCreationArguments
    {
        public Route Route { get; init; }
        public PassengerModel Passenger { get; init; }
        public DriverModel Driver { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime UpdateDate { get; set; }
        public OrderRating Rating { get; set; }
        public Tariff Tariff { get; init; }
        public OrderStatus Status { get; set; }
    }
}