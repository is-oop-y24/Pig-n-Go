using System;
using Pig_n_Go.Driver;
using Pig_n_Go.Passenger;

namespace Pig_n_Go.Order
{
    public class OrderModel
    {
        public Guid Id { get; init; }
        public OrderStatus Status { get; set; }
        public Route Route { get; init; }
        public PassengerModel Passenger { get; init; }
        public DriverModel Driver { get; set; }
        public DateTime CreateDateTime { get; init; }
        public DateTime UpdateDateTime { get; set; }
    }
}