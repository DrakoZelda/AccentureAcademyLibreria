using AccentureAcademy.Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureAcademy.Libreria.Controllers
{
    public class EditorialesController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        public ActionResult Mostrar(int id)
        {
            Editorial editorial = db.Editorial.Find(id);
            return PartialView("_ShowEditoriales", editorial);
        }

        public ActionResult Crear()
        {
            Editorial editorial = new Editorial();
            ViewBag.actionlink = Url.Action("Crear", "Editoriales");
            return PartialView("_FormEditoriales", editorial);
        }

        [HttpPost]
        public ActionResult Crear(Editorial editorial)
        {
            db.Editorial.Add(editorial);
            db.SaveChanges();
            return Content("La editorial se ha creado satisfactoriamente");
        }

        public ActionResult Editar(int id)
        {
            Editorial editorial = db.Editorial.Find(id);
            ViewBag.actionlink = Url.Action("Editar", "Editoriales");
            return PartialView("_FormEditoriales", editorial);
        }

        [HttpPost]
        public ActionResult Editar(Editorial editorial)
        {
            db.Editorial.Attach(editorial);
            db.Entry(editorial).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return PartialView("_ShowEditoriales", editorial);
        }

        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            Editorial editorial = db.Editorial.Find(id);
            db.Editorial.Remove(editorial);
            db.SaveChanges();
            return Content("La editorial se ha eliminado satisfactoriamente");
        }
    }
}