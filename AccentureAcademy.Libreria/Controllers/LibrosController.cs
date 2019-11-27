using AccentureAcademy.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.Libreria.Controllers
{
    public class LibrosController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: Libros
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            Libro libro = new Libro();
            ViewBag.Id_Editorial = new SelectList(db.Editorial, "Id", "Nombre");
            ViewBag.actionlink = Url.Action("Crear", "Libros");
            return PartialView("_FormLibros", libro);
        }

        [HttpPost]
        public ActionResult Crear(Libro libro)
        {
            db.Libro.Add(libro);
            db.SaveChanges();
            return Content("Libro creado satisfactoriamente.");
        }



        public ActionResult Editar(int id)
        {
            Libro libro = db.Libro.Find(id);

            //Editorial
            ViewBag.EditorialId = new SelectList(db.Editorial, "Id", "Nombre", libro.Editorial.Id);

            return PartialView("_FormLibros", libro);
        }

        [HttpPost]
        public ActionResult Editar(Libro libro)
        {
            db.Libro.Attach(libro);
            db.Entry(libro).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Content("Libro editado satisfactoriamente.");
        }

        public ActionResult Mostrar(int id)
        {
            Libro libro = db.Libro.Find(id);
            return PartialView("_ShowLibro", libro);
        }

        
    }
}