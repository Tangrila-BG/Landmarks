using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.Areas.Admin.ViewModels;
using DeltaDucks.Web.ViewModels;
using PagedList;

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
        private readonly ILocationService _locationService;

        public LandmarkController(ILandmarkService landmarkService, IPictureService pictureService, ITownService townService, ILocationService locationService)
        {
            this._landmarkService = landmarkService;
            this._pictureService = pictureService;
            this._townService = townService;
            this._locationService = locationService;
        }
        //
        //        // GET: Admin/Landmark
        public ActionResult Index(int? page)  // int page = 1
        {
            const int recordsOnPage = 10;
            //int landmarksCount = _landmarkService.LandmarksCount();
            //this.ViewBag.MaxPage = (landmarksCount / recordsOnPage) + (landmarksCount % recordsOnPage > 0 ? 1 : 0);
            //this.ViewBag.MinPage = 1;
            //this.ViewBag.Page = page;

            //landmarks = _landmarkService.GetSinglePageLendmarks(page).ToList();

            var landmarks = _landmarkService.GetLandmarks()
                .ProjectTo<LandmarkViewModel>()
                .ToList();

            int pageNumber = (page ?? 1);
            return View(landmarks.ToPagedList(pageNumber, recordsOnPage));
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
                if (file.ContentLength == 0)
                {
                    break;
                }
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

        [HttpGet]
        public ActionResult Update(int number)
        {
            Landmark landmark = _landmarkService.GetLandmarkByNumber(number);
            if (landmark == null)
            {
                return HttpNotFound();
            }
            UpdateLandmarksViewModel model = Mapper.Map<Landmark, UpdateLandmarksViewModel>(landmark);
            return View(model);
        }

        [HttpPost, ActionName("Update")]
        public ActionResult UpdateConfirm(UpdateLandmarksViewModel model)
        {
            var landmark = _landmarkService.GetLandmarkById(model.LandmarkId);
            DeletePictures(landmark.Pictures);
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                if (file.ContentLength == 0)
                {
                    break;
                }
                byte[] imageBytes = null;
                using (var binary = new BinaryReader(file.InputStream))
                {
                    imageBytes = binary.ReadBytes(file.ContentLength);
                    landmark.Pictures.Add(CreatePictures(imageBytes, model.Name + "u" + i));
                }
            }
            SetLandmarkProps(landmark, model);
            Location location = GetLocation(model.Latitude, model.Longitude);
            var town = GetTown(model.Town);
            location.Town = town;
            landmark.Location = location;
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }
            _landmarkService.SaveLandmark();
            return RedirectToAction("Index");
        }

        private void SetLandmarkProps(Landmark landmark, UpdateLandmarksViewModel model)
        {
            landmark.Code = model.Code;
            landmark.Number = model.Number;
            landmark.Name = model.Name;
            landmark.Description = model.Description;
            landmark.Information = model.Information;
            landmark.Points = model.Points;
        }

        private void DeletePictures(ICollection<Picture> pictures)
        {
            
            List<Picture> picturesForDelete = new List<Picture>();
            foreach (var picture in pictures)
            {
                var id = picture.PictureId;
                var result = Request.Form[id.ToString()];
                if (result == "true,false")
                {
                    var pictureForDelete = _pictureService.GetPictureById(id);
                    picturesForDelete.Add(pictureForDelete);
                }
            }
            _pictureService.DeletePictures(picturesForDelete);
            _pictureService.SavePictures();
        }

        private Location GetLocation(double latitude, double longitude)
        {
            Location location = _locationService.GetLocationByCoordinates(latitude, longitude);
            if (location != null)
            {
                return location;
            }

            return new Location()
            {
                Longitude = longitude,
                Latitude = latitude
            };
        }
    }
}