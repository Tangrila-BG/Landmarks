namespace DeltaDucks.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Score { get; set; }

        public virtual ICollection<Landmark> VisitedLandmarks { get; set; }

        public User()
        {
            this.VisitedLandmarks = new HashSet<Landmark>();
        }
    }
}
