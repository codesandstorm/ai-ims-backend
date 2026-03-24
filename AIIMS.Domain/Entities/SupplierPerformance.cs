using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class SupplierPerformance
    {
        [Key]
        public int PerformanceId { get; set; }

        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public double OnTimeRate { get; set; }

        public double DefectRate { get; set; }

        public double AvgDelay { get; set; }

        public DateTime LastEvaluated { get; set; }
    }
}