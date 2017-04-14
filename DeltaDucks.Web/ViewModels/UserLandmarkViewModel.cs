using System.Collections.Generic;

namespace DeltaDucks.Web.ViewModels
{
    public class UserLandmarkViewModel
    {
        public int Score { get; set; }

        public List<LandmarkViewModel> VisitedLandmarks { get; set; }

        public List<LandmarkViewModel> NotVisitedLandmarks { get; set; }
    }
}