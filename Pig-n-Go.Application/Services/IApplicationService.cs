using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pig_n_Go.Application.Services
{
    public interface IApplicationService<TDto>
        where TDto : class
    {
        Task<TDto> AddAsync(TDto dto);
        Task<TDto> FindAsync(Guid id);
        Task<IReadOnlyCollection<TDto>> GetAllAsync();
        Task RemoveAsync(Guid id);
    }
}
