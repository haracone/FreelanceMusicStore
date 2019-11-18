﻿using AutoMapper;
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
        public async Task<ActionResult> TakeOrder(OrderViewModel order)
        {
            var currentUser = _applicationUserService.GetUserById(Guid.Parse(User.Identity.GetUserId()));
            order.MusicianId = currentUser.Id;
            OrderDTO orderDTO = _mapper.Map<OrderViewModel, OrderDTO>(order);
            await _orderService.UpdateOrder(orderDTO);
            return RedirectToAction("GetOrders", "Musician");
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(FileViewModel fileViewModel)
        {
            HttpClient _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));

            MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
            FileDTO fileDTO = _mapper.Map<FileViewModel, FileDTO>(fileViewModel);
            var result = await _client.PostAsync("webapi.localhost:", fileDTO, bsonFormatter);

            return View();
        }
    }
}