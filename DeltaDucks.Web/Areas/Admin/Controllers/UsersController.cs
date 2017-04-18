using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.Areas.Admin.ViewModels;
using DeltaDucks.Web.ViewModels;

namespace DeltaDucks.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin")]
    [RouteArea("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: Admin/User
        public ActionResult Index(int page = 1)
        {
            
            const int recordsperPage = 20;
            int usersCount = _userService.GetUsers()
                .Select(u => u.Id)
                .Count();
            this.ViewBag.MaxPage = (usersCount / recordsperPage) + (usersCount % recordsperPage > 0 ? 1 : 0);
            this.ViewBag.MinPage = 1;
            this.ViewBag.Page = page;

            var users = _userService.GetSinglePageUsers(page,recordsperPage)
                .ProjectTo<UsersViewModel>()
                .ToList();

            return View(users);
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = _userService.GetUserById(Id);
            UsersViewModel mappedUser = Mapper.Map<ApplicationUser, UsersViewModel>(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(mappedUser);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser user = _userService.GetUserById(id);
            _userService.DeleteUser(user);
            _userService.SaveUser();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = _userService.GetUserById(Id);
            UsersViewModel mappedUser = Mapper.Map<ApplicationUser, UsersViewModel>(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(mappedUser);
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult Edit(UsersViewModel user)
        {
            ApplicationUser editedUser = _userService.GetUserById(user.Id);
            if (ModelState.IsValid)
            {
                editedUser.FirstName = user.FirstName;
                editedUser.LastName = user.LastName;
                editedUser.UserName = user.UserName;
                editedUser.Email = user.Email;
                _userService.UpdateUser(editedUser);
                _userService.SaveUser();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}