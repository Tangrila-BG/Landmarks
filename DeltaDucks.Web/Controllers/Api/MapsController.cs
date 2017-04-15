using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper.QueryableExtensions;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.Dtos;
using DeltaDucks.Web.Properties;
using Newtonsoft.Json;

namespace DeltaDucks.Web.Controllers.Api
{
    public class MapsController : ApiController
    {
        private readonly ILandmarkService _landmarkService;

        public MapsController(ILandmarkService landmarkService)
        {
            _landmarkService = landmarkService;
        }

        [HttpGet]
        public IHttpActionResult GetMapOptions()
        {
            var path = HttpContext.Current.Server.MapPath(Resources.LandmarksMapData);

            if (path == null)
                return NotFound();

            string data = File.ReadAllText(path);
            StringBuilder sb = new StringBuilder(data);

            var landmarks = JsonConvert
                .SerializeObject(_landmarkService.GetLandmarks()
                    .AsQueryable()
                    .ProjectTo<LandmarkToMapDto>());

            sb.Insert(data.Length - 1, $",locations: {landmarks}");

            return Ok(JsonConvert.DeserializeObject(sb.ToString()));
        }

    }
}
