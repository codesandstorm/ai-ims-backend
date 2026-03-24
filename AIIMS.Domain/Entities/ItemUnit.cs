using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class ItemUnit
    {
        [Key]
        public int ItemUnitId { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int UnitId { get; set; }

        public Unit? Unit { get; set; }

        public bool IsBase { get; set; }
    }
}