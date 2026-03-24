using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class SystemLog
    {
        [Key]
        public int LogId { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public string LogType { get; set; } = string.Empty;

        public string Module { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string? StackTrace { get; set; }

        public string? IPAddress { get; set; }

        public string? DeviceId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}