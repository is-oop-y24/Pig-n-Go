using System;
using Pig_n_Go.Passenger;

namespace Pig_n_Go.Order
{
    public class OrderRating
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public PassengerModel Author { get; set; }
    }
}