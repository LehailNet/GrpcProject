using InventoryManagementService.Models;

namespace InventoryManagementService.Services.Interfaces
{
    public interface IItemService
    {
        ItemModel GetItemInfo(int id);
        bool IsItemAvailable(int id);
    }
}
