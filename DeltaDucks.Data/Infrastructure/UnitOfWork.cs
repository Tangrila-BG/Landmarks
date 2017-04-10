using System;
using DeltaDucks.Data.IInfrastructure;

namespace DeltaDucks.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DeltaDucksContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
           _dbFactory = dbFactory;
        }

        public DeltaDucksContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
