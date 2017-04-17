namespace DeltaDucks.Models
{
    public class UserNotification
    {
        public string UserId { get; set; }
        public int NotificationId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Notification Notification { get; set; }
        public bool IsRead { get; set; }
    }
}
