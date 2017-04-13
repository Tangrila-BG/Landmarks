using System.Collections.Generic;
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

    }
}
