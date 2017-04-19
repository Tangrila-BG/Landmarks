using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.Infrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    public class UserNotificationRepository : RepositoryBase<UserNotification>,IUserNotificationRepository
    {
        public UserNotificationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
