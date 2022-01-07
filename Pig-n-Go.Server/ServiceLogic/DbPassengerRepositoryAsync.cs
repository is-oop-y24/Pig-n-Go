using System;
using System.Threading.Tasks;
using Pig_n_Go.Passenger;

namespace Pig_n_Go
{
    public class DbPassengerRepositoryAsync : IPassengerRepositoryAsync
    {
        private readonly TaxiContext _taxiContext;

        public DbPassengerRepositoryAsync(TaxiContext taxiContext)
        {
            _taxiContext = taxiContext;
        }

        public async Task AddAsync(PassengerModel model)
        {
            await _taxiContext.PassengerModels.AddAsync(model);
            await _taxiContext.SaveChangesAsync();
        }

        public async Task<PassengerModel> GetAsync(Guid id)
        {
            return await _taxiContext.PassengerModels.FindAsync(id);
        }

        public async Task RemoveAsync(PassengerModel model)
        {
            _taxiContext.PassengerModels.Remove(model);
            await _taxiContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PassengerModel model)
        {
            _taxiContext.PassengerModels.Update(model);
            await _taxiContext.SaveChangesAsync();
        }
    }
}