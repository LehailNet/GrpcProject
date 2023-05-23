using AutoMapper;
using OrederService.Models;
using OrederService.Models.Entities;
using OrederService.Repositories.Intefaces;

namespace OrederService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        //Replacing the database implementation
        private List<Order> orders = new List<Order>();

        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool AddOrder(OrderModel model)
        {
            Order order = _mapper.Map<OrderModel, Order>(model);

            try
            {
                orders.Add(order);
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        public Order GetOrder(Guid id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateOrder(Order order)
        {
            var index = orders.FindIndex(x => x.Id == order.Id);

            try
            {
                orders[index] = order;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
