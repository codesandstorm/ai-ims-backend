using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int LocationId { get; set; }

        public Location? Location { get; set; }

        public int Quantity { get; set; }

        public int ReservedQty { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public ICollection<StockBatch>? StockBatches { get; set; }
    }
}