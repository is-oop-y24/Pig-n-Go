using Pig_n_Go.BLL.Driver;

namespace Pig_n_Go.BLL.Tools
{
    public interface IDistanceCalculator
    {
        decimal GetDistance(CartesianLocationUnit unit1, CartesianLocationUnit unit2);
    }
}