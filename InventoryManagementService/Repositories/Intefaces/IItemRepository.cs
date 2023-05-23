using InventoryManagementService.Models.Entities;

namespace InventoryManagementService.Repositories.Intefaces
{
    public interface IItemRepository
    {
        Item GetItemById(int id);
    }
}
