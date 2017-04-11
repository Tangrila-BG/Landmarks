using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    using System.Linq;
    using Infrastructure;

    public class UserApplicationRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUser GetUserByUsername(string username)
        {
            return this.DbContext.Users.FirstOrDefault(u => u.UserName == username);
        }

        public UserApplicationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
