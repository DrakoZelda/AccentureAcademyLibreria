using AccentureAcademy.Libreria.Models;
using AccentureAcademy.Libreria.Models.Filtros;
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
            ViewBag.Autores = db.Autor.ToList();
            ViewBag.Generos = db.Genero.ToList();
            //ViewBag.Autores = db.Autor.ToList();
            //ViewBag.Generos = db.Genero.ToList();
            ViewBag.AutoresInLibro = new List<Autor>();
            ViewBag.GenerosInLibro = new List<Genero>();
            ViewBag.actionlink = Url.Action("Crear", "Libros");
            return PartialView("_FormLibros", libro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Libro libro, int[] Id_Generos, int[] Id_Autores)
        {
            if (this.ModelState.IsValid)
            {
                foreach (int id_genero in Id_Generos)
                {
                    Pertenece pertenece = new Pertenece();
                    pertenece.Id_Genero = id_genero;
                    libro.Pertenece.Add(pertenece);
                }

                foreach (int id_autor in Id_Autores)
                {
                    EscritoPor escritoPor = new EscritoPor();
                    escritoPor.Id_Autor = id_autor;
                    libro.EscritoPor.Add(escritoPor);
                }

                db.Libro.Add(libro);
                db.SaveChanges();
                return Content("Libro creado satisfactoriamente.");

            }
            return new HttpStatusCodeResult(505, "Internal server Error");
        }



        public ActionResult Editar(int id)
        {
            Libro libro = db.Libro.Find(id);

            //Editorial
            ViewBag.Id_Editorial = new SelectList(db.Editorial, "Id", "Nombre", libro.Editorial.Id);
            ViewBag.Generos = db.Genero.ToList();
            ViewBag.Autores = db.Autor.ToList();
            ViewBag.AutoresInLibro = libro.EscritoPor.Select(relacion => relacion.Autor).ToList();
            ViewBag.GenerosInLibro = new List<Genero>();
            ViewBag.actionlink = Url.Action("Editar", "Libros");

            return PartialView("_FormLibros", libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Libro libro, int[] Id_Generos, int[] Id_Autores)
        {
            if (this.ModelState.IsValid)
            {
                libro.Pertenece.Clear();
                foreach( int id_genero in Id_Generos)
                {
                    Pertenece pertenece = new Pertenece();
                    pertenece.Id_Genero = id_genero;
                    pertenece.Id_Libro = libro.Id;
                    libro.Pertenece.Add(pertenece);
                }
                libro.EscritoPor.Clear();
                foreach( int id_autor in Id_Autores)
                {
                    if(!(id_autor == -1)){
                        EscritoPor escritoPor = new EscritoPor();
                        escritoPor.Id_Autor = id_autor;
                        escritoPor.Id_Libro = libro.Id;
                        libro.EscritoPor.Add(escritoPor);
                    }
                }
                db.Libro.Attach(libro);
                db.Entry(libro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Content("Libro editado satisfactoriamente.");

            }
            return new HttpStatusCodeResult(505, "Internal server Error");
        }

        public ActionResult Mostrar(int id)
        {
            Libro libro = db.Libro.Find(id);
            return PartialView("_ShowLibro", libro);
        }

        public ActionResult Filtrar()
        {
            ViewBag.Autores = db.Autor.ToList();
            ViewBag.Generos = db.Genero.ToList();
            ViewBag.Editoriales = db.Editorial.ToList();
            return PartialView("_FiltrarLibros");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FiltrarLibro(FiltroLibro filtros)
        {
            EstrategiaFiltroLibro strategy = new EstrategiaFiltroLibro()
            {
                libros = db.Libro,
                Filtros = filtros
            };

            List<Libro> librosFiltrados = strategy.Filtrar();
            return PartialView("_ListarLibros", librosFiltrados);
        }

        public ActionResult Eliminar(int id)
        {
            Libro libro = db.Libro.Find(id);
            db.Libro.Remove(libro);
            db.SaveChanges();
            return Content("El libro se ha eliminado con exito");
        }
    }
}