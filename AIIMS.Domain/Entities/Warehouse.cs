using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public ICollection<Zone>? Zones { get; set; }
    }
}