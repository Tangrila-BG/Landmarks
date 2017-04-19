using System.Collections.Generic;
using System.Linq;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface ILandmarkService
    {
        IQueryable<Landmark> GetLandmarks();
        Landmark GetLandmarkById(int id);
        // IEnumerable<Landmark> GetSinglePageLendmarks(int page);
        IQueryable<Landmark> GetUserVisitedLandmarks(string id);
        IQueryable<Landmark> GetUserNotVisitedLandmarks(string id);
        void Add(Landmark landmark);
        void DeleteLandmark(Landmark landmark);
        int LandmarksCount();
        void SaveLandmark();
        void IncreaseVisits(int id);
        Landmark GetLandmarkByNumber(int number);
        bool IsLandmarkExists(byte number);
    }
}
