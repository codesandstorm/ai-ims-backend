using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Return
    {
        [Key]
        public int ReturnId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int BatchId { get; set; }

        public Batch? Batch { get; set; }

        public string Grade { get; set; } = string.Empty;

        public string Reason { get; set; } = string.Empty;

        public int ProcessedBy { get; set; }

        public User? ProcessedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}