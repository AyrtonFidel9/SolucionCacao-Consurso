using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolucionCacao.Models
{
    public partial class Climas
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public double? ProbPrecipitaciones { get; set; }
        public double? Humedad { get; set; }
        public double? Viento { get; set; }
        public int? Sensacion { get; set; }
        public string Descripcion { get; set; }
    }
}