using System;

namespace DeltaDucks.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public int LandmarkId { get; set; }
        public virtual Landmark Landmark { get; set; }
    }
}
