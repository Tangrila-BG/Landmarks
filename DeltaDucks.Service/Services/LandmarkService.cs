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

        public LandmarkService(IRepository<Landmark> irepository , IUnitOfWork unitOfWork)
        {
            this._landmarkRepository = irepository;
            //this._unitOfWork = unitOfWork;
        }


        public Landmark GetLandmarkById(int id)
        {
            return _landmarkRepository.GetById(id);
        }

    }
}
