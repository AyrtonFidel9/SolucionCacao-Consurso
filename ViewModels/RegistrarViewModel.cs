using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.ViewModels
{
    public partial class RegistrarViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres, una mayúscula y un dígito.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
