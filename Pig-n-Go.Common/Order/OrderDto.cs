using System;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Common.Passenger;
using Pig_n_Go.Common.Tariff;

namespace Pig_n_Go.Common.Order
{
    public class OrderDto
    {
        public Guid Id { get; init; }
        public Route Route { get; init; }
        public PassengerDto Passenger { get; init; }
        public DriverDto Driver { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime UpdateDate { get; set; }
        public OrderRating Rating { get; set; }
        public TariffDto Tariff { get; init; }
        public OrderStatus Status { get; set; }
        public OrderStatusHistory StatusHistory { get; init; } = new OrderStatusHistory();
    }
}