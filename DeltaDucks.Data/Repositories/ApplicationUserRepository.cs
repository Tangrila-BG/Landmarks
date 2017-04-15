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
            : base(dbFactory) { }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.DbContext.Users.FirstOrDefault(u => u.UserName == username);
        }

        public IEnumerable<ApplicationUser> GetPageOfUsers(int take, int skip)
        {
            return DbContext.Users.OrderBy(x => x.UserName).Skip(skip).Take(take);
        }

        public int GetUserScore(string id)
        {
            return this.DbContext.Users.FirstOrDefault(u => u.Id == id).Score;
        }
    }
}
