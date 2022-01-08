using System;

namespace Pig_n_Go.Core.Order
{
    public class OrderStatusHistoryEntry :
        IEquatable<OrderStatusHistoryEntry>,
        IComparable<OrderStatusHistoryEntry>
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Time { get; set; }
        public OrderStatus Status { get; set; }


        public bool Equals(OrderStatusHistoryEntry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderStatusHistoryEntry)obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public int CompareTo(OrderStatusHistoryEntry other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Time.CompareTo(other.Time);
        }
    }
}