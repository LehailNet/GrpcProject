using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrederService.Models;
using OrederService.Models.Enums;
using OrederService.Models.RequestModels;
using OrederService.Models.ResponeModes;
using OrederService.Services.Interfeces;

namespace OrederService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderInventoryService _orderInventoryService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IOrderInventoryService orderInventoryService, IMapper mapper)
        {
            _orderService = orderService;
            _orderInventoryService = orderInventoryService;
            _mapper = mapper;
        }


        [HttpPost("create")]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<Guid> CreateOrder(OrderRequest request)
        {
            var isAvailable = await _orderInventoryService.IsItemAvailableAsync(request.InventoryId);

            if (!isAvailable)
            {
                throw new ArgumentException("Item not available");
            }

            return _orderService.CreateOrder(request);
        }

        [HttpPost("updateStatus")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult<bool> UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            var isSuccess = _orderService.UpdateOrderStatus(orderId, status);

            return Ok(isSuccess);
        }

        [HttpGet("info/{orderId}")]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        public ActionResult<OrderResponse> GetOrderInfo(Guid orderId)
        {
            var order = _orderService.GetOrderInfo(orderId);

            return Ok(_mapper.Map<OrderModel, OrderResponse>(order));
        }
    }
}
