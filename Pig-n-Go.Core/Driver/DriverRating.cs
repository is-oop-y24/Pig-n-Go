using System;
using System.Collections.Generic;
using System.Linq;
using Pig_n_Go.Order;

namespace Pig_n_Go.Driver
{
    public class DriverRating
    {
        public Guid Id { get; init; }
        public List<OrderRating> RatingHistory { get; private init; } = new List<OrderRating>();

        public double AvrRating
        {
            get { return RatingHistory.Select(rh => rh.Rating).Average(); }
            private init { }
        }
    }
}