﻿using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using Microsoft.AspNet.Identity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestProject.ExceptionFilter;
using TestProject.Models;

namespace TestProject.Controllers {
    [ExceptionFilter]
    public class CommentAjaxController : Controller {
        private static Logger s_logger;
        private IMapper _mapper;
        private ICommentService _commentService;
        private IApplicationUserService _applicationUserService;
        private static Guid OrderId { get; set; }

        public CommentAjaxController(IMapper mapper, ICommentService commentService, IApplicationUserService applicationUserService) {
            _mapper = mapper;
            _commentService = commentService;
            _applicationUserService = applicationUserService;
            s_logger = LogManager.GetCurrentClassLogger();
        }

        public ActionResult Chat(Guid id) {
            OrderId = id;
            List<CommentDTO> commentsDTO = _commentService.GetAll();
            var commentsViewModel = new List<CommentViewModel>();
            foreach (var commentDTO in commentsDTO) {
                commentsViewModel.Add(_mapper.Map<CommentDTO, CommentViewModel>(commentDTO));
            }
            return View(commentsViewModel.Where(comment => comment.OrderId == id).OrderBy(comment => comment.CommentTime));
        }

        [HttpPost]
        public async Task<JsonResult> Chat(CommentViewModel commentViewModel) {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            s_logger.Info("User " + currentUser.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            ServerRequest serverRequest = new ServerRequest();
            try {
                commentViewModel.Id = Guid.NewGuid();
                commentViewModel.CommentTime = DateTime.Now;
                commentViewModel.UserId = Guid.Parse(User.Identity.GetUserId());
                commentViewModel.OrderId = OrderId;
                await _commentService.AddComment(_mapper.Map<CommentViewModel, CommentDTO>(commentViewModel));
                serverRequest.Message = "succesful";
                return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
            }
            catch {
                s_logger.Error("Error when user " + currentUser.Id + " try to send message");
                serverRequest.Message = "error";
                return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
            }
        }

        public async Task<JsonResult> DeleteMessage(CommentViewModel commentViewModel) {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            s_logger.Info("User " + currentUser.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            CommentDTO commentDTO = _commentService.GetById(commentViewModel.Id);
            commentViewModel.CommentTime = commentDTO.CommentTime;
            ServerRequest serverRequest = new ServerRequest();
            try {
                if (DateTime.Now < commentViewModel.CommentTime.AddMinutes(10)) {
                    await _commentService.DeleteComment(commentViewModel.Id);
                    serverRequest.Message = "succesful";
                    return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
                }
                else {
                    serverRequest.ErrorOccured = true;
                    serverRequest.Message = "You cannot delete you comment so... late";
                    return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
                }
            }
            catch {
                s_logger.Error("Error when user " + currentUser.Id + " try to delete message");
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "error";
                return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
            }
        }
    }
}