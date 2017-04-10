namespace DeltaDucks.Models
{

    public class Landmark
    {
        public int LandmarkId { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int?  LocationId { get; set; }

        public virtual Location Location { get; set; }

    }
}
