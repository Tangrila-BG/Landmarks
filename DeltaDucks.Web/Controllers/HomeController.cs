using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeltaDucks.Models;
using DeltaDucks.Service.Interfaces;
using DeltaDucks.Service.Services;
using DeltaDucks.Web.Models;
using DeltaDucks.Web.ViewModels;

namespace DeltaDucks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILandmarkService _landmarkService;

        public HomeController(ILandmarkService landmarkService)
        {

            _landmarkService = landmarkService;

            this._landmarkService = landmarkService;
        }

        public ActionResult Index()
        {

            Landmark landmark = _landmarkService.GetLandmarkById(1);

            LandmarkViewModel landmarkViewModel = new LandmarkViewModel
            {
                Name = landmark.Name
            };
            return View(landmarkViewModel);
        }
    }
}