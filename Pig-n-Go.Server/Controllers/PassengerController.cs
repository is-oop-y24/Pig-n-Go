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

        [Route("add")]
        public async Task<IActionResult> AddPassenger([FromBody] PassengerCreationArguments args)
        {
            PassengerModel passenger = _mapper.Map<PassengerModel>(args);

            await _passengerService.AddAsync(passenger);

            return Ok();
        }

        [Route("get")]
        public async Task<IActionResult> GetPassenger([FromQuery] Guid passengerId)
        {
            if (passengerId == Guid.Empty)
                return BadRequest();

            PassengerModel passenger = await _passengerService.FindAsync(passengerId);

            if (passenger == null)
                return NotFound();

            return Ok(_mapper.Map<PassengerDTO>(passenger));
        }

        [Route("all")]
        public async Task<IActionResult> GetAllPassengers()
        {
            IReadOnlyCollection<PassengerModel> passengers = await _passengerService.GetAllAsync();

            if (passengers == null || passengers.Count == 0)
                return NotFound();

            IEnumerable<PassengerDTO> dtos = passengers.Select(p => _mapper.Map<PassengerDTO>(p));
            return Ok(dtos);
        }

        [Route("remove")]
        public async Task<IActionResult> RemovePassenger([FromQuery] Guid passengerId)
        {
            if (passengerId == Guid.Empty)
                return BadRequest();

            await _passengerService.RemoveAsync(passengerId);
            return Ok();
        }

        [Route("{passengerId}/pay")] // why not "pay", and request id from query|body|sth ?
        public async Task<IActionResult> Pay(Guid passengerId)
        {
            await _passengerService.Pay(passengerId);
            return Ok();
        }
    }
}