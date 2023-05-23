using AutoMapper;
using InventoryManagementService.Models.ResponsModels;
using InventoryManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet("info/{id}")]
        [ProducesResponseType(typeof(ItemResponse), 200)]
        public ActionResult<ItemResponse> GetItemInfo(int id)
        {
            var item = _itemService.GetItemInfo(id);

            return Ok(_mapper.Map<ItemResponse>(item));
        }

        [HttpGet("availability/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult<bool> IsItemAvailable(int id)
        {
            var isAvailable = _itemService.IsItemAvailable(id);

            return Ok(isAvailable);
        }
    }
}
