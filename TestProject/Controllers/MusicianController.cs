using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class MusicianController : Controller
    {
        private IMusicInstrumentService _InstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;

        public MusicianController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
        }

        public ActionResult GetOrders()
        {
            var order = _orderService.GetAll();
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var o in order)
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(o));
            return View(orderViewModels);
        }
    }
}