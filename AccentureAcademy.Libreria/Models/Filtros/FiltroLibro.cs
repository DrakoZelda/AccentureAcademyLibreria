using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccentureAcademy.Libreria.Models.Filtros
{
    public class FiltroLibro
    {
        public string Titulo { get; set; }
        public int? Id_Editorial { get; set; }
        public int[] Id_Autores { get; set; }
        public int[] Id_Generos { get; set; }

        public FiltroLibro()
        {
            Id_Autores = Array.Empty<int>();
            Id_Generos = Array.Empty<int>();

        }
    }
}