using System.Collections.Generic;

namespace DeltaDucks.Web.ViewModels
{
    public class VisitedLandmarksViewModel
    {
        public int Score { get; set; }

        public List<LandmarkViewModel> VisitedLandmarks { get; set; }

    }
}