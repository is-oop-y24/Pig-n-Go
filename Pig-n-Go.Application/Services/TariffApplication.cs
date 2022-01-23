using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pig_n_Go.Common.Tariff;
using Pig_n_Go.Core.Tariffs;
using Pig_n_Go.DAL.DatabaseContexts;

namespace Pig_n_Go.Application.Services
{
    public class TariffApplication : IApplicationService<TariffDto>
    {
        private readonly TaxiDbContext _dbContext;
        private readonly IMapper _mapper;

        public TariffApplication(TaxiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TariffDto> AddAsync(TariffDto dto)
        {
            TariffModel model = _mapper.Map<TariffModel>(dto);
            EntityEntry<TariffModel> result = await _dbContext.Tariffs.AddAsync(model);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TariffDto>(result.Entity);
        }

        public async Task<TariffDto> FindAsync(Guid id)
        {
            TariffModel result = await _dbContext.Tariffs.FindAsync(id);
            return _mapper.Map<TariffDto>(result);
        }

        public async Task<IReadOnlyCollection<TariffDto>> GetAllAsync()
        {
            return await _dbContext.Tariffs.Select(model => _mapper.Map<TariffDto>(model)).ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _dbContext.Tariffs.Remove(await _dbContext.Tariffs.FindAsync(id));
            await _dbContext.SaveChangesAsync();
        }
    }
}
