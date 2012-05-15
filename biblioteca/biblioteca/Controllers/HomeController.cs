using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace biblioteca.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Biblioteca de contenidos colectivos";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Acerca de nosotros";

            return View();
        }
    }
}
