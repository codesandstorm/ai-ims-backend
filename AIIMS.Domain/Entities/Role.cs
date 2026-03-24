using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}