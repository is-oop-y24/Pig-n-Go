using System;
using System.Threading.Tasks;
using Pig_n_Go.Passenger;

namespace Pig_n_Go
{
    public class DbPassengerRepositoryAsync : IPassengerRepositoryAsync
    {
        public Task AddAsync(PassengerModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PassengerModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(PassengerModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PassengerModel model)
        {
            throw new NotImplementedException();
        }
    }
}