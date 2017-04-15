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

        public LandmarkController(ILandmarkService landmarkService, IPictureService pictureService)
        {
            this._landmarkService = landmarkService;
            this._pictureService = pictureService;
        }
//
//        // GET: Admin/Landmark
//        public ActionResult Index()
//        {
//            return View();
//        }

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

            _landmarkService.Add(landmark);
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
    }
}