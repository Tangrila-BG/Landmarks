using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.Dtos;
using Microsoft.AspNet.Identity;

namespace DeltaDucks.Web.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        private readonly IUserNotificationService _userNotificationService;
        public NotificationsController(IUserNotificationService service)
        {
            this._userNotificationService = service;
        }
        [HttpGet]
        public IQueryable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var userNotifications = _userNotificationService
                .GetAll()
                .Where(n=>n.UserId == userId && !n.IsRead)
                .Select(n=>n.Notification)
                .AsQueryable()
                .ProjectTo<NotificationDto>();
            return userNotifications;
        }
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var userNotifications = _userNotificationService
                .GetAll()
                .Where(n => n.UserId == userId && !n.IsRead)
                .ToList();
            foreach (var notification in userNotifications)
            {
                notification.IsRead = true;
                _userNotificationService.Update(notification);
            }
            _userNotificationService.Save();
            return Ok();
        }
    }
}
