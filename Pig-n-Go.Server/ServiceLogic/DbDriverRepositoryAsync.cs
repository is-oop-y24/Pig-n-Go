using System;
using System.Threading.Tasks;
using Pig_n_Go.Driver;

namespace Pig_n_Go
{
    public class DbDriverRepositoryAsync : IDriverRepositoryAsync
    {
        private readonly TaxiContext _taxiContext;

        public DbDriverRepositoryAsync(TaxiContext taxiContext)
        {
            _taxiContext = taxiContext;
        }

        public async Task AddAsync(DriverModel model)
        {
            await _taxiContext.DriversModels.AddAsync(model);
            await _taxiContext.SaveChangesAsync();
        }

        public async Task<DriverModel> GetAsync(Guid id)
        {
            return await _taxiContext.DriversModels.FindAsync(id);
        }

        public async Task RemoveAsync(DriverModel model)
        {
            _taxiContext.DriversModels.Remove(model);
            await _taxiContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DriverModel model)
        {
            _taxiContext.DriversModels.Update(model);
            await _taxiContext.SaveChangesAsync();
        }
    }
}