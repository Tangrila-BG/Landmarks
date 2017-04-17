using System;
using DeltaDucks.Models;

namespace DeltaDucks.Web.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public NotificationLandmarkDto Landmark { get; set; }
    }
}