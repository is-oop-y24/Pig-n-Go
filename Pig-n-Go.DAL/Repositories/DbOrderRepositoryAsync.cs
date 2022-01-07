using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<OrderModel> FindAsync(Guid id)
        {
            return await _taxiDbContext.Orders.FindAsync(id);
        }

        public async Task<IReadOnlyCollection<OrderModel>> GetAll()
        {
            return await _taxiDbContext.Orders.ToListAsync();
        }

        public async Task<IReadOnlyCollection<OrderModel>> GetWhere(Func<OrderModel, bool> predicate)
        {
            return await _taxiDbContext.Orders
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