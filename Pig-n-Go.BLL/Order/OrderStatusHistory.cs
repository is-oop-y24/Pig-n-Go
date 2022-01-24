using System;
using System.Collections.Generic;

namespace Pig_n_Go.BLL.Order
{
    public class OrderStatusHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<OrderStatusHistoryEntry> Entries { get; set; } = new List<OrderStatusHistoryEntry>();
    }
}