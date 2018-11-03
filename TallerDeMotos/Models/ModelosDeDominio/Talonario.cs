using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TallerDeMotos.Models.AtributosDeValidacion;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Talonario
    {
        public int Id { get; set; }

        [RestriccionUnicaEnTalonario]
        public int Timbrado { get; set; }

        [Display(Name = "Fecha de Inicio de Vigencia")]
        public DateTime FechaInicioVigencia { get; set; }

        [Display(Name = "Fecha de Inicio de Vigencia")]
        [NotMapped]
        public string FechaIni { get; set; }
        
        [Display(Name = "Fecha Fin de Vigencia")]
        public DateTime FechaFinVigencia { get; set; }

        [FechaFinMayorFechaInicio]
        [Display(Name = "Fecha Fin de Vigencia")]
        [NotMapped]
        public string FechaFin { get; set; }

        [Display(Name = "Número de Factura Inicial")]
        [MayorACero]
        public int NumeroFacturaInicial { get; set; }

        [FacturaFinalMayorAFacturaInicial]
        [MayorACero]
        [Display(Name = "Número de Factura Final")]
        public int NumeroFacturaFinal { get; set; }

        [Display(Name = "Número de Factura Actual")]
        public int NumeroFacturaActual { get; set; }

        public bool EstaActivo { get; set; }

        public Caja Caja { get; set; }

        [Display(Name = "Asignar Talonario a una Caja")]
        public int CajaId { get; set; }

        public ICollection<FacturaVenta> FacturaVentas { get; set; }

        public Talonario()
        {
            FacturaVentas = new HashSet<FacturaVenta>();
        }
    }
}