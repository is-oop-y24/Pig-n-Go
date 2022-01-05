using System;
using System.Threading.Tasks;
using Pig_n_Go.Passenger;

namespace Pig_n_Go
{
    public class DbPassengerRepositoryAsync : IPassengerRepositoryAsync
    {
        public Task Add(PassengerModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PassengerModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(PassengerModel model)
        {
            throw new NotImplementedException();
        }

        public Task Update(PassengerModel model)
        {
            throw new NotImplementedException();
        }
    }
}