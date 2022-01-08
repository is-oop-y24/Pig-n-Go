using System;
using System.Collections.Generic;
using Pig_n_Go.Driver;

namespace Pig_n_Go.Core.Order
{
    public class Route
    {
        private readonly List<CartesianLocationUnit> _locationUnits;

        public Route(List<CartesianLocationUnit> locationUnits)
        {
            _locationUnits = locationUnits;
        }

        public Guid Id { get; init; }
        public IReadOnlyCollection<CartesianLocationUnit> LocationUnits => _locationUnits;
    }
}