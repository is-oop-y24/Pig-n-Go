using System.Threading.Tasks;
using Pig_n_Go.BLL.Passenger;

namespace Pig_n_Go.BLL.Services
{
    public class PassengerService : IPassengerService
    {
        public async Task<PassengerModel> Pay(PassengerModel passengerModel)
        {
            return await Task.FromResult(passengerModel);
        }
    }
}
