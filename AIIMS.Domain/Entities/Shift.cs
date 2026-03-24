using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public ICollection<UserSession>? Sessions { get; set; }
    }
}