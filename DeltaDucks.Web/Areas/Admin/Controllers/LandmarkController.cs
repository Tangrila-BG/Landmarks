using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.Areas.Admin.ViewModels;

namespace DeltaDucks.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin")]
    [RouteArea("Admin")]
    public class LandmarkController : Controller
    {
        private readonly ILandmarkService _landmarkService;
        private readonly IPictureService _pictureService;
        private readonly ITownService _townService;

        public LandmarkController(ILandmarkService landmarkService, IPictureService pictureService, ITownService townService)
        {
            this._landmarkService = landmarkService;
            this._pictureService = pictureService;
            this._townService = townService;
        }
//
//        // GET: Admin/Landmark
//        public ActionResult Index()
//        {
//            return View();
//        }

        public ActionResult Create()
        {
            return View();
        }    

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Pictures")]CreateLandmarkViewModel model)
        {
            var landmark = Mapper.Map<CreateLandmarkViewModel, Landmark>(model);
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                byte[] imageBytes = null;
                using (var binary = new BinaryReader(file.InputStream))
                {
                    imageBytes = binary.ReadBytes(file.ContentLength);
                    landmark.Pictures.Add(CreatePictures(imageBytes, model.Name + "" + i));
                }
            }
            var location = Mapper.Map<CreateLandmarkViewModel, Location>(model);
            var town = GetTown(model.Town);
            location.Town = town;
            landmark.Location = location;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _landmarkService.Add(landmark);
            _landmarkService.SaveLandmark();            
            return View();
        }

        private Picture CreatePictures(byte[] picture, string name)
        {
            var image = new Picture()
            {
                Name = name,
                ImageData = picture
            };

            return image;
        }

        private Town GetTown(string name)
        {
            var town = _townService.GetTownByName(name);
            if (town != null)
            {
                return town;
            }

            return new Town(){Name = name};
        }
    }
}