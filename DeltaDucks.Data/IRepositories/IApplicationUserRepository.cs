using System.Collections.Generic;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Models;

namespace DeltaDucks.Data.IRepositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUserByUsername(string username);
        IEnumerable<ApplicationUser> GetPageOfUsers(int take, int skip);
        int GetUserScore(string id);
        void IncreaseScore(string id, int score);
        void AddVisit(string id, int landmarkId);
    }
}