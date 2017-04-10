using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        void RegisterUser(User gadget);
        void UpdateUserPassword(string password);
        void LoginUser(string username, string password);
        void SaveUser();
    }
}