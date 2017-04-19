using System.Collections.Generic;
using DeltaDucks.Models;

namespace DeltaDucks.Web.ViewModels
{
    public class UserRankingViewModel
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Score { get; set; }

        public int VistedLandmarks { get; set; }
    }
}