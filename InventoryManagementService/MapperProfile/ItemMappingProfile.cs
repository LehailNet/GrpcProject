using AutoMapper;
using InventoryManagementService.Models;
using InventoryManagementService.Models.Entities;
using InventoryManagementService.Models.ResponsModels;

namespace InventoryManagementService.MapperProfile
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, ItemModel>();
            CreateMap<ItemModel, ItemResponse>();
        }
    }
}
