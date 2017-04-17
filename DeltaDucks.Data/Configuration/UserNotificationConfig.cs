using System.Data.Entity.ModelConfiguration;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Configuration
{
    public class UserNotificationConfig : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfig()
        {
            ToTable("UsersNotifications");
            this.HasKey(un => new { un.UserId, un.NotificationId });
        }
    }
}
