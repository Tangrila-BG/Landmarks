using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeltaDucks.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LandmarkController : Controller
    {
        // GET: Admin/Landmark
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}