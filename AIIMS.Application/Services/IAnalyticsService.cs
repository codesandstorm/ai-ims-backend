using AIIMS.Domain.Entities;

namespace AIIMS.Application.Services
{
    public interface IAnalyticsService
    {
        Task<List<Item>> GetDeadStockItems(int days);

        Task<List<Stock>> GetLowStockItems();

        Task GenerateReorderSuggestions();
    }
}