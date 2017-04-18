using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Service.Services;
using DeltaDucks.Web.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;

namespace DeltaDucks.Web.Controllers
{
    public class LandmarkController : Controller
    {
        private readonly ILandmarkService _landmarkService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public LandmarkController(ILandmarkService landmarkService, IUserService userService, ICommentService commentService)
        {
            this._landmarkService = landmarkService;
            this._userService = userService;
            this._commentService = commentService;
        }
        // GET: Landmark
        //        public ActionResult Index()
        //        {
        //            IEnumerable<LandmarkViewModel> landmarksViewModel;
        //            IEnumerable<Landmark> landmarks;
        //
        //            landmarks = _landmarkService.GetLandmarks().ToList();
        //
        //            landmarksViewModel = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(landmarks);
        //            return View(landmarksViewModel);
        //        }

        public ActionResult Index(int? page)
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

        public ActionResult Details(int number)
        {
            var landmark = Mapper.Map<Landmark, LandmarkViewModel>(
                    _landmarkService.GetLandmarkByNumber(number));

            landmark.Comments = _commentService
                .GetCommentsByLandmarkId(landmark.LandmarkId)
                .ToList();
                
            ViewBag.Pictures = RenderPicture(landmark);
            return View(landmark);
        }

        private ICollection<byte[]> RenderPicture(LandmarkViewModel viewModel)
        {
            List<byte[]> pictures = new List<byte[]>();
            foreach (var picture in viewModel.Pictures)
            {
                pictures.Add(picture.ImageData);
            }
            return pictures;
        }

        [HttpPost]
        public ActionResult CheckCode(int id, string code)
        {
            Landmark landmark = _landmarkService.GetLandmarkById(id);

            if (landmark.Code != code)
            {
                return HttpNotFound();
            }
            string userId = User.Identity.GetUserId();
            _userService.IncreaseScore(userId, landmark.Points);
            _userService.AddVisit(userId, id);
            _landmarkService.IncreaseVisits(id);

            return new EmptyResult();
        }
    }
}