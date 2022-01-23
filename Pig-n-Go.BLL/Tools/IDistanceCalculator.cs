using Pig_n_Go.Core.Driver;

namespace Pig_n_Go.Core.Tools
{
    public interface IDistanceCalculator
    {
        decimal GetDistance(CartesianLocationUnit unit1, CartesianLocationUnit unit2);
    }
}