using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using biblioteca.Models;
using System.Web.Security;

namespace biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Usuario()
        {
            MembershipUser UsuarioActual = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
            DataClasses1DataContext db = new DataClasses1DataContext();
            System.Guid idus = db.aspnet_Users.Where(a => a.UserName == UsuarioActual.UserName)
                                .Select(a => a.UserId).ToArray()[0];

       var infoUsuario = from mem in db.aspnet_Membership from us in db.Usuario from asp_us in db.aspnet_Users where (mem.UserId == idus && us.UserId == idus && asp_us.UserId == idus)
                              select new usuarioview
                              {   email = mem.Email, nombreus = asp_us.UserName, nombre = us.Nombre, app = us.App, apm = us.Apm,
                                  Intereses = us.Intereses, Ubicacion = us.Ubicacion
                              };
            var articulo_top = from art in db.Articulo
                            from us in db.Usuario
                            where (art.UserId == idus && us.UserId == idus)
                            select new articuloview { titulo = art.Titulo, nombre = us.Nombre, ap = us.App, desc = art.Contenido };

            var curso_top = from cur in db.Curso
                            from us in db.Usuario
                            where (cur.UserId == idus && us.UserId == idus)
                            select new cursoview { titulo = cur.Titulo, nombre = us.Nombre, ap = us.App, desc = cur.Indice };

            var tutorial_top = from tut in db.Tutorial
                               from us in db.Usuario
                               where (tut.UserId == idus && us.UserId == idus)
                               select new tutorialview { titulo = tut.Titulo, nombre = us.Nombre, ap = us.App, desc = tut.Contenido };

            var libro_top = from lib in db.Libro
                            from us in db.Usuario
                            where (lib.UserId == idus && us.UserId == idus)
                            select new libroview { titulo = lib.Titulo, nombre = us.Nombre, ap = us.App, desc = lib.Descripcion };

            var articulos = from art in db.Articulo
                            from us in db.Usuario
                            where (art.UserId == idus && us.UserId == idus)
                            select new Ultimos10view { titulo = art.Titulo, nombre = us.Nombre, ap = us.App };

            var cursos = from cur in db.Curso
                         from us in db.Usuario
                         where (cur.UserId == idus && us.UserId == idus)
                         select new Ultimos10view { titulo = cur.Titulo, nombre = us.Nombre, ap = us.App };

            var tutoriales = from tut in db.Tutorial
                             from us in db.Usuario
                             where (tut.UserId == idus && us.UserId == idus)
                             select new Ultimos10view { titulo = tut.Titulo, nombre = us.Nombre, ap = us.App };

            var libros = from lib in db.Libro
                         from us in db.Usuario
                         where (lib.UserId == idus && us.UserId == idus)
                         select new Ultimos10view { titulo = lib.Titulo, nombre = us.Nombre, ap = us.App };
            ViewBag.lista = articulo_top;
            ViewBag.lista1 = curso_top;
            ViewBag.lista2 = tutorial_top;
            ViewBag.lista3 = libro_top;
            ViewBag.articulos = articulos;
            ViewBag.cursos = cursos;
            ViewBag.tutoriales = tutoriales;
            ViewBag.libros = libros;
            ViewBag.usuario = infoUsuario;
            return View();
        }

        public ActionResult publicar_libro()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult publicar_libro(publicar_libroModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                bool informacionLibro = true;
                var Url = "";
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(file.FileName);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Archivos/Libros/Img"), fileName);
                        file.SaveAs(path);
                        Url = fileName;
                    }
                    MembershipUser UsuarioActual = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    System.Guid idus = db.aspnet_Users.Where(a => a.UserName == UsuarioActual.UserName).Select(a => a.UserId).ToArray()[0];
                    
                    Libro rel = new Libro() {   Titulo = model.Titulo, UrlPortada = Url, Autor = model.Autor,
                                                AñoPublicacion=model.AñoPublicacion, Tema = model.Tema,
                                                Descripcion=model.Descripcion, UserId=idus};
                    db.Libro.InsertOnSubmit(rel);
                    db.SubmitChanges();


                }
                catch (Exception)
                {
                    informacionLibro = false;
                }
                if (informacionLibro)
                {
                    return RedirectToAction("Usuario", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("", "Error al insertar datos ... verifique e intentelo de nuevo.");
                }
            }
            return View(model);
        }

        public ActionResult crear_articulo()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult crear_articulo(crear_articuloModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                bool informacionArticulo = true;
                var Url = "";
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(file.FileName);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Archivos/ArticulosImg"), fileName);
                        file.SaveAs(path);
                        Url = fileName;
                    }
                    MembershipUser UsuarioActual = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    System.Guid idus = db.aspnet_Users.Where(a => a.UserName == UsuarioActual.UserName).Select(a => a.UserId).ToArray()[0];
                    Articulo rel = new Articulo()
                    {
                        Titulo = model.Titulo,
                        Contenido = model.Contenido,
                        UrlImagenes = Url,
                        UserId = idus
                    };
                    db.Articulo.InsertOnSubmit(rel);
                    db.SubmitChanges();
                 }
                catch (Exception)
                {
                    informacionArticulo = false;
                }
                if (informacionArticulo)
                {
                    return RedirectToAction("Usuario", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("", "Error al insertar datos ... verifique e intentelo de nuevo.");
                }
            }
            return View(model);
        }
        public ActionResult crear_curso()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult crear_curso(crear_cursoModel model)
        {
            if (ModelState.IsValid)
            {
                bool informacionCurso = true;
                
                try
                {
                    MembershipUser UsuarioActual = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    System.Guid idus = db.aspnet_Users.Where(a => a.UserName == UsuarioActual.UserName).Select(a => a.UserId).ToArray()[0];
                    
                    Curso rel = new Curso()
                    {
                        Titulo = model.Titulo,
                        Indice = model.Indice,
                        Contenido = model.Contenido,
                        
                        UserId = idus
                    };
                    db.Curso.InsertOnSubmit(rel);
                    db.SubmitChanges();


                }
                catch (Exception)
                {
                    informacionCurso = false;
                }
                if (informacionCurso)
                {
                    return RedirectToAction("Usuario", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("", "Error al insertar datos ... verifique e intentelo de nuevo.");
                }
            }
            return View(model);
        }

        public ActionResult crear_tutorial()
        { return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult crear_tutorial(crear_tutorialModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                bool informaciontutorial = true;
                var Url = "";
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(file.FileName);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Archivos/TutorialesImg"), fileName);
                        file.SaveAs(path);
                        Url = fileName;
                    }
                    MembershipUser UsuarioActual = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    System.Guid idus = db.aspnet_Users.Where(a => a.UserName == UsuarioActual.UserName).Select(a => a.UserId).ToArray()[0];
                    
                    Tutorial rel = new Tutorial()
                    {
                        Titulo = model.Titulo,
                        Indice = model.Indice,
                        Contenido = model.Contenido,
                        
                        UrlImagenes = Url,
                        UserId = idus
                    };
                    db.Tutorial.InsertOnSubmit(rel);
                    db.SubmitChanges();


                }
                catch (Exception)
                {
                    informaciontutorial = false;
                }
                if (informaciontutorial)
                {
                    return RedirectToAction("Usuario", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("", "Error al insertar datos ... verifique e intentelo de nuevo.");
                }
            }
            return View(model);
        }
    }
}
