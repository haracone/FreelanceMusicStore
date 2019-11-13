using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using BLL.FreelanceMusicStore.Services;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class ClientController : Controller
    {
        private IMusicInstrumentService _InstrumentService;
        private IOrderService _orderService;

        public ClientController(IMusicInstrumentService instrumentService, IOrderService orderService)
        {
            _InstrumentService = instrumentService;
            _orderService = orderService;
        }

        [Authorize(Roles = "Client")]
        public ActionResult MakeOrder()
        {
            return View(new OrderViewModel(_InstrumentService));
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            _orderService.CreateOrder(PropertiesConvert<OrderViewModel, OrderDTO>.AllPropertiesConvert(order));
            return RedirectToAction("Index", "Home");
        }
    }
}