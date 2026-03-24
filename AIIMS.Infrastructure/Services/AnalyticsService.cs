using AIIMS.Application.Services;
using AIIMS.Domain.Entities;
using AIIMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AIIMS.Infrastructure.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly AppDbContext _context;

        public AnalyticsService(AppDbContext context)
        {
            _context = context;
        }

        // Detect items with no movement for X days
        public async Task<List<Item>> GetDeadStockItems(int days)
        {
            var cutoffDate = DateTime.UtcNow.AddDays(-days);

            var deadStockItems = await _context.Items
                .Where(item =>
                    !_context.InventoryTransactions
                    .Any(t => t.ItemId == item.ItemId && t.CreatedAt > cutoffDate))
                .ToListAsync();

            return deadStockItems;
        }

        // Detect items below minimum stock level
        public async Task<List<Stock>> GetLowStockItems()
        {
            var lowStock = await _context.Stocks
                .Join(_context.StockThresholds,
                    stock => stock.ItemId,
                    threshold => threshold.ItemId,
                    (stock, threshold) => new { stock, threshold })
                .Where(x => x.stock.Quantity <= x.threshold.MinQty)
                .Select(x => x.stock)
                .ToListAsync();

            return lowStock;
        }

        // Generate reorder suggestions automatically
        public async Task GenerateReorderSuggestions()
        {
            var thresholds = await _context.StockThresholds.ToListAsync();

            foreach (var threshold in thresholds)
            {
                var stock = await _context.Stocks
                    .FirstOrDefaultAsync(s => s.ItemId == threshold.ItemId);

                if (stock != null && stock.Quantity <= threshold.MinQty)
                {
                    var suggestion = new ReorderSuggestion
                    {
                        ItemId = threshold.ItemId,
                        SuggestedQty = threshold.ReorderQty,
                        ReorderDate = DateTime.UtcNow,
                        Status = "PENDING"
                    };

                    await _context.ReorderSuggestions.AddAsync(suggestion);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}