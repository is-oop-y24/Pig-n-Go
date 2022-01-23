using System.Threading.Tasks;
using Pig_n_Go.BLL.Passenger;

namespace Pig_n_Go.BLL.Services
{
    public interface IPassengerService
    {
        public Task<PassengerModel> Pay(PassengerModel passengerModel);
    }
}
