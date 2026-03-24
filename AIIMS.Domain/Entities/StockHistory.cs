using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class StockHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int QtyChange { get; set; }

        public string Reason { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}