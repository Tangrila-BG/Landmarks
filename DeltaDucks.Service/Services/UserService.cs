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
        private readonly IApplicationUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IApplicationUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public ApplicationUser GetUserByUserName(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _userRepository.GetById(userId);
        }

        public void DeleteUser(ApplicationUser user)
        {
            _userRepository.Delete(user);
        }

        public void UpdateUserPassword(string pasword) { }

        public void LoginUser(string username, string password) { }

        public void RegisterUser(ApplicationUser user)
        {
            _userRepository.Add(user);
        }

        public int GetUserScore(string id)
        {
            return _userRepository.GetUserScore(id);
        }

        public IEnumerable<ApplicationUser> GetSinglePageUsers(int page, int limit)
        {
            int skip = (page - 1) * limit;
            return _userRepository.GetPageOfUsers(limit, skip);
        }

        public void SaveUser()
        {
            _unitOfWork.Commit();
        }
    }
}