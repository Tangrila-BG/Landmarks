using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface ILandmarkService
    {
         IEnumerable<Landmark> GetLandmarks();
        // Landmark GetLandmarkById(int id);
    }
}
