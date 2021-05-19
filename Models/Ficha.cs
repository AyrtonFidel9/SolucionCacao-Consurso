using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class Ficha
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Técnico responsable")]
        public int? IdTecnico { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Zona de Estudio")]
        public int? IdZona { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int? Arbol { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int? Fruto { get; set; }
        public int? Incidencia { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Severidad")]
        [RegularExpression("[0-1]", ErrorMessage = "La severidad debe ser 0 ó 1")]
        public int? Severidad { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime? Fecha { get; set; }

        public virtual Tecnico IdTecnicoNavigation { get; set; }
        public virtual ZonaEstudio IdZonaNavigation { get; set; }
    }
}
