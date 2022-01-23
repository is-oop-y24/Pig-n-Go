using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.DAL.Repositories;

namespace Pig_n_Go.BLL.Services
{
    public class PassengerServiceAsync : IPassengerServiceAsync
    {
        private readonly IPassengerRepositoryAsync _repository;
        private readonly ILogger<PassengerServiceAsync> _logger;

        public PassengerServiceAsync(
            IPassengerRepositoryAsync repository,
            ILogger<PassengerServiceAsync> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PassengerModel> AddAsync(PassengerModel model)
        {
            _logger.LogInformation("Add new passenger");

            return await _repository.AddAsync(model);
        }

        public async Task<PassengerModel> FindAsync(Guid id)
        {
            _logger.LogInformation($"Find passenger with id {id}");

            return await _repository.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<PassengerModel>> GetAllAsync()
        {
            _logger.LogInformation("Return all passengers");

            return await _repository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<PassengerModel>> GetWhereAsync(Func<PassengerModel, bool> predicate)
        {
            return await _repository.GetWhereAsync(predicate);
        }

        public async Task UpdateAsync(PassengerModel model)
        {
            _logger.LogInformation($"Update passenger with id {model.Id}");

            await _repository.UpdateAsync(model);
        }

        public async Task RemoveAsync(Guid id)
        {
            _logger.LogInformation($"Update passenger with id {id}");

            PassengerModel passenger = await _repository.FindAsync(id);
            await _repository.RemoveAsync(passenger);
        }

        public async Task Pay(Guid passengerId)
        {
            _logger.LogInformation($"Perform payment for passenger with id {passengerId}");

            await Task.CompletedTask;
        }
    }
}
