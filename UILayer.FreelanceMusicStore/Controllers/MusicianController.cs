using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using Microsoft.AspNet.Identity;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestProject.ExceptionFilter;
using TestProject.Models;

namespace TestProject.Controllers {
    [ExceptionFilter]
    public class MusicianController : Controller {
        private static Logger s_logger;
        private IMusicInstrumentService _musicInstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;
        private IApplicationUserService _applicationUserService;
        private IFileStorageService _fileStorageService;
        private IMusicianService _musicianService;
        public MusicianController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper, IApplicationUserService applicationUserService, IFileStorageService fileStorageService, IMusicianService musicianService) {
            s_logger = LogManager.GetCurrentClassLogger();
            _musicInstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _fileStorageService = fileStorageService;
            _musicianService = musicianService;
        }

        [Authorize(Roles = "Musician")]
        public ActionResult GetOrders() {
            MusicianDTO musician = _musicianService.GetMusicianById(Guid.Parse(User.Identity.GetUserId()));
            s_logger.Info("User " + musician.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            List<OrderDTO> orderDTOs = _orderService.GetAll();
            var orderViewModels = new List<OrderViewModel>();
            foreach (var orderDTO in orderDTOs) {
                orderDTO.MusicInstrument = _musicInstrumentService.GetById(orderDTO.MusicInstrumentId);
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(orderDTO));
            }
            List<MusicInstrumentViewModel> musicInstrumentViewModels = new List<MusicInstrumentViewModel>();
            return View(orderViewModels.Where(orderViewModel => orderViewModel.MusicianId == null));
        }

        [Authorize(Roles = "Musician")]
        public ActionResult GetTakenOrders() {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            s_logger.Info("User " + currentUser.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            List<OrderDTO> orderDTOs = _orderService.GetAll();
            var orderViewModels = new List<OrderViewModel>();
            foreach (var orderDTO in orderDTOs) {
                orderDTO.MusicInstrument = _musicInstrumentService.GetById(orderDTO.MusicInstrumentId);
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(orderDTO));
            }
            return View(orderViewModels.Where(orderViewModel => orderViewModel.MusicianId == currentUser.Id));
        }

        [HttpPost]
        public async Task<ActionResult> TakeOrder(OrderViewModel order) {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            s_logger.Info("User " + currentUser.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            order.MusicianId = currentUser.Id;
            OrderDTO orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            await _orderService.UpdateOrder(orderDTO);
            s_logger.Info("Order " + order.Id + " taken by user " + currentUser.Id);
            return RedirectToAction("GetOrders", "Musician");
        }

        [HttpPost]
        [Authorize(Roles = "Musician")]
        public async Task<ActionResult> UploadFile(OrderViewModel order) {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            FileViewModel fileViewModel = new FileViewModel();
            HttpPostedFileBase file = Request.Files[0];
            fileViewModel.OrderId = order.Id;
            fileViewModel.FileName = Path.GetFileName(file.FileName);
            fileViewModel.FileType = file.ContentType;
            using (var binaryReader = new BinaryReader(file.InputStream)) {
                fileViewModel.Data = binaryReader.ReadBytes(file.ContentLength);
            }
            FileDTO.FileDTO fileDTO = _mapper.Map<FileViewModel, FileDTO.FileDTO>(fileViewModel);
            ServerRequest result = await _fileStorageService.UploadFileAsync(fileDTO);
            if (!result.ErrorOccured) {
                s_logger.Info("User " + currentUser.Id + " upload file ");
                return RedirectToAction("GetTakenOrders", "Musician");
            }
            else {
                s_logger.Error("Error when user " + currentUser.Id + " try to upload file ");
                ViewBag.Error = result.Message;
                return RedirectToAction("GetTakenOrders", "Musician");
            }
        }
    }
}