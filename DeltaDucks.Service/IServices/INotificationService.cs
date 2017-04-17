using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface INotificationService
    {
        void Add(Notification notification);
        void Delete(int id);
        void Update(Notification notification);
        void Save();
        IEnumerable<Notification> GetAll();
    }
}
