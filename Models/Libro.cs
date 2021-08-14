using System;
using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es campo obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripcion es campo obligatorio")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "La fecha es campo obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El Autor es campo obligatorio")]
        public string Autor { get; set; }
        public int Precio { get; set; }
    }
}