using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class Tecnico
    {
        public Tecnico()
        {
            Fichas = new HashSet<Ficha>();
        }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Id { get; set; }
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Contacto")]
        [RegularExpression("[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "El teléfono ingresado debe contener 10 dígitos")]
        public string Contacto { get; set; }

        public virtual ICollection<Ficha> Fichas { get; set; }
    }
}
