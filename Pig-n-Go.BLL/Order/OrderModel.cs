using System;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Core.Order
{
    public class OrderModel
    {
        public Guid Id { get; init; }
        public Route Route { get; init; }
        public PassengerModel Passenger { get; set; }
        public DriverModel Driver { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public OrderRating Rating { get; set; }
        public TariffModel Tariff { get; set; }

        public OrderStatus Status { get; set; }
        public OrderStatusHistory StatusHistory { get; init; } = new OrderStatusHistory();
    }
}