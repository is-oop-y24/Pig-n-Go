using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.Application.Services;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.Common.Order;

namespace Pig_n_Go.Server.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderApplication _orderApplication;
        private readonly PassengerApplication _passengerApplication;
        private readonly IMapper _mapper;

        public OrderController(
            OrderApplication orderApplication,
            PassengerApplication passengerApplication,
            IMapper mapper)
        {
            _orderApplication = orderApplication;
            _passengerApplication = passengerApplication;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreationArguments arguments, [FromQuery] Guid passengerId)
        {
            arguments.Passenger = await _passengerApplication.FindAsync(passengerId);
            OrderDto dto = _mapper.Map<OrderDto>(arguments);

            dto.Status = OrderStatus.Searching;
            OrderDto result = await _orderApplication.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            OrderDto order = await _orderApplication.FindAsync(orderId);

            if (order is null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet("all/available")]
        public async Task<IActionResult> GetAvailableOrders()
        {
            List<OrderDto> order = await _orderApplication.GetAvailableOrders();

            if (order is null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderApplication.GetAllAsync());
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            await _orderApplication.RemoveAsync(orderId);
            return Ok();
        }

        [HttpPatch("accept")]
        public async Task<IActionResult> AcceptOrder([FromQuery] Guid orderId, [FromQuery] Guid driverId)
        {
            if (orderId == Guid.Empty || driverId == Guid.Empty)
                return BadRequest();

            await _orderApplication.AcceptOrderAsync(orderId, driverId);
            return Ok();
        }

        [HttpPatch("decline")]
        public async Task<IActionResult> DeclineOrder([FromQuery] Guid orderId, [FromQuery] Guid driverId)
        {
            if (orderId == Guid.Empty || driverId == Guid.Empty)
                return BadRequest();

            await _orderApplication.DeclineOrderAsync(orderId, driverId);
            return Ok();
        }

        [HttpPatch("finish")]
        public async Task<IActionResult> FinishOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            await _orderApplication.FinishOrderAsync(orderId);
            return Ok();
        }
    }
}
