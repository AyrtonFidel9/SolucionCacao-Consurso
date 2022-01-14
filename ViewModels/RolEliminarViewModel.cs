using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.ViewModels
{
    public partial class RolEliminarViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Name{ get; set; }
    }
}