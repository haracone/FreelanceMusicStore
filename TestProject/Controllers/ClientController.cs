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

namespace TestProject.Controllers
{
    public class ClientController : Controller
    {
        private IMusicInstrumentService _InstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;
        private IUnitOfWork _UnitOfWork;

        public ClientController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Client")]
        public ActionResult MakeOrder()
        {
            return View(new OrderViewModel(_InstrumentService, _mapper));
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            OrderDTO orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            _orderService.CreateOrder(orderDTO);
            return RedirectToAction("Index", "Home");
        }
    }
}