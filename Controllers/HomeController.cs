using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "YOU ARE AN ADMIN";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "CONGRATS!LOGGED IN";

            return View();
        }


    }
}