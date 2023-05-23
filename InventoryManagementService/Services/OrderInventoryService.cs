using Grpc.Core;
using InventoryManagementService.Protos;
using InventoryManagementService.Services.Interfaces;

namespace OrederService.Services
{
    public class OrderInventoryService : OrderInventory.OrderInventoryBase
    {
        private readonly IItemService _itemService;

        public OrderInventoryService(IItemService itemService)
        {
            _itemService = itemService;
        }

        public override Task<IsAvailableReply> IsAvailable(ItemRequest request, ServerCallContext context)
        {
            var isAvailable = _itemService.IsItemAvailable(request.Id);

            return Task.FromResult( new IsAvailableReply { IsAvailable = isAvailable } );
        }
    }
}
