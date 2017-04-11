using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeltaDucks.Web.Properties;
using Newtonsoft.Json;

namespace DeltaDucks.Web.Controllers.Api
{
    public class MapsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Landmarks()
        {
            return Json(File.ReadAllLines(Resources.LandmarksMapStyles));
        }
    }
}
