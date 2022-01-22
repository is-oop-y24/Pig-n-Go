using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.Application.Services;
using Pig_n_Go.Common.DTO.Driver;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Server.Controllers
{
    [ApiController]
    [Route("drivers")]
    public class DriverController : ControllerBase
    {
        private readonly DriverApplication _applicationService;
        private readonly IMapper _mapper;

        public DriverController(DriverApplication applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDriver([FromBody] DriverCreationArguments arguments)
        {
            DriverDto driver = _mapper.Map<DriverDto>(arguments);

            driver.Tariff = new TariffModel(); // TODO: temporary solution, need to figure out how to receive tariffs
            driver.DriverRating = new DriverRating(); // TODO: mapper doesn't get it

            DriverDto result = await _applicationService.AddAsync(driver);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetDriver([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            DriverDto driver = await _applicationService.FindAsync(driverId);

            if (driver is null)
                return NotFound();

            return Ok(driver);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDrivers()
        {
            IReadOnlyCollection<DriverDto> drivers = await _applicationService.GetAllAsync();

            return Ok(drivers);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveDriver([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            await _applicationService.RemoveAsync(driverId);
            return Ok();
        }

        [HttpPatch("update/location")]
        public async Task<IActionResult> UpdateLocation(
            [FromQuery] Guid driverId,
            [FromBody] CartesianLocationUnit locationUnit)
        {
            if (driverId == Guid.Empty || locationUnit is null)
                return BadRequest();

            await _applicationService.UpdateLocation(driverId, locationUnit);
            return Ok();
        }

        [HttpPatch("update/rating")]
        public async Task<IActionResult> UpdateRating([FromQuery] Guid driverId, [FromQuery] Guid orderId)
        {
            if (driverId == Guid.Empty || orderId == Guid.Empty)
                return BadRequest();

            await _applicationService.UpdateRating(driverId, orderId);
            return Ok();
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            await _applicationService.GoOnline(driverId);
            return Ok();
        }

        [HttpPut("logout")]
        public async Task<IActionResult> Logout([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            await _applicationService.GoOffline(driverId);
            return Ok();
        }
    }
}
