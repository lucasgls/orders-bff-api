using Microsoft.EntityFrameworkCore;
using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Application.Interfaces;
using OrderProcessingAPI.Domain.Exceptions;
using OrderProcessingAPI.Infrastructure.Data;
using OrderProcessingAPI.Models.Enum;

namespace OrderProcessingAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private AppDbContext _context;
        private MapperService _mapper;
        public OrderService(AppDbContext context, MapperService mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CancelOrderResponseDto> CancelOrderByIdAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order is null)
                throw new NotFoundException("Pedido não encontrado");

            if (order.Status == OrderStatus.CANCELED)
                throw new BusinessRuleException("Pedido já está cancelado");

            if (order.Status == OrderStatus.INVOICED)
                throw new BusinessRuleException("Pedido faturado não pode ser cancelado");

            order.Status = OrderStatus.CANCELED;
            order.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new CancelOrderResponseDto
            (
                OrderId: order.Id,
                Message: "Pedido cancelado com sucesso!",
                OrderNumber: order.OrderNumber,
                Timestamp: order.UpdatedAt
            );
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order is null)
                throw new KeyNotFoundException("Pedido não encontrado");

            return _mapper.ToResponse(order);
        }

        public async Task<IReadOnlyList<OrderResponseDto>> GetOrderListAsync()
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .ToListAsync();

            return orders.Select(_mapper.ToResponse).ToList();
        }
    }
}