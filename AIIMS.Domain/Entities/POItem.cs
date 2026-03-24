using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class POItem
    {
        [Key]
        public int POItemId { get; set; }

        public int POId { get; set; }

        public PurchaseOrder? PurchaseOrder { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int QtyOrdered { get; set; }

        public decimal UnitPrice { get; set; }
    }
}