using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    using System.Linq;
    using Infrastructure;

    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.DbContext.Users.FirstOrDefault(u => u.UserName == username);
        }

    }
}
