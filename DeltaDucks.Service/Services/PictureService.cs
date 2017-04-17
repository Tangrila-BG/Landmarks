using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PictureService(IPictureRepository pictureRepository, IUnitOfWork unitOfWork)
        {
            this._pictureRepository = pictureRepository;
            this._unitOfWork = unitOfWork;
        }

        public void AddPicture(Picture picture)
        {
            _pictureRepository.AddPicture(picture);
        }

        public Picture GetPictureById(int id)
        {
            return _pictureRepository.GetPictureById(id);
        }

        public void DeletePictures(IEnumerable<Picture> pictures)
        {
            _pictureRepository.DeletePictutes(pictures);
        }

        public void SavePictures()
        {
            _unitOfWork.Commit();
        }
    }
}
