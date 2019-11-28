using AccentureAcademy.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.Libreria.Controllers
{
    public class AutoresController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        public ActionResult Mostrar(int id)
        {
            Autor autor = db.Autor.Find(id);
            return PartialView("_ShowAutores", autor);
        }

        public ActionResult Crear()
        {
            Autor autor = new Autor();
            ViewBag.actionlink = Url.Action("Crear", "Autores");
            return PartialView("_FormAutores", autor);
        }

        [HttpPost]
        public ActionResult Crear(Autor autor)
        {
            db.Autor.Add(autor);
            db.SaveChanges();
            return Content("El autor se ha creado satisfactoriamente.");
        }

        public ActionResult Editar(int id)
        {
            Autor autor = db.Autor.Find(id);
            ViewBag.actionlink = Url.Action("Editar", "Autores");
            return PartialView("_FormAutores", autor);
        }

        [HttpPost]
        public ActionResult Editar(Autor autor)
        {
            db.Autor.Attach(autor);
            db.Entry(autor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ViewBag.DbMessage = "El autor se ha editado satisfactoriamente.";
            return PartialView("_ShowAutores", autor);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            Autor autor = db.Autor.Find(id);
            db.Autor.Remove(autor);
            db.SaveChanges();
            return Content("El autor se ha eliminado satisfactoriamente");
        }
    }
}