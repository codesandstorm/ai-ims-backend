using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class ReorderSuggestion
    {
        [Key]
        public int SuggestionId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int SuggestedQty { get; set; }

        public DateTime ReorderDate { get; set; }

        public string Status { get; set; } = "Pending";
    }
}