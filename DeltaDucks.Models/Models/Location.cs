namespace DeltaDucks.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public double Latitude { get; set; }

        public double  Longitude { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }
    }
}
