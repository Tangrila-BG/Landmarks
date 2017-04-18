using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            var usersRankings = _userService.GetUsers()
                .ProjectTo<UserRankingViewModel>()
                .OrderByDescending(u => u.Score)
                .ToList();

            return View(usersRankings);
        }
    }
}