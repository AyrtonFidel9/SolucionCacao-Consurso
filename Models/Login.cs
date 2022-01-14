using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class Login
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Usuario { get; set; }
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Password { get; set; }
        public bool isPersistent { get; set;}
    }
}
