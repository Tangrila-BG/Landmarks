using System.Collections.Generic;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    using System.Linq;
    using Infrastructure;

    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {

        public ApplicationUserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.DbContext.Users.FirstOrDefault(u => u.UserName == username);
        }

        public int GetUserScore(string id)
        {
            return this.GetById(id).Score;
        }

        public IEnumerable<ApplicationUser> GetPageOfUsers(int take, int skip)
        {
            return DbContext.Users.OrderBy(x => x.UserName).Skip(skip).Take(take);
        }

        public void IncreaseScore(string id, int score)
        {
            this.GetById(id).Score += score;
            DbContext.Commit();
        }

        public void AddVisit(string id, int landmarkId)
        {
            this.GetById(id).VisitedLandmarks
                .Add(DbContext.Landmarks.FirstOrDefault(l => l.LandmarkId == landmarkId));
            DbContext.Commit();
        }
    }
}
