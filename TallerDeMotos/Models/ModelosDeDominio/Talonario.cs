using System;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Talonario
    {
        public int Id { get; set; }

        public int Timbrado { get; set; }

        [Display(Name = "Fecha de Inicio de Vigencia")]
        public DateTime FechaInicioVigencia { get; set; }

        [Display(Name = "Fecha Fin de Vigencia")]
        public DateTime FechaFinVigencia { get; set; }

        [Display(Name = "Número de Factura Inicial")]
        public int NumeroFacturaInicial { get; set; }

        [Display(Name = "Número de Factura Final")]
        public int NumeroFacturaFinal { get; set; }

        [Display(Name = "Número de Factura Actual")]
        public int NumeroFacturaActual { get; set; }

        public bool EstaActivo { get; set; }
    }
}