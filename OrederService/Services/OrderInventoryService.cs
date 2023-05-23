using OrederService.Protos;
using OrederService.Services.Interfeces;

namespace OrederService.Services
{
    public class OrderInventoryService : IOrderInventoryService
    {
        private readonly OrderInventory.OrderInventoryClient _orderInventoryClient;

        public OrderInventoryService(OrderInventory.OrderInventoryClient orderInventoryClient)
        {
            _orderInventoryClient = orderInventoryClient;
        }

        public async Task<bool> IsItemAvailableAsync(int itemId)
        {
            var itemRequest = new ItemRequest { Id = itemId };
            var isAvailable = await _orderInventoryClient.IsAvailableAsync(itemRequest);

            if (isAvailable == null)
            {
                throw new ArgumentNullException(nameof(isAvailable));
            }

            return isAvailable.IsAvailable;
        }
    }
}
