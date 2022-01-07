using System;
using System.Threading.Tasks;
using Pig_n_Go.Core.Order;
using Pig_n_Go.DAL.DatabaseContexts;

namespace Pig_n_Go.DAL.Repositories
{
    public class DbOrderRepositoryAsync : IOrderRepositoryAsync
    {
        private readonly TaxiDbContext _taxiDbContext;

        public DbOrderRepositoryAsync(TaxiDbContext taxiDbContext)
        {
            _taxiDbContext = taxiDbContext;
        }

        public async Task AddAsync(OrderModel model)
        {
            await _taxiDbContext.Orders.AddAsync(model);
            await _taxiDbContext.SaveChangesAsync();
        }

        public async Task<OrderModel> GetAsync(Guid id)
        {
            return await _taxiDbContext.Orders.FindAsync(id);
        }

        public async Task RemoveAsync(OrderModel model)
        {
            _taxiDbContext.Orders.Remove(model);
            await _taxiDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderModel model)
        {
            _taxiDbContext.Orders.Update(model);
            await _taxiDbContext.SaveChangesAsync();
        }
    }
}