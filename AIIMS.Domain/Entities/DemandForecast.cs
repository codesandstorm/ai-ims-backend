using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class DemandForecast
    {
        [Key]
        public int ForecastId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public DateTime ForecastDate { get; set; }

        public int PredictedQty { get; set; }

        public string ModelVersion { get; set; } = string.Empty;
    }
}