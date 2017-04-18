using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface ILandmarkService
    {
        IEnumerable<Landmark> GetLandmarks();
        Landmark GetLandmarkById(int id);
       // IEnumerable<Landmark> GetSinglePageLendmarks(int page);
        IEnumerable<Landmark> GetUserVisitedLandmarks(string id);
        IEnumerable<Landmark> GetUserNotVisitedLandmarks(string id);
        void Add(Landmark landmark);
        void DeleteLandmark(Landmark landmark);
        int LandmarksCount();
        void SaveLandmark();
        void IncreaseVisits(int id);
        Landmark GetLandmarkByNumber(int number);
    }
}
