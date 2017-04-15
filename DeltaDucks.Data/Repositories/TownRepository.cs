using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.Infrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    public class TownRepository : RepositoryBase<Town>, ITownRepository
    {
        public TownRepository(IDbFactory dbFactory) : base(dbFactory){}

        public Town GetByName(string townName)
        {
            return this.DbContext.Towns.FirstOrDefault(x => x.Name == townName);
        }
    }
}
