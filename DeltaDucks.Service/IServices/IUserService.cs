using System.Collections.Generic;
using System.Linq;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface IUserService
    {
        IQueryable<ApplicationUser> GetUsers();
        IQueryable<ApplicationUser> GetSinglePageUsers(int page,int limit);
        ApplicationUser GetUserByUserName(string userId);
        ApplicationUser GetUserById(string userId);
        void DeleteUser(ApplicationUser user);
        void RegisterUser(ApplicationUser user);
        void UpdateUserPassword(string password);
        void LoginUser(string username, string password);
        int GetUserScore(string id);
        void IncreaseScore(string id, int score);
        void AddVisit(string id, int landmarkId);
        void SaveUser();
        void UpdateUser(ApplicationUser user);
    }
}