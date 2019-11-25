using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;
using Microsoft.AspNet.Identity;
using Domain.FreelanceMusicStore.Identity;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;

namespace TestProject.Controllers
{
    public class MusicianController : Controller
    {
        private IMusicInstrumentService _InstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;
        private IApplicationUserService _applicationUserService;
        private IFileStorageService _fileStorageService;
        private IMusicianService _musicianService;
        public MusicianController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper, IApplicationUserService applicationUserService, IFileStorageService fileStorageService, IMusicianService musicianService)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _fileStorageService = fileStorageService;
            _musicianService = musicianService;
        }

        [Authorize(Roles = "Musician")]
        public ActionResult GetOrders()
        {
            var orderDTOs = _orderService.GetAll();
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var orderDTO in orderDTOs)
            {
                orderDTO.MusicInstrument = _InstrumentService.GetById(orderDTO.MusicInstrumentId);
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(orderDTO));               
            }
            return View(orderViewModels.Where(orderViewModel => orderViewModel.MusicianId == null));
        }

        [Authorize(Roles = "Musician")]
        public ActionResult GetTakenOrders()
        {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            var orderDTOs = _orderService.GetAll();
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var orderDTO in orderDTOs)
            {
                orderDTO.MusicInstrument = _InstrumentService.GetById(orderDTO.MusicInstrumentId);
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(orderDTO));
            }
            return View(orderViewModels.Where(orderViewModel => orderViewModel.MusicianId == currentUser.Id));
        }

        [HttpPost]
        public async Task<ActionResult> TakeOrder(OrderViewModel order)
        {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            order.MusicianId = currentUser.Id;
            OrderDTO orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            await _orderService.UpdateOrder(orderDTO);
            return RedirectToAction("GetOrders", "Musician");
        }

        [HttpPost]
        [Authorize(Roles = "Musician")]
        public async Task<ActionResult> UploadFile(OrderViewModel order)
        {
            FileViewModel fileViewModel = new FileViewModel();
            fileViewModel.OrderId = order.Id;
            fileViewModel.PostedFile = order.PostedFile;           
            FileDTO fileDTO = _mapper.Map<FileViewModel, FileDTO>(fileViewModel);
            ServerRequest result = await _fileStorageService.UploadFileAsync(fileDTO);
            if (!result.ErrorOccured)
            {
                return RedirectToAction("GetTakenOrders", "Musician");
            }
            else
            {
                ViewBag.Error = result.Message;
                return RedirectToAction("GetTakenOrders", "Musician");
            }
        }
    }
}