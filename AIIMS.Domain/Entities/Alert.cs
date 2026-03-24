using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Alert
    {
        [Key]
        public int AlertId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public string AlertType { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public bool IsResolved { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}