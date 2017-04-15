using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeltaDucks.Web.Dtos
{
    public class LocationToMapDto
    {
        // Casing needed for javascript object property
        public double lat { get; set; }
        public double lng { get; set; }
    }
}