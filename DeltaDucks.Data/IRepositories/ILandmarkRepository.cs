using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Models;

namespace DeltaDucks.Data.IRepositories
{
    public interface ILandmarkRepository : IRepository<Landmark>
    {
        Landmark GetLandmarkByName(string landmarkName);
    }
}