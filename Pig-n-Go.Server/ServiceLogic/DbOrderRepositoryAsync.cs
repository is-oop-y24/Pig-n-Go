using System;
using System.Threading.Tasks;
using Pig_n_Go.Order;

namespace Pig_n_Go
{
    public class DbOrderRepositoryAsync : IOrderRepositoryAsync
    {
        private readonly TaxiContext _taxiContext;

        public DbOrderRepositoryAsync(TaxiContext taxiContext) {
            _taxiContext = taxiContext;
        }

        public async Task AddAsync(OrderModel model)
        {
            await _taxiContext.OrderModels.AddAsync(model);
            await _taxiContext.SaveChangesAsync();
        }

        public async Task<OrderModel> GetAsync(Guid id)
        {
            return await _taxiContext.OrderModels.FindAsync(id);
        }

        public async Task RemoveAsync(OrderModel model)
        {
            _taxiContext.OrderModels.Remove(model);
            await _taxiContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderModel model)
        {
            _taxiContext.OrderModels.Update(model);
            await _taxiContext.SaveChangesAsync();
        }
    }
}