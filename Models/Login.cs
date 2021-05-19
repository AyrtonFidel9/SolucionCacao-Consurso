using System;
using System.Collections.Generic;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Cargo { get; set; }
        public string Contraseña { get; set; }
    }
}
