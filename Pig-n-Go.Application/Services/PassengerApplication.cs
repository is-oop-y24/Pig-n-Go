using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pig_n_Go.Common.DTO.Passenger;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.Core.Services;
using Pig_n_Go.DAL.DatabaseContexts;

namespace Pig_n_Go.Application.Services
{
    public class PassengerApplication : IApplicationService<PassengerDto>
    {
        private readonly TaxiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPassengerService _service;

        public PassengerApplication(TaxiDbContext dbContext, IMapper mapper, IPassengerService service)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _service = service;
        }

        public async Task<PassengerDto> AddAsync(PassengerDto dto)
        {
            PassengerModel passengerModel = _mapper.Map<PassengerModel>(dto);

            EntityEntry<PassengerModel> result = await _dbContext.AddAsync(passengerModel);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PassengerDto>(result.Entity);
        }

        public async Task<PassengerDto> FindAsync(Guid id)
        {
            PassengerModel result = await _dbContext.Passengers.FindAsync(id);
            return _mapper.Map<PassengerDto>(result);
        }

        public async Task<IReadOnlyCollection<PassengerDto>> GetAllAsync()
        {
            return await _dbContext.Passengers.Select(model => _mapper.Map<PassengerDto>(model)).ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _dbContext.Passengers.Remove(await _dbContext.Passengers.FindAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PassengerDto> Pay(Guid passengerId)
        {
            PassengerModel passengerModel = await _dbContext.Passengers.FindAsync(passengerId);

            PassengerModel result = await _service.Pay(passengerModel);
            _dbContext.Passengers.Update(result);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PassengerDto>(result);
        }
    }
}
