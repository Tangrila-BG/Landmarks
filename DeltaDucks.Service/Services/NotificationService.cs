using System.Collections.Generic;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            this._notificationRepository = notificationRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Notification notification)
        {
            this._notificationRepository.Add(notification);
        }

        public void Delete(int id)
        {
           this._notificationRepository.Delete(n=>n.Id == id);
        }

        public void Update(Notification notification)
        {
            this._notificationRepository.Update(notification);
        }

        public void Save()
        {
           this._unitOfWork.Commit();
        }

        public IEnumerable<Notification> GetAll()
        {
           return this._notificationRepository.GetAll();
        }
    }
}
