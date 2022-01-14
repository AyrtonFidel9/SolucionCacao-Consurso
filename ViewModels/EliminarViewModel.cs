using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.ViewModels
{
    public partial class EliminarViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Usuario { get; set; }

        public string Correo { get; set; }
        public string Numero { get; set; }
    }
}
