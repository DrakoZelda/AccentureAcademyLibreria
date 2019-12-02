using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademy.Libreria.Models.Metadata
{
    public class MetadataGenero
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud debe ser entre 2 y 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Una descripcion es requerida")]
        [StringLength(100, MinimumLength =20, ErrorMessage ="La longitud debe ser entre 20 y 100 caracteres")]
        public string Descripcion { get; set; }


    }
}