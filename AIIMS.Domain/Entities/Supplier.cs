using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        public string? HeadOfficeAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ContactPerson { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? GSTNumber { get; set; }

        public string? PAN { get; set; }

        public string? BankAccount { get; set; }

        public string? IFSC { get; set; }

        public int LeadTimeDays { get; set; }

        public double ReliabilityScore { get; set; }

        public double Rating { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }
}