using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.Application.Services;
using Pig_n_Go.Common.DTO.Passenger;

namespace Pig_n_Go.Controllers
{
    [ApiController]
    [Route("passengers")]
    public class PassengerController : Controller
    {
        private readonly PassengerApplication _applicationService;
        private readonly IMapper _mapper;

        public PassengerController(PassengerApplication applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPassenger([FromBody] PassengerCreationArguments args)
        {
            if (args.PassengerInfo?.Name is null || args.PassengerInfo?.Surname is null)
                return BadRequest();
            PassengerDto passenger = _mapper.Map<PassengerDto>(args);

            PassengerDto result = await _applicationService.AddAsync(passenger);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetPassenger([FromQuery] Guid passengerId)
        {
            if (passengerId == Guid.Empty)
                return BadRequest();

            PassengerDto passenger = await _applicationService.FindAsync(passengerId);

            if (passenger is null)
                return NotFound();

            return Ok(passenger);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPassengers()
        {
            IReadOnlyCollection<PassengerDto> passengers = await _applicationService.GetAllAsync();

            return Ok(passengers);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemovePassenger([FromQuery] Guid passengerId)
        {
            if (passengerId == Guid.Empty)
                return BadRequest();

            await _applicationService.RemoveAsync(passengerId);
            return Ok();
        }

        [HttpPatch("{passengerId:guid}/pay")]
        public async Task<IActionResult> Pay([FromRoute] Guid passengerId)
        {
            await _applicationService.Pay(passengerId);
            return Ok();
        }
    }
}
