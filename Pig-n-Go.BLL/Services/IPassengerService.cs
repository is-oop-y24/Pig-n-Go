using System.Threading.Tasks;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.Core.Services
{
    public interface IPassengerService
    {
        public Task<PassengerModel> Pay(PassengerModel passengerModel);
    }
}
