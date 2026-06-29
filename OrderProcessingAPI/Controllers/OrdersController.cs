using Microsoft.AspNetCore.Mvc;
using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Application.Interfaces;

namespace OrderProcessingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderResponseDto>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<IReadOnlyList<OrderResponseDto>>> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);

            return Ok(order);
        }

        [HttpPost("{orderId}/cancel")]
        public async Task<ActionResult<CancelOrderResponseDto>> CancelOrderById(Guid orderId)
        {
            var order = await _orderService.CancelOrderAsync(orderId);

            return Ok(order);
        }

        [HttpPatch("{orderId}/advance-status")]
        public async Task<ActionResult<OrderResponseDto>> AdvanceOrderById(Guid orderId)
        {
            var order = await _orderService.AdvanceOrderStatusAsync(orderId);

            return Ok(order);
        }
    }
}