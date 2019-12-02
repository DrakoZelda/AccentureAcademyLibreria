using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademy.Libreria.Models.Metadata
{
    public class MetadataEditorial
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud debe ser entre 2 y 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El cuil es requerido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El cuil debe posee 11 numeros")]
        public string Cuil { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }
    }
}