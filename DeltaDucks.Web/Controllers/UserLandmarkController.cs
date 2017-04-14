using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.ViewModels;
using Microsoft.AspNet.Identity;

namespace DeltaDucks.Web.Controllers
{
    public class UserLandmarkController : Controller
    {
        private readonly ILandmarkService _landmarkService;
        private readonly IUserService _userService;

        public UserLandmarkController(ILandmarkService landmarkService, IUserService userService)
        {
            this._landmarkService = landmarkService;
            this._userService = userService;
        }

        // GET: UserLandmark
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Visited()
        {
            VisitedLandmarksViewModel visitedLandmarksViewModel;
            IEnumerable<Landmark> userVisitedLandmarks;

            string userId = User.Identity.GetUserId();
            userVisitedLandmarks = _landmarkService.GetUserVisitedLandmarks(userId);

            var userScore = _userService.GetUserScore(userId);
            var userVisitedLandmarkViewModels = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(userVisitedLandmarks);

            visitedLandmarksViewModel = new VisitedLandmarksViewModel
            {
                Score = userScore,
                VisitedLandmarks = userVisitedLandmarkViewModels.ToList()
            };

            return View(visitedLandmarksViewModel);
        }

        public ActionResult NotVisited()
        {
            NotVisitedLandmarksViewModel notVisitedLandmarksViewModel;
            IEnumerable<Landmark> userNotVisitedLandmarks;

            string userId = User.Identity.GetUserId();
            userNotVisitedLandmarks = _landmarkService.GetUserNotVisitedLandmarks(userId);

            var userScore = _userService.GetUserScore(userId);
            var userNotVisitedLandmarkViewModels = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(userNotVisitedLandmarks);

            notVisitedLandmarksViewModel = new NotVisitedLandmarksViewModel()
            {
                Score = userScore,
                NotVisitedLandmarks = userNotVisitedLandmarkViewModels.ToList()
            };

            return View(notVisitedLandmarksViewModel);
        }

    }
}