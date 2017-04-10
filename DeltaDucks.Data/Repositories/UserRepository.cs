using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    using System.Linq;
    using Infrastructure;

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public User GetUserByUsername(string username)
        {
            return this.DbContext.Users.FirstOrDefault(u => u.Name == username);
        }
    }
}
