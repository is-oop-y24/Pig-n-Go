using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pig_n_Go.Core.Order;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.DAL.Extensions;

namespace Pig_n_Go.DAL.Repositories
{
    public class DbOrderRepositoryAsync : IOrderRepositoryAsync
    {
        private readonly TaxiDbContext _taxiDbContext;

        public DbOrderRepositoryAsync(TaxiDbContext taxiDbContext)
        {
            _taxiDbContext = taxiDbContext;
        }

        public async Task<OrderModel> AddAsync(OrderModel model)
        {
            EntityEntry<OrderModel> order = await _taxiDbContext.Orders.AddAsync(model);
            await _taxiDbContext.SaveChangesAsync();

            return order.Entity;
        }

        public async Task<OrderModel> FindAsync(Guid id)
        {
            return await _taxiDbContext.Orders
                                       .LoadOrderDependencies()
                                       .FirstOrDefaultAsync(model => model.Id == id);
        }

        public async Task<IReadOnlyCollection<OrderModel>> GetAllAsync()
        {
            return await _taxiDbContext.Orders
                                       .LoadOrderDependencies()
                                       .ToListAsync();
        }

        public async Task<IReadOnlyCollection<OrderModel>> GetWhereAsync(Func<OrderModel, bool> predicate)
        {
            return await _taxiDbContext.Orders
                                       .LoadOrderDependencies()
                                       .Where(predicate)
                                       .AsQueryable()
                                       .ToListAsync();
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
