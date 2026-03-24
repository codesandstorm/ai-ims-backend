using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Zone
    {
        [Key]
        public int ZoneId { get; set; }

        public int WarehouseId { get; set; }

        public Warehouse? Warehouse { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Location>? Locations { get; set; }
    }
}