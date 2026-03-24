using System.ComponentModel.DataAnnotations;

namespace AIIMS.Domain.Entities
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public int ZoneId { get; set; }

        public Zone? Zone { get; set; }

        public string? Rack { get; set; }

        public string? Shelf { get; set; }

        public string? Bin { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public string? LocationType { get; set; }
    }
}