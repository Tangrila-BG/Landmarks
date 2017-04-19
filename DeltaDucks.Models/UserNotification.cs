using System;

namespace DeltaDucks.Models
{
    public class UserNotification
    {
        public string UserId { get;private set; }
        public int NotificationId { get;private set; }
        public virtual ApplicationUser User { get;private set; }
        public virtual Notification Notification { get;private set; }
        public bool IsRead { get;private set; }

        public void Read()
        {
            this.IsRead = true;
        }

        protected UserNotification()
        {
            
        }

        public UserNotification(ApplicationUser user,Notification notification)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            this.IsRead = false;
            this.Notification = notification;
            this.User = user;
        }
    }
}
