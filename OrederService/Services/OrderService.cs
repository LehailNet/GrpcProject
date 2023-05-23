using AutoMapper;
using OrederService.Models;
using OrederService.Models.Entities;
using OrederService.Models.Enums;
using OrederService.Models.RequestModels;
using OrederService.Repositories.Intefaces;
using OrederService.Services.Interfeces;

namespace OrederService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Guid CreateOrder(OrderRequest model)
        {
            var order = _mapper.Map<OrderRequest, OrderModel>(model);

            var result = _orderRepository.AddOrder(order);

            if(result)
                return order.Id;

            throw new InvalidOperationException("Failed to create order.");
        }

        public bool UpdateOrderStatus(Guid orderId, OrderStatus status) 
        { 
            var order = GetOrderById(orderId);

            order.Status = status;

            return _orderRepository.UpdateOrder(order);
        }

        public OrderModel GetOrderInfo(Guid orderId) 
        {
            var order = GetOrderById(orderId);

            return _mapper.Map<OrderModel>(order);
        }

        private Order GetOrderById(Guid orderId)
        {
            var order = _orderRepository.GetOrder(orderId);

            if (order == null)
                throw new InvalidOperationException("Order not found.");

            return order;
        }
    }
}
