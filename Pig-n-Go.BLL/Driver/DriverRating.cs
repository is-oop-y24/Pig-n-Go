using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Core.Driver
{
    public class DriverRating
    {
        public Guid Id { get; init; }
        public List<OrderRating> RatingHistory { get; private init; } = new List<OrderRating>();

        [JsonIgnore]
        public double AverageRating
        {
            get { return RatingHistory.Select(rh => rh.Rating).Average(); }
        }
    }
}