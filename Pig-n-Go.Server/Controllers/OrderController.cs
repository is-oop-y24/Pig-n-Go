using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.Application.Services;
using Pig_n_Go.Common.DTO.Order;

namespace Pig_n_Go.Server.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderApplication _orderService;
        private readonly PassengerApplication _passengerService;
        private readonly IMapper _mapper;

        public OrderController(OrderApplication orderService, PassengerApplication passengerService, IMapper mapper)
        {
            _orderService = orderService;
            _passengerService = passengerService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreationArguments arguments, [FromQuery] Guid passengerId)
        {
            OrderDto dto = _mapper.Map<OrderDto>(arguments);

            OrderDto result = await _orderService.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            OrderDto order = await _orderService.FindAsync(orderId);

            if (order is null)
                return NotFound();

            return Ok(order);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllAsync());
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            await _orderService.RemoveAsync(orderId);
            return Ok();
        }

        [HttpPatch("accept")]
        public async Task<IActionResult> AcceptOrder([FromQuery] Guid orderId, [FromQuery] Guid driverId)
        {
            if (orderId == Guid.Empty || driverId == Guid.Empty)
                return BadRequest();

            await _orderService.AcceptOrderAsync(orderId, driverId);
            return Ok();
        }

        [HttpPatch("decline")]
        public async Task<IActionResult> DeclineOrder([FromQuery] Guid orderId, [FromQuery] Guid driverId)
        {
            if (orderId == Guid.Empty || driverId == Guid.Empty)
                return BadRequest();

            await _orderService.DeclineOrderAsync(orderId, driverId);
            return Ok();
        }

        [HttpPatch("finish")]
        public async Task<IActionResult> FinishOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            await _orderService.FinishOrderAsync(orderId);
            return Ok();
        }
    }
}
