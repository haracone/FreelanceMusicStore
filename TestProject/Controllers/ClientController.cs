using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using BLL.FreelanceMusicStore.Services;
using System.Web.Mvc;
using TestProject.Models;
using AutoMapper;

namespace TestProject.Controllers
{
    public class ClientController : Controller
    {
        private IMusicInstrumentService _InstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;

        public ClientController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
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
            _orderService.CreateOrder(_mapper.Map<OrderViewModel, OrderDTO>(order));           
            return RedirectToAction("Index", "Home");
        }
    }
}