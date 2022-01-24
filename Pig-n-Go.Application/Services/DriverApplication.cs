using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.BLL.Tariffs;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Common.Order;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.DAL.Extensions;

namespace Pig_n_Go.Application.Services
{
    public class DriverApplication : IApplicationService<DriverDto>
    {
        private readonly TaxiDbContext _dbContext;
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;
        private readonly ILogger<DriverApplication> _logger;

        public DriverApplication(
            TaxiDbContext dbContext,
            IDriverService driverService,
            IMapper mapper,
            ILogger<DriverApplication> logger)
        {
            _dbContext = dbContext;
            _driverService = driverService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DriverDto> AddAsync(DriverDto dto)
        {
            DriverModel model = _mapper.Map<DriverModel>(dto);

            EntityEntry<DriverModel> result = await _dbContext.Drivers.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Add new driver with id {result.Entity.Id}");

            return _mapper.Map<DriverDto>(result.Entity);
        }

        public async Task<DriverDto> FindAsync(Guid id)
        {
            DriverModel result =
                await _dbContext.Drivers.LoadDependencies().FirstOrDefaultAsync(model => model.Id == id);
            return _mapper.Map<DriverDto>(result);
        }

        public async Task<IReadOnlyCollection<DriverDto>> GetAllAsync()
        {
            return await _dbContext.Drivers.LoadDependencies()
                                   .Select(model => _mapper.Map<DriverDto>(model))
                                   .ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _dbContext.Drivers.Remove(await _dbContext.Drivers.FindAsync(id));

            _logger.LogInformation($"Remove driver with id {id}");

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<OrderDto>> UpdateLocation(Guid driverId, CartesianLocationUnit locationUnit)
        {
            DriverModel driverModel =
                await _dbContext.Drivers.LoadDependencies().FirstOrDefaultAsync(model => model.Id == driverId);

            DriverModel result = await _driverService.UpdateLocation(driverModel, locationUnit);
            _dbContext.Drivers.Update(result);
            await _dbContext.SaveChangesAsync();

            List<OrderModel> orders = await _dbContext.Orders.LoadDependencies()
                                                      .Where(model => model.Status == OrderStatus.Searching)
                                                      .AsQueryable()
                                                      .ToListAsync();
            return await Task.FromResult(orders.Select(model => _mapper.Map<OrderDto>(model)).ToList());
        }

        public async Task UpdateRating(Guid driverId, Guid orderId)
        {
            DriverModel driverModel =
                await _dbContext.Drivers.LoadDependencies().FirstOrDefaultAsync(model => model.Id == driverId);
            OrderModel orderModel = await _dbContext.Orders.FindAsync(orderId);

            await _driverService.UpdateRating(driverModel, orderModel);
            _dbContext.Drivers.Update(driverModel);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Update rating of driver with id {driverId}");
        }

        public async Task GoOnline(Guid driverId, Guid tariffId)
        {
            DriverModel driverModel = await _dbContext.Drivers.LoadDependencies()
                                                      .FirstOrDefaultAsync(model => model.Id == driverId);
            TariffModel tariffModel = await _dbContext.Tariffs.FindAsync(tariffId);

            driverModel = await _driverService.GoOnline(driverModel, tariffModel);

            _dbContext.Drivers.Update(driverModel);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Set driver with id {driverId} online");
        }

        public async Task GoOffline(Guid driverId)
        {
            DriverModel driverModel = await _dbContext.Drivers.LoadDependencies()
                                                      .FirstOrDefaultAsync(model => model.Id == driverId);

            driverModel = await _driverService.GoOffline(driverModel);

            _dbContext.Drivers.Update(driverModel);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"Set driver with id {driverId} offline");
        }
    }
}
