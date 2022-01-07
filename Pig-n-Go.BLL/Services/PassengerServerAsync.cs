using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class PassengerServerAsync : IPassengerServiceAsync
    {
        private readonly IPassengerRepositoryAsync _repository;

        public PassengerServerAsync(IPassengerRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(PassengerModel passenger)
        {
            await _repository.AddAsync(passenger);
        }

        public async Task<PassengerModel> FindAsync(Guid id)
        {
            return await _repository.FindAsync(id);
        }

        public Task<IReadOnlyCollection<PassengerModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id)
        {
            PassengerModel passenger = await _repository.FindAsync(id);
            await _repository.RemoveAsync(passenger);
        }

        public Task Pay(Guid passengerId)
        {
            throw new NotImplementedException();
        }
    }
}
