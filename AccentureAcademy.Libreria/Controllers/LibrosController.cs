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

        public ActionResult _FormLibros()
        {
            ViewBag.EditorialId= new SelectList(db.Editorial, "Id", "Nombre");
            return PartialView();
        }
    }
}