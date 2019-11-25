﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class AdminController : Controller
    {
        IRoleService _roleService;
        IOrderService _orderService;
        IMusicInstrumentService _InstrumentService;
        IMapper _mapper;

        public AdminController(IRoleService roleService, IOrderService orderService, IMapper mapper, IMusicInstrumentService InstrumentService)
        {
            _roleService = roleService;
            _orderService = orderService;
            _InstrumentService = InstrumentService;
            _mapper = mapper;
        }


        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async  Task<ActionResult> CreateRole(CustomRoleViewModel customRoleViewModel)
        {
            customRoleViewModel.Id = Guid.NewGuid();
            var customRoleDTO = _mapper.Map<CustomRoleViewModel, CustomRoleDTO>(customRoleViewModel);
            await _roleService.CreateRoleAsync(customRoleDTO);
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetAllOrders()
        {
            var orderDTOs = _orderService.GetAll();
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var orderDTO in orderDTOs)
            {
                orderDTO.MusicInstrument = _InstrumentService.GetById(orderDTO.MusicInstrumentId);
                orderViewModels.Add(_mapper.Map<OrderDTO, OrderViewModel>(orderDTO));
            }
            return View(orderViewModels);
        }
    }
}