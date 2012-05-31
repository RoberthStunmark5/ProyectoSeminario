using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using biblioteca.Models;

namespace biblioteca.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {   ViewBag.Message = "";
            DataClasses1DataContext db = new DataClasses1DataContext();
            var articulo_top = from art in db.Articulo
                            from us in db.Usuario
                            where art.UserId == us.UserId 
                            select new articuloview { titulo = art.Titulo, nombre = us.Nombre, ap = us.App, desc = art.Contenido };

            var curso_top = from cur in db.Curso
                         from us in db.Usuario
                         where cur.UserId == us.UserId
                         select new cursoview { titulo = cur.Titulo, nombre = us.Nombre, ap = us.App, desc=cur.Indice };

            var tutorial_top = from tut in db.Tutorial
                             from us in db.Usuario
                             where tut.UserId == us.UserId
                             select new tutorialview { titulo = tut.Titulo, nombre = us.Nombre, ap = us.App, desc= tut.Contenido};

            var libro_top = from lib in db.Libro
                         from us in db.Usuario
                         where lib.UserId == us.UserId
                         select new libroview { titulo = lib.Titulo, nombre = us.Nombre, ap = us.App, desc = lib.Descripcion};

            var articulos = from art in db.Articulo  from us in db.Usuario where art.UserId == us.UserId
                            select new Ultimos10view  {   titulo = art.Titulo,   nombre = us.Nombre,     ap = us.App  };

            var cursos = from cur in db.Curso from us in db.Usuario where cur.UserId == us.UserId
                            select new Ultimos10view { titulo = cur.Titulo, nombre = us.Nombre, ap = us.App };

            var tutoriales = from tut in db.Tutorial from us in db.Usuario where tut.UserId == us.UserId
                            select new Ultimos10view { titulo = tut.Titulo, nombre = us.Nombre, ap = us.App };

            var libros = from lib in db.Libro from us in db.Usuario where lib.UserId == us.UserId
                            select new Ultimos10view { titulo = lib.Titulo, nombre = us.Nombre, ap = us.App };
            ViewBag.lista = articulo_top;
            ViewBag.lista1 = curso_top;
            ViewBag.lista2 = tutorial_top;
            ViewBag.lista3 = libro_top;
            ViewBag.articulos = articulos;
            ViewBag.cursos = cursos;
            ViewBag.tutoriales = tutoriales;
            ViewBag.libros = libros;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Acerca de nosotros";

            return View();
        }
        public ActionResult Captcha()
        {
            return View();
        }
        public ActionResult upload()
        {
            return this.View(); 
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase hpf)
        {
            var uploadpath = Server.MapPath("~/App_Data/UploadedFiles");

            // nos estan subiendo un archivo?


            if (hpf != null && hpf.ContentLength > 0)
            {
                var savedFileName = Path.Combine(uploadpath, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

            }

            // lista de archivos subidos
            var files = Directory.GetFiles(uploadpath);
            ViewBag.Files = files;
            return Json(true);
        }
    }
}
