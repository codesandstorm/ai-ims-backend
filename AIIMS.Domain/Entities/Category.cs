using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}