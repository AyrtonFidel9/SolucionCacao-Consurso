using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class Propietario
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Cédula")]
        [RegularExpression("[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "La cédula ingresada debe contener 10 dígitos")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Celular")]
        [RegularExpression("[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "El celular ingresado debe contener 10 dígitos")]
        public string Celular { get; set; }
    }
}
