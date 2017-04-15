using System.Collections.Generic;

namespace DeltaDucks.Web.ViewModels
{
    public class NotVisitedLandmarksViewModel
    {
        public int Score { get; set; }

        public List<LandmarkViewModel> NotVisitedLandmarks { get; set; }
    }
}