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
        private IUnitOfWork _UnitOfWork;
        private IApplicationUserService _applicationUserService;
        private IClientService _ClientService;

        public ClientController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper, IUnitOfWork unitOfWork, IApplicationUserService applicationUserService, IClientService clientService)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
            _applicationUserService = applicationUserService;
            _ClientService = clientService;
        }

        [Authorize(Roles = "Client")]
        public ActionResult MakeOrder()
        {

            return View(new OrderViewModel(_InstrumentService, _mapper));
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> MakeOrder(OrderViewModel order)
        {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            order.ClientId = currentUser.Id;
            OrderDTO orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            await _orderService.CreateOrder(orderDTO);
            return RedirectToAction("Index", "Home");
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

        public async Task<ActionResult> DownloadFile(OrderViewModel order)
        {
            FileViewModel fileViewModel = new FileViewModel();
            fileViewModel.OrderId = order.Id;
            fileViewModel.PostedFile = order.PostedFile;
            FileDTO fileDTO = _mapper.Map<FileViewModel, FileDTO>(fileViewModel);
/*            var result = await _fileStorageService.UploadFileAsync(fileDTO);*/
            return RedirectToAction("GetTakenOrders", "Musician");
        }
    }
}