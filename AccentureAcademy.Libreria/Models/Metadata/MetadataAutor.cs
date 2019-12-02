using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademy.Libreria.Models.Metadata
{
    public class MetadataAutor
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud debe ser entre 2 y 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud debe ser entre 2 y 20 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }
    }
}