using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.Common.DTO.Order;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _service;
        private readonly IMapper _mapper;

        public OrderController(IOrderServiceAsync service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreationArguments arguments)
        {
            OrderModel order = _mapper.Map<OrderModel>(arguments);

            OrderModel result = await _service.AddAsync(order);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            OrderModel order = await _service.FindAsync(orderId);

            if (order is null)
                return NotFound();

            return Ok(_mapper.Map<OrderDTO>(order));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            IReadOnlyCollection<OrderModel> orders = await _service.GetAllAsync();

            if (orders is null || orders.Count == 0)
                return NotFound();

            return Ok(orders.Select(o => _mapper.Map<OrderDTO>(o)).ToList());
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            await _service.RemoveAsync(orderId);
            return Ok();
        }

        [HttpPatch("accept")]
        public async Task<IActionResult> AcceptOrder([FromQuery] Guid orderId, [FromQuery] Guid driverId)
        {
            if (orderId == Guid.Empty || driverId == Guid.Empty)
                return BadRequest();

            await _service.AcceptOrderAsync(orderId, driverId);
            return Ok();
        }

        [HttpPatch("decline")]
        public async Task<IActionResult> DeclineOrder([FromQuery] Guid orderId, [FromQuery] Guid driverId)
        {
            if (orderId == Guid.Empty || driverId == Guid.Empty)
                return BadRequest();

            await _service.DeclineOrderAsync(orderId, driverId);
            return Ok();
        }

        [HttpPatch("finish")]
        public async Task<IActionResult> FinishOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            await _service.FinishOrderAsync(orderId);
            return Ok();
        }
    }
}