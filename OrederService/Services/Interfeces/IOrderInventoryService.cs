namespace OrederService.Services.Interfeces
{
    public interface IOrderInventoryService
    {
        Task<bool> IsItemAvailableAsync(int itemId);
    }
}
