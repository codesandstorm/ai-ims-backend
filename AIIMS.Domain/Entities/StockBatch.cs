using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class StockBatch
    {
        [Key]
        public int StockBatchId { get; set; }

        public int StockId { get; set; }

        public Stock? Stock { get; set; }

        public int BatchId { get; set; }

        public Batch? Batch { get; set; }

        public int Quantity { get; set; }
    }
}