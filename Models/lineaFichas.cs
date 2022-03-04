using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolucionCacao.Models
{
    public partial class lineaFichas
    {
        public lineaFichas()
        {
             Fichas = new HashSet<Ficha>();
        }
        [Key]
        public string Id {get; set;}

        [ForeignKey("idFicha")]
        public string IdFicha {get; set;}
        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se admiten números.")]
        public int? Arbol { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se admiten números.")]
        public int? Fruto { get; set; }
        
        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se admiten números.")]
        public int? Incidencia { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Severidad")]
        [RegularExpression("[0-1]", ErrorMessage = "La severidad debe ser 0 ó 1")]
        public int? Severidad { get; set; }
         [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Fecha")]
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Ficha> Fichas { get; set; }
    }
}