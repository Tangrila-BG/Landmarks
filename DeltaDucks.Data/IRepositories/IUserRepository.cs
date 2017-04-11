using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Models;

namespace DeltaDucks.Data.IRepositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUserByUsername(string username);
    }
}