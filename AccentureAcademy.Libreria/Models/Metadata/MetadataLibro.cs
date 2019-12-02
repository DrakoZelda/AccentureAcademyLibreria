using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccentureAcademy.Libreria.Models.Metadata
{
    public class MetadataLibro
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud debe ser entre 2 y 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de publicacion es requerida")]
        public DateTime AnioPublicacion { get; set; }

        [Required(ErrorMessage ="El numero de paginas es requerido")]
        [Range(1, 5000, ErrorMessage = "El numero de paginas debe ser entre 1 y 5000")]
        public int NroPaginas { get; set; }
        
        [Required(ErrorMessage ="El ISBN es requerido.")]
        [StringLength(22, MinimumLength = 22, ErrorMessage = "El ISBN debe poseer 22 caracteres")]
        public string ISBN { get; set; }

        [Required(ErrorMessage ="El editorial es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un editorial valido")]
        public int Id_Editorial { get; set; }
    }
}