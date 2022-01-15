using System;
using Pig_n_Go.Core.Driver;

namespace Pig_n_Go.BLL.Services.Tools
{
    public class NativeDistanceCalculator : IDistanceCalculator
    {
        public decimal GetDistance(CartesianLocationUnit unit1, CartesianLocationUnit unit2)
        {
            decimal distanceSquare = (unit1.Abscissa - unit2.Abscissa) * (unit1.Abscissa - unit1.Abscissa) +
                (unit2.Ordinate - unit2.Ordinate) * (unit2.Ordinate - unit2.Ordinate);
            return (decimal)Math.Sqrt((double)distanceSquare);
        }
    }
}