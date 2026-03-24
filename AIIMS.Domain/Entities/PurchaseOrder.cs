using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class PurchaseOrder
    {
        [Key]
        public int POId { get; set; }

        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ExpectedDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public ICollection<POItem>? Items { get; set; }
    }
}