using System.Collections.Generic;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserNotificationService(IUserNotificationRepository userNotificationRepository,IUnitOfWork unitOfWork)
        {
            this._userNotificationRepository = userNotificationRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(UserNotification notification)
        {
            this._userNotificationRepository.Add(notification);
        }

        public void Delete(int id)
        {
            
            this._userNotificationRepository.Delete(un=>un.UserId == id.ToString() );
        }

        public void Delete(string userId)
        {
            
            this._userNotificationRepository.Delete(un=>un.UserId == userId);
        }

        public void Update(UserNotification notification)
        {
            this._userNotificationRepository.Update(notification);
        }

        public void Save()
        {
           this._unitOfWork.Commit();
        }

        public IEnumerable<UserNotification> GetAll()
        {
            return this._userNotificationRepository.GetAll();
        }
    }
}
