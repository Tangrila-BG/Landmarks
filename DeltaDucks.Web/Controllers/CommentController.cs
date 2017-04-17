using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;
using DeltaDucks.Web.ViewModels;
using Microsoft.AspNet.Identity;

namespace DeltaDucks.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            this._userService = userService;
            this._commentService = commentService;
        }

        public ActionResult Create(int id, byte number)
        {
            CommentViewModel comment = new CommentViewModel()
            {
                LandmarkId = id,
                LandmarkNumber = number
            };
            return View(comment);
        }

        [HttpPost]
        public ActionResult Create(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                Comment dbComment = new Comment();
                dbComment.LandmarkId = comment.LandmarkId;
                dbComment.Text = comment.Text;
                dbComment.DateCreated = DateTime.Now;
                dbComment.AuthorId = User.Identity.GetUserId();
                _commentService.Add(dbComment);
                _commentService.Save();
                return RedirectToAction("Details", "Landmark", new { number = comment.LandmarkNumber });
            }
            return View(comment);
        }

        [HttpGet]
        public ActionResult Edit(int id,int landmarkId, byte number)
        {
            Comment comment = _commentService.GetCommentById(id);
            CommentViewModel mappedComment = Mapper.Map<Comment, CommentViewModel>(comment);
            if (comment.AuthorId != User.Identity.GetUserId())
            {
                return RedirectToAction("Login", "Account");
            }
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(mappedComment);
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult Edit(CommentViewModel commentViewModel)
        {
            Comment comment = Mapper.Map<CommentViewModel, Comment>(commentViewModel);
            if (comment.AuthorId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                comment.DateCreated = DateTime.Now;
                _commentService.Update(comment);
                _commentService.Save();
                return RedirectToAction("Details", "Landmark", new { number = commentViewModel.LandmarkNumber });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int commentId,byte number)
        {
            Comment comment = _commentService.GetCommentById(commentId);
            if (comment == null)
            {
                return HttpNotFound();
            }
            if (comment.AuthorId != User.Identity.GetUserId())
            {
                return RedirectToAction("Login", "Account");
            }
            _commentService.Delete(comment);
            _commentService.Save();
            return RedirectToAction("Details", "Landmark", new { number = number});
        }
    }
}