using System.Collections.Generic;
using System.Linq;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.Infrastructure;
using DeltaDucks.Data.Repositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    public class LandmarkService : ILandmarkService
    {
        private readonly IRepository<Landmark> _landmarkRepository;

        // NOT USED YET 
        //private readonly IUnitOfWork _unitOfWork;

        public LandmarkService(IRepository<Landmark> landmarkRepository) //,IUnitOfWork unitOfWork)
        {
            this._landmarkRepository = landmarkRepository;
            //this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Landmark> GetLandmarks()
        {      
                return _landmarkRepository.GetAll();    
        }

        public IEnumerable<Landmark> GetSinglePageLendmarks(int page)
        {
            const int recordsOnPage = 10; 
            int skip = (page - 1)*recordsOnPage;
            int take = recordsOnPage;
            return _landmarkRepository.GetAll().OrderBy(x => x.Number).Skip(skip).Take(take);
        }

        public int LandmarksCount()
        {
            return _landmarkRepository.GetCount();
        }
    }
}
