using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccentureAcademy.Libreria.Models.Filtros
{
    public class EstrategiaFiltroLibro
    {
        public IQueryable<Libro> libros { get; set; }
        public FiltroLibro Filtros{ get; set; }

        public EstrategiaFiltroLibro()
        {
            Filtros = new FiltroLibro();
        }

        private void FiltrarNombre()
        {
            if(!(Filtros.Titulo == null || Filtros.Titulo == ""))
            {
                libros = libros.Where(libro => libro.Nombre.Contains(Filtros.Titulo));
            }
        }

        private void FiltrarEditorial()
        {
            if (Filtros.Id_Editorial.HasValue && Filtros.Id_Editorial >= 0)
            {
                libros = libros.Where(libro => libro.Id_Editorial == Filtros.Id_Editorial);
            }
        }

        private void FiltrarAutores()
        {
            if(Filtros.Id_Autores.Length <= 0)
            {
                foreach (int id_autor in Filtros.Id_Autores)
                {
                    libros = libros.Where(libro => libro.EscritoPor.Any(relacion => relacion.Id_Autor == id_autor));
                }
            }
        }

        private void FiltrarGeneros()
        {
            if(Filtros.Id_Generos.Length > 0)
            {
                foreach (int id_genero in Filtros.Id_Generos)
                {
                    libros = libros.Where(libro => libro.Pertenece.Any(relacion => relacion.Id_Genero == id_genero));
                }
            }
        }

        public List<Libro> Filtrar()
        {
            FiltrarNombre();
            FiltrarEditorial();
            FiltrarGeneros();
            FiltrarAutores();

            return libros.ToList();
        }
    }
}