using System;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.Core.Order
{
    public class OrderRating
    {
        public Guid Id { get;  init; }
        public int Rating { get; init; }
        public PassengerModel Author { get; init; }
    }
}