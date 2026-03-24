using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class InventoryTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public string Type { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public int? FromLocationId { get; set; }

        public Location? FromLocation { get; set; }

        public int? ToLocationId { get; set; }

        public Location? ToLocation { get; set; }

        public double? GPSLat { get; set; }

        public double? GPSLong { get; set; }

        public string? ReferenceNo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}