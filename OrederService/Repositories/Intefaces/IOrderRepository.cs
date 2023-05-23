using OrederService.Models;
using OrederService.Models.Entities;

namespace OrederService.Repositories.Intefaces
{
    public interface IOrderRepository
    {
        bool AddOrder(OrderModel model);
        Order GetOrder(Guid id);
        bool UpdateOrder(Order order);
    }
}
