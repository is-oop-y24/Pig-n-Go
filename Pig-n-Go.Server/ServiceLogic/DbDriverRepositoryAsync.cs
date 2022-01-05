using System;
using System.Threading.Tasks;
using Pig_n_Go.Driver;

namespace Pig_n_Go
{
    public class DbDriverRepositoryAsync : IDriverRepositoryAsync
    {
        public Task Add(DriverModel model)
        {
            throw new NotImplementedException();
        }

        public Task<DriverModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(DriverModel model)
        {
            throw new NotImplementedException();
        }

        public Task Update(DriverModel model)
        {
            throw new NotImplementedException();
        }
    }
}