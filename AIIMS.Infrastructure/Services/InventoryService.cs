using AIIMS.Application.Services;
using AIIMS.Domain.Entities;
using AIIMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AIIMS.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        // ========================
        // STOCK IN
        // ========================
        public async Task StockIn(int itemId, int locationId, int quantity, int userId)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.ItemId == itemId && s.LocationId == locationId);

            if (stock == null)
            {
                stock = new Stock
                {
                    ItemId = itemId,
                    LocationId = locationId,
                    Quantity = quantity,
                    ReservedQty = 0,
                    LastUpdated = DateTime.UtcNow
                };

                await _context.Stocks.AddAsync(stock);
            }
            else
            {
                stock.Quantity += quantity;
                stock.LastUpdated = DateTime.UtcNow;
            }

            var transaction = new InventoryTransaction
            {
                ItemId = itemId,
                UserId = userId,
                Type = "IN",
                Quantity = quantity,
                ToLocationId = locationId,
                CreatedAt = DateTime.UtcNow
            };

            await _context.InventoryTransactions.AddAsync(transaction);

            await _context.SaveChangesAsync();
        }

        // ========================
        // STOCK OUT
        // ========================
        public async Task StockOut(int itemId, int locationId, int quantity, int userId)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.ItemId == itemId && s.LocationId == locationId);

            if (stock == null || stock.Quantity < quantity)
            {
                throw new Exception("Insufficient stock");
            }

            stock.Quantity -= quantity;
            stock.LastUpdated = DateTime.UtcNow;

            var transaction = new InventoryTransaction
            {
                ItemId = itemId,
                UserId = userId,
                Type = "OUT",
                Quantity = quantity,
                FromLocationId = locationId,
                CreatedAt = DateTime.UtcNow
            };

            await _context.InventoryTransactions.AddAsync(transaction);

            await _context.SaveChangesAsync();
        }

        // ========================
        // TRANSFER STOCK
        // ========================
        public async Task TransferStock(int itemId, int fromLocationId, int toLocationId, int quantity, int userId)
        {
            var sourceStock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.ItemId == itemId && s.LocationId == fromLocationId);

            if (sourceStock == null || sourceStock.Quantity < quantity)
            {
                throw new Exception("Insufficient stock for transfer");
            }

            sourceStock.Quantity -= quantity;
            sourceStock.LastUpdated = DateTime.UtcNow;

            var destinationStock = await _context.Stocks
                .FirstOrDefaultAsync(s => s.ItemId == itemId && s.LocationId == toLocationId);

            if (destinationStock == null)
            {
                destinationStock = new Stock
                {
                    ItemId = itemId,
                    LocationId = toLocationId,
                    Quantity = quantity,
                    ReservedQty = 0,
                    LastUpdated = DateTime.UtcNow
                };

                await _context.Stocks.AddAsync(destinationStock);
            }
            else
            {
                destinationStock.Quantity += quantity;
                destinationStock.LastUpdated = DateTime.UtcNow;
            }

            var transaction = new InventoryTransaction
            {
                ItemId = itemId,
                UserId = userId,
                Type = "TRANSFER",
                Quantity = quantity,
                FromLocationId = fromLocationId,
                ToLocationId = toLocationId,
                CreatedAt = DateTime.UtcNow
            };

            await _context.InventoryTransactions.AddAsync(transaction);

            await _context.SaveChangesAsync();
        }

        // ========================
        // NEW READ METHODS
        // ========================

        public async Task<List<Stock>> GetStockByItem(int itemId)
        {
            return await _context.Stocks
                .Where(s => s.ItemId == itemId)
                .Include(s => s.Location)
                .ToListAsync();
        }

        public async Task<List<InventoryTransaction>> GetAllTransactions()
        {
            return await _context.InventoryTransactions
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Item>> GetAllItems()
        {
            var items = await _context.Items
                .Include(i => i.Category)
                .ToListAsync();

            foreach (var item in items)
            {
                item.Quantity = await _context.Stocks
                    .Where(s => s.ItemId == item.ItemId)
                    .SumAsync(s => (int?)s.Quantity) ?? 0;
            }

            return items;
        }
    }
}