using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.Common.DTO.Passenger;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.Controllers
{
    [ApiController]
    [Route("passengers")]
    public class PassengerController : Controller
    {
        private readonly IPassengerServiceAsync _passengerService;
        private readonly IMapper _mapper;

        public PassengerController(IPassengerServiceAsync passengerService, IMapper mapper)
        {
            _passengerService = passengerService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPassenger([FromBody] PassengerCreationArguments args)
        {
            if (args.PassengerInfo?.Name is null || args.PassengerInfo?.Surname is null)
                return BadRequest();
            PassengerModel passenger = _mapper.Map<PassengerModel>(args);

            PassengerModel result = await _passengerService.AddAsync(passenger);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetPassenger([FromQuery] Guid passengerId)
        {
            if (passengerId == Guid.Empty)
                return BadRequest();

            PassengerModel passenger = await _passengerService.FindAsync(passengerId);

            if (passenger is null)
                return NotFound();

            return Ok(_mapper.Map<PassengerDTO>(passenger));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPassengers()
        {
            IReadOnlyCollection<PassengerModel> passengers = await _passengerService.GetAllAsync();

            return Ok(passengers.Select(p => _mapper.Map<PassengerDTO>(p)));
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemovePassenger([FromQuery] Guid passengerId)
        {
            if (passengerId == Guid.Empty)
                return BadRequest();

            await _passengerService.RemoveAsync(passengerId);
            return Ok();
        }

        [HttpPatch("{passengerId:guid}/pay")]
        public async Task<IActionResult> Pay([FromRoute] Guid passengerId)
        {
            await _passengerService.Pay(passengerId);
            return Ok();
        }
    }
}
