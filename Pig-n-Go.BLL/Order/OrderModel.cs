using System;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Passenger;
using Pig_n_Go.BLL.Tariffs;

namespace Pig_n_Go.BLL.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Route Route { get; set; }
        public PassengerModel Passenger { get; set; }
        public DriverModel Driver { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public OrderRating Rating { get; set; }
        public TariffModel Tariff { get; set; }

        public OrderStatus Status { get; set; }
        public OrderStatusHistory StatusHistory { get; set; } = new OrderStatusHistory();
    }
}