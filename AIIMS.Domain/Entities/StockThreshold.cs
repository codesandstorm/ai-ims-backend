using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class StockThreshold
    {
        [Key]
        public int ThresholdId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int MinQty { get; set; }

        public int MaxQty { get; set; }

        public int ReorderQty { get; set; }
    }
}