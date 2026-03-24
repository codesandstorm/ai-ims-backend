using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        [Required]
        public string BatchNo { get; set; } = string.Empty;

        public DateTime MfgDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int QtyProduced { get; set; }

        public int QtyRemaining { get; set; }

        public ICollection<StockBatch>? StockBatches { get; set; }
    }
}