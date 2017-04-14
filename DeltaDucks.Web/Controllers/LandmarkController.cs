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
using Microsoft.AspNet.Identity;

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

        public ActionResult Index(int page = 1)
        {
            IEnumerable<LandmarkViewModel> landmarksViewModel;
            IEnumerable<Landmark> landmarks;
            const int recordsOnPage = 10;
            int landmarksCount = _landmarkService.LandmarksCount();
            this.ViewBag.MaxPage = (landmarksCount/recordsOnPage) + (landmarksCount%recordsOnPage > 0 ? 1 : 0);
            this.ViewBag.MinPage = 1;
            this.ViewBag.Page = page;

            landmarks = _landmarkService.GetSinglePageLendmarks(page).ToList();

            landmarksViewModel = Mapper.Map<IEnumerable<Landmark>, IEnumerable<LandmarkViewModel>>(landmarks);
            return View(landmarksViewModel);
        }

        public ActionResult Details(int number)
        {
            LandmarkViewModel landmarkViewModel;
            Landmark landmark;

            landmark = _landmarkService.GetLandmarks().FirstOrDefault(x => x.Number == number);

            landmarkViewModel = Mapper.Map<Landmark, LandmarkViewModel>(landmark);
            return View(landmarkViewModel);
        }
    }
}