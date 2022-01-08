using System;
using System.Collections.Generic;

namespace Pig_n_Go.Core.Order
{
    public class OrderStatusHistory
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public SortedSet<OrderStatusHistoryEntry> Entries { get; init; } = new SortedSet<OrderStatusHistoryEntry>();
    }
}