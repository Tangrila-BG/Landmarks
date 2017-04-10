using System.Collections.Generic;

namespace DeltaDucks.Models
{
    public class Town
    {
        public int TownId { get; set; }

       public string  Name { get; set; }

       public virtual  ICollection<Landmark> Landmarks { get; set; }

        public Town()
        {
            this.Landmarks = new HashSet<Landmark>();
        }
    }
}
