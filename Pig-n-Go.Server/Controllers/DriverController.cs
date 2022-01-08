using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.DTO.Driver;

namespace Pig_n_Go.Controllers
{
    public class DriverController : Controller
    {
        [ApiController]
        [Route("/orders")]
        public class ReportController : ControllerBase
        {
            private readonly IDriverServiceAsync _service;
            private readonly IMapper _mapper;

            public ReportController(IDriverServiceAsync service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }

            [HttpPost("add")]
            public async Task<IActionResult> AddDriver([FromBody] DriverCreateArguments arguments)
            {
                DriverModel driver = _mapper.Map<DriverModel>(arguments);

                await _service.AddAsync(driver);
                return Ok();
            }

            [HttpGet("get")]
            public async Task<IActionResult> GetDriver([FromQuery] Guid orderId)
            {
                if (orderId == Guid.Empty)
                    return BadRequest();

                DriverModel driver = await _service.FindAsync(orderId);

                if (driver == null)
                    return NotFound();

                return Ok(_mapper.Map<DriverDTO>(driver));
            }

            [HttpGet("get-all")]
            public async Task<IActionResult> GetAllDrivers()
            {
                IReadOnlyCollection<DriverModel> drivers = await _service.GetAllAsync();

                if (drivers == null || drivers.Count == 0)
                    return NotFound();

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

            [HttpPatch("update-location")]
            public async Task<IActionResult> UpdateLocation([FromQuery] Guid driverId, Guid locationUnitId)
            {
                if (driverId == Guid.Empty || locationUnitId == Guid.Empty)
                    return BadRequest();

                await _service.UpdateLocation(driverId, locationUnitId);
                return Ok();
            }

            [HttpPatch("update-rating")]
            public async Task<IActionResult> UpdateRating([FromQuery] Guid driverId, Guid orderId)
            {
                if (driverId == Guid.Empty || orderId == Guid.Empty)
                    return BadRequest();

                await _service.UpdateRating(driverId, orderId);
                return Ok();
            }

            [HttpPatch("login")]
            public async Task<IActionResult> Login([FromQuery] Guid driverId)
            {
                if (driverId == Guid.Empty)
                    return BadRequest();

                await _service.Login(driverId);
                return Ok();
            }

            [HttpPatch("logout")]
            public async Task<IActionResult> Logout([FromQuery] Guid driverId)
            {
                if (driverId == Guid.Empty)
                    return BadRequest();

                await _service.Logout(driverId);
                return Ok();
            }
        }
    }
}