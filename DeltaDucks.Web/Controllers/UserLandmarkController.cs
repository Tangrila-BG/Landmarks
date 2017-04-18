using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            var visitedLandmarksViewModel = GetVisitedLandmarks();
            return View(visitedLandmarksViewModel);
        }

        public ActionResult NotVisited()
        {
            var notVisitedLandmarksViewModel = GetNotVisitedLandmarks();
            return View(notVisitedLandmarksViewModel);
        }

        public ActionResult Recommended()
        {
            var recommended = GetRecommended();
            return View(recommended);
        }

        public VisitedLandmarksViewModel GetVisitedLandmarks()
        {
            string userId = User.Identity.GetUserId();
            var userVisitedLandmarks = _landmarkService
                .GetUserVisitedLandmarks(userId)
                .ProjectTo<LandmarkViewModel>()
                .ToList();

            var userScore = _userService.GetUserScore(userId);
            var visitedLandmarksViewModel = new VisitedLandmarksViewModel
            {
                Score = userScore,
                VisitedLandmarks = userVisitedLandmarks
            };

            return visitedLandmarksViewModel;
        }

        public NotVisitedLandmarksViewModel GetNotVisitedLandmarks()
        {
            string userId = User.Identity.GetUserId();
            var userNotVisitedLandmarks = _landmarkService
                .GetUserNotVisitedLandmarks(userId)
                .ProjectTo<LandmarkViewModel>()
                .ToList();

            var userScore = _userService.GetUserScore(userId);

            var notVisitedLandmarksViewModel = new NotVisitedLandmarksViewModel()
            {
                Score = userScore,
                NotVisitedLandmarks = userNotVisitedLandmarks
            };

            return notVisitedLandmarksViewModel;
        }

        public NotVisitedLandmarksViewModel GetRecommended()
        {
            var notVisitedLandmarks = GetNotVisitedLandmarks();
            notVisitedLandmarks.NotVisitedLandmarks 
                = notVisitedLandmarks.NotVisitedLandmarks.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
            return notVisitedLandmarks;
        }

    }
}