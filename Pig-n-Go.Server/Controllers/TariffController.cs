using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.Application.Services;
using Pig_n_Go.Common.DTO.Tariff;

namespace Pig_n_Go.Server.Controllers
{
    [ApiController]
    [Route("tariffs")]
    public class TariffController : ControllerBase
    {
        private readonly TariffApplication _applicationService;
        private readonly IMapper _mapper;

        public TariffController(TariffApplication applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTariff([FromBody] TariffCreationArguments creationArguments)
        {
            TariffDto tariff = _mapper.Map<TariffDto>(creationArguments);

            TariffDto result = await _applicationService.AddAsync(tariff);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTariffs()
        {
            IReadOnlyCollection<TariffDto> drivers = await _applicationService.GetAllAsync();

            return Ok(drivers);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveDriver([FromQuery] Guid tariffId)
        {
            if (tariffId == Guid.Empty)
                return BadRequest();

            await _applicationService.RemoveAsync(tariffId);
            return Ok();
        }
    }
}
