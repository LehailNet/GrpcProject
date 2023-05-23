using InventoryManagementService.Repositories;
using InventoryManagementService.Repositories.Intefaces;
using InventoryManagementService.Services;
using InventoryManagementService.Services.Interfaces;

namespace InventoryManagementService
{
    public static class InventoryServiceDI
    {
        public static void Configure(IServiceCollection services)
        {
            //Singelton needs that in repository does not delete the replacement database
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddTransient<IItemService, ItemService>();
        }
    }
}
