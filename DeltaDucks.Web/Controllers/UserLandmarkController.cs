﻿using System;
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
            UserLandmarkViewModel userLandmarkViewModel;
            IEnumerable<Landmark> userVisitedLandmarks;
            IEnumerable<Landmark> userNotVisitedLandmarks;

            string userId = User.Identity.GetUserId();
            userVisitedLandmarks = _landmarkService.GetUserVisitedLandmarks(userId);
            userNotVisitedLandmarks = _landmarkService.GetUserNotVisitedLandmarks(userId);
     
            var userScore = _userService.GetUserScore(userId);
            var userVisitedLandmarkViewModels = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(userVisitedLandmarks);
            var userNotVisitedLandmarkViewModels = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(userNotVisitedLandmarks);

            userLandmarkViewModel = new UserLandmarkViewModel
            {
                Score = userScore,
                VisitedLandmarks = userVisitedLandmarkViewModels.ToList(),
                NotVisitedLandmarks = userNotVisitedLandmarkViewModels.ToList()
            };
            return View(userLandmarkViewModel);
        }
    }
}