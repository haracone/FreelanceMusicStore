using DAL.FreelanceMusicStore.Identity;
using DAL.FreelanceMusicStore.Interfaces;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Web.Mvc;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unit;
        public HomeController(IUnitOfWork unitOf)
        {
            unit = unitOf;
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