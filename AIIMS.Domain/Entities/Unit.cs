using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Symbol { get; set; } = string.Empty;

        public double ConversionFactor { get; set; }

        public ICollection<ItemUnit>? ItemUnits { get; set; }
    }
}