using System.IO;
using System.Web;
using System.Web.Http;
using DeltaDucks.Web.Properties;
using Newtonsoft.Json;

namespace DeltaDucks.Web.Controllers.Api
{
    public class MapsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMapOptions()
        {
            var path = HttpContext.Current.Server.MapPath(Resources.LandmarksMapData);
            string data = File.ReadAllText(path);

            return Ok(JsonConvert.DeserializeObject(data));
        }

    }
}
