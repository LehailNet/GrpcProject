namespace InventoryManagementService.Models.ResponsModels
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public bool IsAvailable { get; set; }
    }
}
