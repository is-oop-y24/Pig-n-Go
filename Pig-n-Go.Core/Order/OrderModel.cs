using System;
using System.Linq;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Core.Order
{
    public class OrderModel
    {
        private OrderStatus _status;

        public Guid Id { get; init; }
        public Route Route { get; init; }
        public PassengerModel Passenger { get; init; }
        public DriverModel Driver { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime UpdateDate { get; set; }
        public OrderRating Rating { get; set; }
        public Tariff Tariff { get; init; }

        public OrderStatus Status
        {
            get => _status;
            set
            {
                StatusHistory.Entries.Add(new OrderStatusHistoryEntry
                    { Status = value, Time = DateTime.Now });
                _status = value;
            }
        }

        public OrderStatusHistory StatusHistory { get; init; } = new OrderStatusHistory();
    }
}