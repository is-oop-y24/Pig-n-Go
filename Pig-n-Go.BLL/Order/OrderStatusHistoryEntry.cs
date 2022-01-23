using System;

namespace Pig_n_Go.BLL.Order
{
    public class OrderStatusHistoryEntry
    {
        public Guid Id { get; init; }
        public DateTime Time { get; set; }
        public OrderStatus Status { get; set; }
    }
}