using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Web.ViewModels
{
    public class LandmarkViewModel
    {
        public int LandmarkId { get; set; }

        public byte Number { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Information { get; set; }

        public int Visits { get; set; }

        public int Points { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public List<Comment> Comments { get; set; }
    }
}