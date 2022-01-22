using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class PassengerServiceAsync : IPassengerServiceAsync
    {
        private readonly IPassengerRepositoryAsync _repository;

        public PassengerServiceAsync(IPassengerRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<PassengerModel> AddAsync(PassengerModel model)
        {
            return await _repository.AddAsync(model);
        }

        public async Task<PassengerModel> FindAsync(Guid id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<PassengerModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<PassengerModel>> GetWhereAsync(Func<PassengerModel, bool> predicate)
        {
            return await _repository.GetWhereAsync(predicate);
        }

        public async Task UpdateAsync(PassengerModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task RemoveAsync(Guid id)
        {
            PassengerModel passenger = await _repository.FindAsync(id);
            await _repository.RemoveAsync(passenger);
        }

        public async Task Pay(Guid passengerId)
        {
            await Task.CompletedTask;
        }
    }
}
