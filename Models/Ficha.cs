using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class Ficha
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Técnico responsable")]
        public string IdTecnico { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Zona de Estudio")]
        public string IdZona { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Nombre")]
        public string NombreFicha { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Fecha creación")]
        public DateTime? Fecha { get; set; }
        [ForeignKey("IdTecnico")]
        public virtual Tecnico IdTecnicoNavigation { get; set; }
        [ForeignKey("IdZona")]
        public virtual ZonaEstudio IdZonaNavigation { get; set; }
        [NotMapped]
        [ForeignKey("IdLineaFichas")]
        public lineaFichas idLineaFichasNavigation {get; set;}
    }
}
