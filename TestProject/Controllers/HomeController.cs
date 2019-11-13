using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.FreelanceMusicStore;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Services;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using DAL.FreelanceMusicStore.Repositories;
using DAL.FreelanceMusicStore.Identity;
using System.Threading.Tasks;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    { 
        public HomeController(IUnitOfWork unitOfWork)
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}