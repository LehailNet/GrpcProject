namespace OrederService.Models.RequestModels
{
    public class OrderRequest
    {
        public int InventoryId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string ShippingAdress { get; set; }
    }
}
