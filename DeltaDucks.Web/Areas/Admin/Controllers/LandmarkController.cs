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
using DeltaDucks.Web.ViewModels;

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
        public ActionResult Index(int page = 1)
        {
            IEnumerable<LandmarkViewModel> landmarksViewModel;
            IEnumerable<Landmark> landmarks;
            const int recordsOnPage = 10;
            int landmarksCount = _landmarkService.LandmarksCount();
            this.ViewBag.MaxPage = (landmarksCount / recordsOnPage) + (landmarksCount % recordsOnPage > 0 ? 1 : 0);
            this.ViewBag.MinPage = 1;
            this.ViewBag.Page = page;

            landmarks = _landmarkService.GetSinglePageLendmarks(page).ToList();

            landmarksViewModel = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(landmarks);
            return View(landmarksViewModel);
        }

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
            return RedirectToAction("Index", "Home");
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

        [HttpGet]
        public ActionResult Delete(int number)
        {
            Landmark landmark = _landmarkService.GetLandmarkByNumber(number);
            if (landmark == null)
            {
                return HttpNotFound();
            }
            LandmarkViewModel model = Mapper.Map<Landmark, LandmarkViewModel>(landmark);
            
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int number)
        {
            Landmark landmark = _landmarkService.GetLandmarkByNumber(number);
            _landmarkService.DeleteLandmark(landmark);
            _landmarkService.SaveLandmark();
             return RedirectToAction("Index");
        }
    }
}