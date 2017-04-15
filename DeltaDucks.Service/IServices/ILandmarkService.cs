using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface ILandmarkService
    {
         IEnumerable<Landmark> GetLandmarks();
        // Landmark GetLandmarkById(int id);

        IEnumerable<Landmark> GetSinglePageLendmarks(int page);
        IEnumerable<Landmark> GetUserVisitedLandmarks(string id);
        IEnumerable<Landmark> GetUserNotVisitedLandmarks(string id);
        void Add(Landmark landmark);
        int LandmarksCount();
    }
}
