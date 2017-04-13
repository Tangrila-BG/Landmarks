using System.Collections.Generic;

namespace DeltaDucks.Models
{
    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public Town()
        {
            this.Locations = new HashSet<Location>();
        }
    }
}
