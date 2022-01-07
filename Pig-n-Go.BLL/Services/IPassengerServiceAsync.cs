using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.BLL.Services
{
    public interface IPassengerServiceAsync : IServiceAsync<PassengerModel>
    {
        Task Pay(Guid passengerId);
    }
}
