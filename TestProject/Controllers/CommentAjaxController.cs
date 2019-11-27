using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.FreelanceMusicStore.Interfaces;
using TestProject.Models;
using BLL.FreelanceMusicStore.EntityDTO;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    public class CommentAjaxController : Controller
    {
        private IMapper _mapper;
        private ICommentService _commentService;
        private IApplicationUserService _applicationUserService;
        private static Guid OrderId { get; set; }

        public CommentAjaxController(IMapper mapper, ICommentService commentService, IApplicationUserService applicationUserService)
        {
            _mapper = mapper;
            _commentService = commentService;
            _applicationUserService = applicationUserService;
        }

        public ActionResult Chat(Guid id)
        {
            OrderId = id;
            var commentsDTO = _commentService.GetAll();
            List<CommentViewModel> commentsViewModel = new List<CommentViewModel>();
            foreach (var commentDTO in commentsDTO)
            {               
                commentsViewModel.Add(_mapper.Map<CommentDTO, CommentViewModel>(commentDTO));
            }
            return View(commentsViewModel.Where(comment => comment.OrderId == id).OrderBy(comment => comment.CommentTime));
        }

        [HttpPost]
        public async Task<JsonResult> Chat(CommentViewModel commentViewModel)
        {
            ServerRequest serverRequest = new ServerRequest();            
            try
            {
                commentViewModel.Id = Guid.NewGuid();
                commentViewModel.CommentTime = DateTime.Now;
                commentViewModel.UserId = Guid.Parse(User.Identity.GetUserId());
                commentViewModel.OrderId = OrderId;
                await _commentService.AddComment(_mapper.Map<CommentViewModel, CommentDTO>(commentViewModel));
                serverRequest.Message = "succesful";
                return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                serverRequest.Message = "error";
                return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
            }
        }

        public async Task<JsonResult> DeleteMessage(CommentViewModel commentViewModel)
        {
            ServerRequest serverRequest = new ServerRequest();
            try
            {                
                await _commentService.DeleteComment(commentViewModel.Id);
                serverRequest.Message = "succesful";
                return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                serverRequest.Message = "error";
                return Json(serverRequest.Message, JsonRequestBehavior.DenyGet);
            }
        }
    }
}