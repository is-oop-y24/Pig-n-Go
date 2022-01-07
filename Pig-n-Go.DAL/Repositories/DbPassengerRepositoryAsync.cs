using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.DAL.DatabaseContexts;

namespace Pig_n_Go.DAL.Repositories
{
    public class DbPassengerRepositoryAsync : IPassengerRepositoryAsync
    {
        private readonly TaxiDbContext _taxiDbContext;

        public DbPassengerRepositoryAsync(TaxiDbContext taxiDbContext)
        {
            _taxiDbContext = taxiDbContext;
        }

        public async Task AddAsync(PassengerModel model)
        {
            await _taxiDbContext.Passengers.AddAsync(model);
            await _taxiDbContext.SaveChangesAsync();
        }

        public async Task<PassengerModel> GetAsync(Guid id)
        {
            return await _taxiDbContext.Passengers.FindAsync(id);
        }

        public async Task RemoveAsync(PassengerModel model)
        {
            _taxiDbContext.Passengers.Remove(model);
            await _taxiDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PassengerModel model)
        {
            _taxiDbContext.Passengers.Update(model);
            await _taxiDbContext.SaveChangesAsync();
        }
    }
}