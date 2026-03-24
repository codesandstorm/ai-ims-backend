using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Barcode
    {
        [Key]
        public int BarcodeId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        public int Version { get; set; }

        public bool IsActive { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }
}