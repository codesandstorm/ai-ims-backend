using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class ActivityLog
    {
        [Key]
        public int ActivityId { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public string Action { get; set; } = string.Empty;

        public string Entity { get; set; } = string.Empty;

        public int EntityId { get; set; }

        public string? OldValue { get; set; }

        public string? NewValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}