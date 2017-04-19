using System.Collections.Generic;
using System.Linq;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.Infrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Data.Repositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    public class LandmarkService : ILandmarkService
    {
        private readonly ILandmarkRepository _landmarkRepository;

        private readonly IUnitOfWork _unitOfWork;

        public LandmarkService(ILandmarkRepository landmarkRepository,IUnitOfWork unitOfWork)
        {
            this._landmarkRepository = landmarkRepository;
            this._unitOfWork = unitOfWork;
        }

        public Landmark GetLandmarkById(int id)
        {
            return _landmarkRepository.GetLandmarkById(id);
        }
        public IQueryable<Landmark> GetLandmarks()
        {      
                return _landmarkRepository.GetAll();    
        }


        // NOT USED
        //public IEnumerable<Landmark> GetSinglePageLendmarks(int page)
        //{
        //    const int recordsOnPage = 10; 
        //    int skip = (page - 1)*recordsOnPage;
        //    return _landmarkRepository.GetPageOfLendmarks(recordsOnPage, skip);
        //}

        public IQueryable<Landmark> GetUserVisitedLandmarks(string id)
        {
            return _landmarkRepository.GetUserVisitedLandmarks(id);
        }

        public IQueryable<Landmark> GetUserNotVisitedLandmarks(string id)
        {
            return _landmarkRepository.GetUserNotVisitedLandmarks(id);
        }

        public int LandmarksCount()
        {
            return _landmarkRepository.GetCount();
        }

        public void Add(Landmark landmark)
        {
            _landmarkRepository.Add(landmark);
        }

        public void SaveLandmark()
        {
            _unitOfWork.Commit();
        }

        public void IncreaseVisits(int id)
        {
            _landmarkRepository.IncreaseVisits(id);
        }

        public Landmark GetLandmarkByNumber(int number)
        {
           return _landmarkRepository.GetLandmarkByNumber(number);
        }

        public void DeleteLandmark(Landmark landmark)
        {
            _landmarkRepository.Delete(landmark);
        }

        public bool IsLandmarkExists(byte number)
        {
            var landmark = _landmarkRepository.GetLandmarkByNumber(number);
            return landmark != null;
        }
    }
}
