using System;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Common.Passenger;
using Pig_n_Go.Common.Tariff;

namespace Pig_n_Go.Common.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Route Route { get; set; }
        public PassengerDto Passenger { get; set; }
        public DriverDto Driver { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public OrderRating Rating { get; set; }
        public TariffDto Tariff { get; set; }
        public OrderStatus Status { get; set; }
        public OrderStatusHistory StatusHistory { get; set; } = new OrderStatusHistory();
    }
}