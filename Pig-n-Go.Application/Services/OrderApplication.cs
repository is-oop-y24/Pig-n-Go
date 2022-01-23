using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pig_n_Go.Common.Order;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Services;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.DAL.Extensions;

namespace Pig_n_Go.Application.Services
{
    public class OrderApplication : IApplicationService<OrderDto>
    {
        private readonly TaxiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IOrderService _service;

        public OrderApplication(TaxiDbContext dbContext, IMapper mapper, IOrderService service)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _service = service;
        }

        public async Task<OrderDto> AddAsync(OrderDto dto)
        {
            OrderModel model = _mapper.Map<OrderModel>(dto);

            EntityEntry<OrderModel> result = await _dbContext.Orders.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<OrderDto>(result.Entity);
        }

        public async Task<OrderDto> FindAsync(Guid id)
        {
            OrderModel result = await _dbContext.Orders.LoadDependencies().FirstOrDefaultAsync(model => model.Id == id);
            return _mapper.Map<OrderDto>(result);
        }

        public async Task<IReadOnlyCollection<OrderDto>> GetAllAsync()
        {
            return await _dbContext.Orders.LoadDependencies()
                                   .Select(model => _mapper.Map<OrderDto>(model))
                                   .ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _dbContext.Orders.Remove(await _dbContext.Orders.FindAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task HandleOrderAsync(Guid orderId)
        {
            OrderModel order = await _dbContext.Orders.LoadDependencies()
                                               .FirstOrDefaultAsync(model => model.Id == orderId);
            List<DriverModel> drivers = await _service.FindClosestDrivers(
                _dbContext.Drivers.ToList(),
                order.Route.LocationUnits.ElementAtOrDefault(0));

            await _service.HandleOrderAsync(order, drivers);
        }

        public async Task AcceptOrderAsync(Guid orderId, Guid driverId)
        {
            OrderModel order = await _dbContext.Orders.LoadDependencies()
                                               .FirstOrDefaultAsync(model => model.Id == orderId);
            DriverModel driver = await _dbContext.Drivers.FindAsync(driverId);

            OrderModel result = await _service.AcceptOrderAsync(order, driver);

            _dbContext.Orders.Update(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeclineOrderAsync(Guid orderId, Guid driverId)
        {
            OrderModel order = await _dbContext.Orders.LoadDependencies()
                                               .FirstOrDefaultAsync(model => model.Id == orderId);
            DriverModel driver = await _dbContext.Drivers.FindAsync(driverId);

            OrderModel result = await _service.DeclineOrderAsync(order, driver);

            _dbContext.Orders.Update(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task FinishOrderAsync(Guid orderId)
        {
            OrderModel order = await _dbContext.Orders.LoadDependencies()
                                               .FirstOrDefaultAsync(model => model.Id == orderId);
            OrderModel result = await _service.FinishOrderAsync(order);

            _dbContext.Orders.Update(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
