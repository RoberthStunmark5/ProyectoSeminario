using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tarea.Models;

namespace tarea.Controllers
{
    public class calcularController : Controller
    {
        //
        // GET: /calcular/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult sumar()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult sumar(calculo model)
        {
            int r = model.a + model.b;
            ViewBag.resultado = r;
            return View();
        }
        public ActionResult restar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult restar(calculo model)
        {
            int r = model.a - model.b;
            ViewBag.resultado1 = r;
            return View();
        }
        public ActionResult multiplicar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult multiplicar(calculo model)
        {
            int r = model.a * model.b;
            ViewBag.resultado2 = r;
            return View();
        }
        public ActionResult dividir()
        {

            return View();
        }
        [HttpPost]
        public ActionResult dividir(calculo model)
        {
            if(model.d!=0)
            {   float r = model.c / model.d;
            ViewBag.resultado3 = r;
            return View();
        }
            else
            ViewBag.resultado3="Error division entre cero";
            return View();
        }
    }
}
