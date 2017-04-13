using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Service.Services;
using DeltaDucks.Web.ViewModels;

namespace DeltaDucks.Web.Controllers
{
    public class LandmarkController : Controller
    {
        private readonly ILandmarkService _landmarkService;

        public LandmarkController(ILandmarkService landmarkService)
        {
            this._landmarkService = landmarkService;
        }
        // GET: Landmark
        public ActionResult Index()
        {
            IEnumerable<LandmarkViewModel> landmarksViewModel;
            IEnumerable<Landmark> landmarks;

            landmarks = _landmarkService.GetLandmarks().ToList();

            landmarksViewModel = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(landmarks);
            return View(landmarksViewModel);
        }
    }
}