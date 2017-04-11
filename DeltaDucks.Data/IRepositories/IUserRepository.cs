using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Models;

namespace DeltaDucks.Data.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
    }
}