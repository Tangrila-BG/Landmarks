using DeltaDucks.Data.IInfrastructure;

namespace DeltaDucks.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DeltaDucksContext _dbContext;

        public DeltaDucksContext Init()
        {
            return _dbContext ?? (_dbContext = new DeltaDucksContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
