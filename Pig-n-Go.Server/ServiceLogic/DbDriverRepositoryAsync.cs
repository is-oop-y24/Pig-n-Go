using System;
using System.Threading.Tasks;
using Pig_n_Go.Driver;

namespace Pig_n_Go
{
    public class DbDriverRepositoryAsync : IDriverRepositoryAsync
    {
        private readonly TaxiContext _taxiContext;
        public DbDriverRepositoryAsync(TaxiContext taxiContext) {
            _taxiContext = taxiContext;
        }

        public Task AddAsync(DriverModel model)
        {
            throw new NotImplementedException();
        }

        public Task<DriverModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(DriverModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DriverModel model)
        {
            throw new NotImplementedException();
        }
    }
}