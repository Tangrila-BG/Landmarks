using System.Collections.Generic;

namespace DeltaDucks.Models
{

    public class Landmark
    {
        public int LandmarkId { get; set; }

        public byte Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Information { get; set; }

        public int Visits { get; set; }

        public int Points { get; set; }

        public int?  LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<ApplicationUser> UsersVisited  { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public Landmark()
        {
            this.Visits = 0;
            this.UsersVisited = new HashSet<ApplicationUser>();
            this.Pictures = new HashSet<Picture>();
        }

    }
}
