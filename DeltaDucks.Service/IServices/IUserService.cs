using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetUsers();
        void RegisterUser(ApplicationUser user);
        void UpdateUserPassword(string password);
        void LoginUser(string username, string password);
        int GetUserScore(string id);
        void SaveUser();
    }
}