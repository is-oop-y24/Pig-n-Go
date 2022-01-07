using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PassengerModel> FindAsync(Guid id)
        {
            return await _taxiDbContext.Passengers.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<PassengerModel>> GetAllAsync()
        {
            return await _taxiDbContext.Passengers.ToListAsync();
        }

        public async Task<IReadOnlyCollection<PassengerModel>> GetWhereAsync(Func<PassengerModel, bool> predicate)
        {
            return await _taxiDbContext.Passengers
                .Where(predicate)
                .AsQueryable()
                .ToListAsync();
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