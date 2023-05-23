using InventoryManagementService.Models.Entities;
using InventoryManagementService.Repositories.Intefaces;

namespace InventoryManagementService.Repositories
{
    public class ItemRepository : IItemRepository
    {
        //Replacing the database, so as not to complicate the project
        private List<Item> items = new List<Item> 
        { 
            new Item{ Id = 1, Name = "test1", Price = 22.2m, Amount = 4, IsAvailable = true},
            new Item{ Id = 2, Name = "test2", Price = 11m, Amount = 1, IsAvailable = true},
            new Item{ Id = 3, Name = "test2", Price = 230m, Amount = 0, IsAvailable = false },
        };

        public Item GetItemById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }
    }
}
