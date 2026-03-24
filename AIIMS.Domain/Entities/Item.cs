using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIIMS.Domain.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string SKU { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public int BaseUnitId { get; set; }

        public Unit? BaseUnit { get; set; }

        public decimal BasePrice { get; set; }

        public bool IsBatchTracked { get; set; }

        public bool IsExpiryTracked { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ItemUnit>? ItemUnits { get; set; }

        public ICollection<Barcode>? Barcodes { get; set; }

        [NotMapped]
        public int Quantity { get; set; }
    }
}