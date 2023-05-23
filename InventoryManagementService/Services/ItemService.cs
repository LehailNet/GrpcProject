using AutoMapper;
using InventoryManagementService.Exceptions;
using InventoryManagementService.Models;
using InventoryManagementService.Models.Entities;
using InventoryManagementService.Repositories.Intefaces;
using InventoryManagementService.Services.Interfaces;

namespace InventoryManagementService.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public ItemModel GetItemInfo(int id)
        {
            var item = GetItemById(id);

            return _mapper.Map<ItemModel>(item);
        }

        public bool IsItemAvailable(int id) 
        {
            var item = GetItemById(id);

            return item.IsAvailable;
        }

        private Item GetItemById(int id) 
        {
            var item = _itemRepository.GetItemById(id);

            if (item == null)
            {
                throw new ItemNotFoundException("Item not found.");
            }

            return item;
        }
    }
}
