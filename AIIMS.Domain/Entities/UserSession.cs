using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class UserSession
    {
        [Key]
        public int SessionId { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public int ShiftId { get; set; }

        public Shift? Shift { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        public string? DeviceId { get; set; }

        public string? IPAddress { get; set; }
    }
}