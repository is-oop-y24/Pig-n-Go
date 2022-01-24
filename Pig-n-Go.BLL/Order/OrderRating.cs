using System;
using Pig_n_Go.BLL.Passenger;

namespace Pig_n_Go.BLL.Order
{
    public class OrderRating
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public PassengerModel Author { get; init; }
    }
}