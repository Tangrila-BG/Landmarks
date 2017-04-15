using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeltaDucks.Models;

namespace DeltaDucks.Web.Dtos
{
    public class LandmarkToMapDto
    {
        // Casing needed for javascript object property
        public string title { get; set; }
        public LocationToMapDto position { get; set; }
    }
}