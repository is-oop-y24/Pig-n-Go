using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.Common.DTO.Driver;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Controllers
{
    [ApiController]
    [Route("drivers")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverServiceAsync _service;
        private readonly IMapper _mapper;

        public DriverController(IDriverServiceAsync service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDriver([FromBody] DriverCreationArguments arguments)
        {
            DriverModel driver = _mapper.Map<DriverModel>(arguments);

            driver.Tariff = new EconomyTariff(); // TODO: temporary solution, need to figure out how to receive tariffs
            driver.DriverRating = new DriverRating(); // TODO: mapper doesn't get it

            DriverModel result = await _service.AddAsync(driver);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetDriver([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            DriverModel driver = await _service.FindAsync(driverId);

            if (driver is null)
                return NotFound();

            return Ok(_mapper.Map<DriverDTO>(driver));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDrivers()
        {
            IReadOnlyCollection<DriverModel> drivers = await _service.GetAllAsync();

            return Ok(drivers.Select(d => _mapper.Map<DriverDTO>(d)).ToList());
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveDriver([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            await _service.RemoveAsync(driverId);
            return Ok();
        }

        [HttpPatch("update/location")]
        public async Task<IActionResult> UpdateLocation(
            [FromQuery] Guid driverId,
            [FromBody] CartesianLocationUnit locationUnit)
        {
            if (driverId == Guid.Empty || locationUnit is null)
                return BadRequest();

            await _service.UpdateLocation(driverId, locationUnit);
            return Ok();
        }

        [HttpPatch("update/rating")]
        public async Task<IActionResult> UpdateRating([FromQuery] Guid driverId, [FromQuery] Guid orderId)
        {
            if (driverId == Guid.Empty || orderId == Guid.Empty)
                return BadRequest();

            await _service.UpdateRating(driverId, orderId);
            return Ok();
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            await _service.GoOnline(driverId);
            return Ok();
        }

        [HttpPut("logout")]
        public async Task<IActionResult> Logout([FromQuery] Guid driverId)
        {
            if (driverId == Guid.Empty)
                return BadRequest();

            await _service.GoOffline(driverId);
            return Ok();
        }
    }
}
