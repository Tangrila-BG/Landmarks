using System.Collections.Generic;

namespace DeltaDucks.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? Score { get; set; }

        public virtual ICollection<Landmark> VisitedLandmarks { get; set; }

        public User()
        {
            this.VisitedLandmarks = new HashSet<Landmark>();
        }
    }
}
