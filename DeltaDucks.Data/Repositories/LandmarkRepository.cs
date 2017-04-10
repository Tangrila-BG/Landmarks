using DeltaDucks.Data.IInfrastructure;
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

        // Hardcode number 
        public override void Update(Landmark entity)
        {
            entity.Number = 34;
            base.Update(entity);
        }
    }

    public interface ILandmarkRepository : IRepository<Landmark>
    {
        Landmark GetLandmarkByName(string landmarkName);
    }
}
