using OrederService.Models.Enums;

namespace OrederService.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int InventoryId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string ShippingAdress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
