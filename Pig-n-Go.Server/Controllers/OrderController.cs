using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.Common.DTO.Order;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderService;
        private readonly IPassengerServiceAsync _passengerService;
        private readonly IMapper _mapper;

        public OrderController(IOrderServiceAsync orderService, IPassengerServiceAsync passengerService, IMapper mapper)
        {
            _orderService = orderService;
            _passengerService = passengerService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreationArguments arguments, [FromQuery] Guid passengerId)
        {
            OrderModel order = _mapper.Map<OrderModel>(arguments);
            order.Passenger = await _passengerService.FindAsync(passengerId);

            order.Tariff = new EconomyTariff(); // TODO: temporary solution, need to figure out how to receive tariffs
            order.CreationDate = DateTime.Now; // TODO: mapper doesn't get it
            order.UpdateDate = DateTime.Now; // TODO: mapper doesn't get it

            OrderModel result = await _orderService.AddAsync(order);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetOrder([FromQuery] Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest();

            OrderModel order = await _orderService.FindAsync(orderId);

            if (order is null)
                return NotFound();

            return Ok(_mapper.Map<OrderDTO>(order));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            IReadOnlyCollection<OrderModel> orders = await _orderService.GetAllAsync() ?? new List<OrderModel>();

            return Ok(orders.Select(o => _mapper.Map<OrderDTO>(o)).ToList());
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
