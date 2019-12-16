using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using Microsoft.AspNet.Identity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestProject.ExceptionFilter;
using TestProject.Models;

namespace TestProject.Controllers {
    [ExceptionFilter]
    public class ClientController : Controller {
        private static Logger _logger;
        private IMusicInstrumentService _musicInstrumentService;
        private IOrderService _orderService;
        private IMapper _mapper;
        private IApplicationUserService _applicationUserService;
        private IClientService _ClientService;
        private IFileStorageService _fileStorageService;

        public ClientController(IMusicInstrumentService instrumentService, IOrderService orderService, IMapper mapper, IApplicationUserService applicationUserService, IClientService clientService, IFileStorageService fileStorageService) {
            _logger = LogManager.GetCurrentClassLogger();
            _musicInstrumentService = instrumentService;
            _orderService = orderService;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _ClientService = clientService;
            _fileStorageService = fileStorageService;
        }

        [Authorize(Roles = "Client")]
        public ActionResult MakeOrder() {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            _logger.Info("User " + currentUser.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            var instruments = _musicInstrumentService.GetAll();
            ICollection<MusicInstrumentViewModel> entity = new List<MusicInstrumentViewModel>();
            foreach (var instrument in instruments)
                entity.Add(_mapper.Map<MusicInstrumentDTO, MusicInstrumentViewModel>(instrument));
            return View(new OrderViewModel(entity));
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> MakeOrder(OrderViewModel order) {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            order.ClientId = currentUser.Id;
            OrderDTO orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            ServerRequest serverRequest = await _orderService.CreateOrder(orderDTO);
            if (!serverRequest.ErrorOccured) {
                _logger.Info("User " + currentUser.Id + " make order ");
                return RedirectToAction("Index", "Home");
            }
            else {
                ViewBag.Error = serverRequest.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Client")]
        public ActionResult GetClientOrders(OrderViewModel order) {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            _logger.Info("User " + currentUser.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            var orderDTOs = _orderService.GetAll();
            var orderViewModels = new List<OrderViewModel>();
            foreach (var orderDTO in orderDTOs) {
                orderDTO.MusicInstrument = _musicInstrumentService.GetById(orderDTO.MusicInstrumentId);
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(orderDTO));
            }
            return View(orderViewModels.Where(orderViewModel => orderViewModel.ClientId == currentUser.Id));
        }

        [Authorize(Roles = "Client")]
        public async Task<ActionResult> DownloadFile(OrderViewModel order) {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            _logger.Info("User " + currentUser.Id + " get url " + HttpContext.Request.Url.AbsoluteUri);
            var files = new List<FilesForClientViewModel>();
            HttpResponseMessage result = await _fileStorageService.DownloadFile(order.Id);
            string str = await result.Content.ReadAsStringAsync();
            string[] filesPath = str.Split('/');
            foreach (var file in filesPath) {
                int startNamePositon = file.LastIndexOf('\\');
                int endNamePosition = file.Length;
                files.Add(new FilesForClientViewModel() { FilePath = file, FileName = file.Substring(startNamePositon + 1, endNamePosition - startNamePositon - 1) });
            }
            return View("AllFiles", files);
        }
    }
}