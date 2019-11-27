using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using BLL.FreelanceMusicStore.Services;
using System.Web.Mvc;
using TestProject.Models;
using AutoMapper;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using DAL.FreelanceMusicStore;
using DAL.FreelanceMusicStore.Repositories;
using System;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Controllers
{
    public class ClientController : Controller
    {
        private IMusicInstrumentService _InstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;
        private IApplicationUserService _applicationUserService;
        private IClientService _ClientService;
        private IFileStorageService _fileStorageService;

        public ClientController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper, IApplicationUserService applicationUserService, IClientService clientService, IFileStorageService fileStorageService)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _ClientService = clientService;
            _fileStorageService = fileStorageService;
        }

        [Authorize(Roles = "Client")]
        public ActionResult MakeOrder()
        {
            var instruments = _InstrumentService.GetAll();
            ICollection<MusicInstrumentViewModel> entity = new List<MusicInstrumentViewModel>();
            foreach (var instrument in instruments)
                entity.Add(_mapper.Map<MusicInstrumentDTO, MusicInstrumentViewModel>(instrument));
            return View(new OrderViewModel(entity));
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> MakeOrder(OrderViewModel order)
        {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            order.ClientId = currentUser.Id;
            OrderDTO orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            ServerRequest serverRequest = await _orderService.CreateOrder(orderDTO);
            if (!serverRequest.ErrorOccured)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = serverRequest.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Client")]
        public ActionResult GetClientOrders(OrderViewModel order)
        {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            var orderDTOs = _orderService.GetAll();
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var orderDTO in orderDTOs)
            {
                orderDTO.MusicInstrument = _InstrumentService.GetById(orderDTO.MusicInstrumentId);
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(orderDTO));
            }
            return View(orderViewModels.Where(orderViewModel => orderViewModel.ClientId == currentUser.Id));
        }

        [Authorize(Roles = "Client")]
        public async Task<ActionResult> DownloadFile(OrderViewModel order)
        {
            List<FilesForClientViewModel> files = new List<FilesForClientViewModel>();
            var result = await _fileStorageService.DownloadFile(order.Id);
            string str = await result.Content.ReadAsStringAsync();
            string[] filesPath = str.Split('/');
            int i = 0;
            foreach(var file in filesPath)
            {
                int startNamePositon = file.LastIndexOf('\\');
                int endNamePosition = file.Length;
                files.Add(new FilesForClientViewModel() { FilePath = filesPath[i], FileName = file.Substring(startNamePositon + 1, endNamePosition - startNamePositon - 1) });
            }           
            return View("AllFiles", files);
        }
    }
}