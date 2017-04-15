using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetUsers();
        IEnumerable<ApplicationUser> GetSinglePageUsers(int page,int limit);
        ApplicationUser GetUserByUserName(string userId);
        ApplicationUser GetUserById(string userId);
        void DeleteUser(ApplicationUser user);
        void RegisterUser(ApplicationUser user);
        void UpdateUserPassword(string password);
        void LoginUser(string username, string password);
        int GetUserScore(string id);
        void SaveUser();
    }
}