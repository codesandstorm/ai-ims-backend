using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public Role? Role { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? LastLogin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserSession>? Sessions { get; set; }
    }
}