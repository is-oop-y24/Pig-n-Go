using System;
using Pig_n_Go.Passenger;

namespace Pig_n_Go.Order
{
    public class OrderRating
    {
        public Guid Id { get;  init; }
        public int Rating { get; init; }
        public PassengerModel Author { get; init; }
    }
}