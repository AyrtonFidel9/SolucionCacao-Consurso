using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class ZonaEstudio
    {
        public ZonaEstudio()
        {
            Fichas = new HashSet<Ficha>();
        }
        
        public string Id { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string IdPropietario { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Lugar { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Coordenadas { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Solo se admiten caractéres.")]
        public string Cultivo { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se admiten números.")]
        public int? Densidad { get; set; }
        //A[+-]? (180|(1[0-7] [0-9]|[0-9]{1,2})([.,][0 - 9]+)?)z
        public virtual ICollection<Ficha> Fichas { get; set; }
        
        [ForeignKey("IdPropietario")]
        public Propietario propietario {get; set;}
    
        [NotMapped]
        public IEnumerable<SelectListItem> _propietarios {get; set;}
        public string NombrePropietario {get; set;}
        
    }
}
