using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.ViewModels;

namespace DeltaDucks.Web.Controllers
{
    public class UserRankingController : Controller
    {

        private readonly IUserService _userService;

        public UserRankingController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: UserRanking
        public ActionResult Index()
        {
            IEnumerable<ApplicationUser> users = _userService.GetUsers().OrderByDescending(u => u.Score);
            IEnumerable<UserRankingViewModel> userRankings;
            userRankings = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserRankingViewModel>>(users);
            return View(userRankings);
        }
    }
}