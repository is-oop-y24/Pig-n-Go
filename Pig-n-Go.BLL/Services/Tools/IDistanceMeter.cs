using Pig_n_Go.Core.Driver;

namespace Pig_n_Go.BLL.Services.Tools
{
    public interface IDistanceMeter
    {
        decimal GetDistance(CartesianLocationUnit unit1, CartesianLocationUnit unit2);
    }
}