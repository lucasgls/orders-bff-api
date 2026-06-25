using Microsoft.AspNetCore.Mvc;
using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Application.Interfaces;

namespace OrdersProcessingAPI.Controllers
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
            var orders = await _orderService.GetOrderListAsync();

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<IReadOnlyList<OrderResponseDto>>> GetOrderById(Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);

            return Ok(order);
        }

        [HttpPost("{orderId}/cancel")]
        public async Task<ActionResult<CancelOrderResponseDto>> CancelOrderById(Guid orderId)
        {
            var order = await _orderService.CancelOrderByIdAsync(orderId);

            return Ok(order);
        }
    }
}