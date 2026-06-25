using Microsoft.EntityFrameworkCore;
using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Application.Interfaces;
using OrderProcessingAPI.Domain.Exceptions;
using OrderProcessingAPI.Infrastructure.Data;
using OrderProcessingAPI.Domain.Enum;

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

            if (order.IsAlreadyCanceled())
                throw new BusinessRuleException("Pedido já está cancelado");

            if (order.IsInvoiced())
                throw new BusinessRuleException("Pedido faturado não pode ser cancelado");

            order.Cancel();

            await _context.SaveChangesAsync();

            return _mapper.ToCancelOrderResponse(order, "Pedido cancelado com sucesso");
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order is null)
                throw new NotFoundException("Pedido não encontrado");

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