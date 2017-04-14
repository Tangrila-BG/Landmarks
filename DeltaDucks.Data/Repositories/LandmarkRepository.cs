using System.Collections.Generic;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    using System.Linq;
    using Infrastructure;

    public class LandmarkRepository : RepositoryBase<Landmark>, ILandmarkRepository
    {
        public LandmarkRepository(IDbFactory dbFactory)
            : base(dbFactory) { }


        public Landmark GetLandmarkByName(string landmarkName)
        {
            return DbContext.Landmarks.FirstOrDefault(l => l.Name == landmarkName);
        }

        public IEnumerable<Landmark> GetPageOfLendmarks(int take, int skip)
        {
            return DbContext.Landmarks.OrderBy(x => x.Number).Skip(skip).Take(take);
        }

        // Hardcode number 
        public override void Update(Landmark entity)
        {
            entity.Number = 34;
            base.Update(entity);
        }
    }
}
