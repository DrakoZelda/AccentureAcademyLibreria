using AccentureAcademy.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.Libreria.Controllers
{
    public class GenerosController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mostrar(int id)
        {
            Genero genero = db.Genero.Find(id);
            return PartialView("_ShowLibros", genero);
        }

        public ActionResult Crear()
        {
            Genero genero = new Genero();
            ViewBag.actionlink = Url.Action("Crear", "Generos");
            return PartialView("_FormGeneros");
        }

        [HttpPost]
        public ActionResult Crear(Genero genero)
        {
            db.Genero.Add(genero);
            db.SaveChanges();

            return Content("El genero se ha creado satisfactoriamiente.");
        }

        public ActionResult Editar(int id)
        {
            Genero genero = db.Genero.Find(id);
            ViewBag.actionlink = Url.Action("Editar", "Generos");
            return PartialView("_FormGeneros", genero);
        }

        [HttpPost]
        public ActionResult Editar(Genero genero)
        {
            db.Genero.Attach(genero);
            db.Entry(genero).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            ViewBag.DbMessage = "El genero se ha modificado satisfactoriamente";
            return PartialView("_ShowGeneros", genero);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            Genero genero = db.Genero.Find(id);
            db.Genero.Remove(genero);
            db.SaveChanges();

            return Content("El genero se ha eliminado satisfactoriamente");
        }
    }
}