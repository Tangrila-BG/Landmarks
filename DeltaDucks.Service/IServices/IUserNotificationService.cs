using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface IUserNotificationService 
    {
        void Add(UserNotification notification);
        void Delete(int id);
        void Delete(string userId);
        void Update(UserNotification notification);
        void Save();
        IEnumerable<UserNotification> GetAll();

    }
}
