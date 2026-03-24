using Microsoft.EntityFrameworkCore;
using AIIMS.Domain.Entities;

namespace AIIMS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Security
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        // Procurement
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierPerformance> SupplierPerformances { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<POItem> POItems { get; set; }

        // Product Master
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemUnit> ItemUnits { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }

        // Warehouse
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Location> Locations { get; set; }

        // Inventory
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<StockBatch> StockBatches { get; set; }

        // Transactions
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Return> Returns { get; set; }

        // Alerts
        public DbSet<StockThreshold> StockThresholds { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // Logs
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        // Analytics
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<DemandForecast> DemandForecasts { get; set; }
        public DbSet<ReorderSuggestion> ReorderSuggestions { get; set; }
    }
}