using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Services;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.DAL.Extensions;

namespace Pig_n_Go.Application.Services
{
    public class DriverApplication : IApplicationService<DriverDto>
    {
        private readonly TaxiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IDriverService _driverService;

        public DriverApplication(
            TaxiDbContext dbContext,
            IMapper mapper,
            IDriverService driverService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _driverService = driverService;
        }

        public async Task<DriverDto> AddAsync(DriverDto dto)
        {
            DriverModel model = _mapper.Map<DriverModel>(dto);

            EntityEntry<DriverModel> result = await _dbContext.Drivers.AddAsync(model);
            await _dbContext.SaveChangesAsync();

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
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DriverDto> UpdateLocation(Guid driverId, CartesianLocationUnit locationUnit)
        {
            DriverModel result =
                await _dbContext.Drivers.LoadDependencies().FirstOrDefaultAsync(model => model.Id == driverId);

            _driverService.UpdateLocation(result, locationUnit);
            _dbContext.Drivers.Update(result);

            return _mapper.Map<DriverDto>(result);
        }

        public async Task<DriverDto> UpdateRating(Guid driverId, Guid orderId)
        {
            DriverModel result =
                await _dbContext.Drivers.LoadDependencies().FirstOrDefaultAsync(model => model.Id == driverId);
            OrderModel orderModel = await _dbContext.Orders.FindAsync(orderId);

            _driverService.UpdateRating(result, orderModel);
            _dbContext.Drivers.Update(result);

            return _mapper.Map<DriverDto>(result);
        }

        public async Task GoOnline(Guid driverId)
        {
            DriverModel driverModel = await _dbContext.Drivers.FindAsync(driverId);
            await _dbContext.ActiveDrivers.AddAsync(driverModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task GoOffline(Guid driverId)
        {
            DriverModel driverModel = await _dbContext.Drivers.FindAsync(driverId);
            _dbContext.ActiveDrivers.Remove(driverModel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
