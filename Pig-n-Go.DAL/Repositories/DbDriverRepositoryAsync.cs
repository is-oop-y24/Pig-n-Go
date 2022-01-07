using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.DAL.DatabaseContexts;

namespace Pig_n_Go.DAL.Repositories
{
    public class DbDriverRepositoryAsync : IDriverRepositoryAsync
    {
        private readonly TaxiDbContext _taxiDbContext;

        public DbDriverRepositoryAsync(TaxiDbContext taxiDbContext)
        {
            _taxiDbContext = taxiDbContext;
        }

        public async Task AddAsync(DriverModel model)
        {
            await _taxiDbContext.Drivers.AddAsync(model);
            await _taxiDbContext.SaveChangesAsync();
        }

        public async Task<DriverModel> FindAsync(Guid id)
        {
            return await _taxiDbContext.Drivers.FindAsync(id);
        }

        public async Task RemoveAsync(DriverModel model)
        {
            _taxiDbContext.Drivers.Remove(model);
            await _taxiDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DriverModel model)
        {
            _taxiDbContext.Drivers.Update(model);
            await _taxiDbContext.SaveChangesAsync();
        }
    }
}