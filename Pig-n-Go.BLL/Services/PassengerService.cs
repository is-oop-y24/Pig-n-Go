using System.Threading.Tasks;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.Core.Services
{
    public class PassengerService : IPassengerService
    {
        public async Task<PassengerModel> Pay(PassengerModel passengerModel)
        {
            return await Task.FromResult(passengerModel);
        }
    }
}
