using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<DriverModel> AddAsync(DriverModel model)
        {
            EntityEntry<DriverModel> driver = await _taxiDbContext.Drivers.AddAsync(model);
            await _taxiDbContext.SaveChangesAsync();

            return driver.Entity;
        }

        public async Task<DriverModel> FindAsync(Guid id)
        {
            return await _taxiDbContext.Drivers.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<DriverModel>> GetAllAsync()
        {
            return await _taxiDbContext.Drivers.ToListAsync();
        }

        public async Task<IReadOnlyCollection<DriverModel>> GetWhereAsync(Func<DriverModel, bool> predicate)
        {
            return await _taxiDbContext.Drivers
                .Where(predicate)
                .AsQueryable()
                .ToListAsync();
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

        public async Task GoOnline(DriverModel driver)
        {
            await _taxiDbContext.ActiveDrivers.AddAsync(driver);
            await _taxiDbContext.SaveChangesAsync();
        }

        public async Task GoOffline(DriverModel driver)
        {
            _taxiDbContext.ActiveDrivers.Remove(driver);
            await _taxiDbContext.SaveChangesAsync();
        }
    }
}