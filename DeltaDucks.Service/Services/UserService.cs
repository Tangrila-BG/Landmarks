using System.Collections.Generic;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.Infrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Data.Repositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public void UpdateUserPassword(string pasword) { }

        public void LoginUser(string username, string password) { }

        public void RegisterUser(User user)
        {
            _userRepository.Add(user);
        }

        public void SaveUser()
        {
            _unitOfWork.Commit();
        }
    }
}
