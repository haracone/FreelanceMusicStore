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

namespace TestProject.Controllers
{
    public class MusicianController : Controller
    {
        private IMusicInstrumentService _InstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;
        private IApplicationUserService _applicationUserService;
        public MusicianController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper, IApplicationUserService applicationUserService)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
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

        [HttpPost]
        public ActionResult TakeOrder(OrderViewModel order)
        {

/*            var currentUserId = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            _applicationUserService.*/
/*            _orderService.UpdateOrder(_mapper.Map<OrderViewModel, OrderDTO>(order));*/
            return View("Musician/GetOrders");
        }
    }
}