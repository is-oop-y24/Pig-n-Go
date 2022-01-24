using System;
using System.Collections.Generic;
using Pig_n_Go.BLL.Driver;

namespace Pig_n_Go.BLL.Order
{
    public class Route
    {
        public Guid Id { get; set; }
        public List<CartesianLocationUnit> LocationUnits { get; set; }
    }
}