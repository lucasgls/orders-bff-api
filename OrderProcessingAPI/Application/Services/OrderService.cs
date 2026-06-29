using OrderProcessingAPI.Application.DTOs;
using OrderProcessingAPI.Application.Interfaces;
using OrderProcessingAPI.Domain.Enum;
using OrderProcessingAPI.Domain.Exceptions;
using System.Net.NetworkInformation;

namespace OrderProcessingAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderMapper _mapper;

        public OrderService(IOrderRepository repository, IOrderMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CancelOrderResponseDto> CancelOrderAsync(Guid orderId)
        {
            var order = await _repository.GetByIdAsync(orderId);

            if (order is null)
                throw new NotFoundException("Pedido não encontrado");

            if (order.IsAlreadyCanceled())
                throw new BusinessRuleException("Pedido já está cancelado");

            if (order.IsInvoiced())
                throw new BusinessRuleException("Pedido faturado não pode ser cancelado");

            order.Cancel();

            await _repository.SaveAsync();

            return _mapper.ToCancelOrderResponse(order, "Pedido cancelado com sucesso");
        }

        public async Task<OrderResponseDto> GetOrderAsync(Guid orderId)
        {
            var order = await _repository.GetByIdAsync(orderId);

            if (order is null)
                throw new NotFoundException("Pedido não encontrado");

            return _mapper.ToResponse(order);
        }

        public async Task<IReadOnlyList<OrderResponseDto>> GetOrdersAsync()
        {
            var orders = await _repository.GetAllAsync();

            return orders.Select(_mapper.ToResponse).ToList();
        }

        public async Task<AdvanceStatusResponseDto> AdvanceOrderStatusAsync(Guid orderId)
        {
            var order = await _repository.GetByIdAsync(orderId);

            if (order is null)
                throw new NotFoundException("Pedido não encontrado");

            if (order.IsInvoiced() || order.IsAlreadyCanceled())
                throw new BusinessRuleException("Pedido não pode ser avançado");
            
            order.AdvanceStatus();

            await _repository.SaveAsync();

            return _mapper.ToAdvanceStatusResponseDto(order);
        }
    }
}