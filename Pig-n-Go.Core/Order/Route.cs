using System;
using System.Collections.Generic;
using Pig_n_Go.Driver;

namespace Pig_n_Go.Core.Order
{
    public class Route
    {
        public Guid Id { get; init; }
        public List<CartesianLocationUnit> LocationUnits { get; set; }
    }
}