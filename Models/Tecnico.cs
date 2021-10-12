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

        public string Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]

        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [EmailAddress(ErrorMessage = "El correo ingresado no es válido, siga el ejemplo: abc@mail.co")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El correo ingresado no es válido, siga el ejemplo: abc@mail.co")]
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
