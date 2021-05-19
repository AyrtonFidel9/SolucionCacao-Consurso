using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class ZonaEstudio
    {
        public ZonaEstudio()
        {
            Fichas = new HashSet<Ficha>();
        }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Id { get; set; }
        public int IdPropietario { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Lugar { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Coordenadas { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Cultivo { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int? Densidad { get; set; }
        //A[+-]? (180|(1[0-7] [0-9]|[0-9]{1,2})([.,][0 - 9]+)?)z
        public virtual ICollection<Ficha> Fichas { get; set; }
    }
}
