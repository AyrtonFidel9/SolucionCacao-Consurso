using System;
using System.Collections.Generic;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class Login
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Cargo { get; set; }
        public string Password { get; set; }
    }
}
