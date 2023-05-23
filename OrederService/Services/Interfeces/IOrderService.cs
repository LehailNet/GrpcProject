using OrederService.Models.Enums;
using OrederService.Models;
using OrederService.Models.RequestModels;

namespace OrederService.Services.Interfeces
{
    public interface IOrderService
    {
        Guid CreateOrder(OrderRequest model);
        bool UpdateOrderStatus(Guid orderId, OrderStatus status);
        OrderModel GetOrderInfo(Guid orderId);
    }
}
