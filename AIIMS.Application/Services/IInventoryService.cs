using AIIMS.Domain.Entities;

namespace AIIMS.Application.Services
{
    public interface IInventoryService
    {
        // Existing methods
        Task StockIn(int itemId, int locationId, int quantity, int userId);
        Task StockOut(int itemId, int locationId, int quantity, int userId);
        Task TransferStock(int itemId, int fromLocationId, int toLocationId, int quantity, int userId);

        // NEW METHODS (READ APIs)
        Task<List<Stock>> GetStockByItem(int itemId);
        Task<List<InventoryTransaction>> GetAllTransactions();
        Task<List<Item>> GetAllItems();
    }
}