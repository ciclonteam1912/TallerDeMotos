using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [FechaFinMayorFechaInicio]
        [Display(Name = "Fecha Fin de Vigencia")]
        public DateTime FechaFinVigencia { get; set; }

        [Display(Name = "Número de Factura Inicial")]
        public int NumeroFacturaInicial { get; set; }

        [FacturaFinalMayorAFacturaInicial]
        [Display(Name = "Número de Factura Final")]
        public int NumeroFacturaFinal { get; set; }

        [FacturaActual]
        [Display(Name = "Número de Factura Actual")]
        public int NumeroFacturaActual { get; set; }

        public bool EstaActivo { get; set; }

        public Caja Caja { get; set; }

        [Display(Name = "Asignar Talonario a una Caja")]
        public int CajaId { get; set; }
        public Sucursal Sucursal { get; set; }

        [Display(Name = "Asignar Talonario a una Sucursal")]
        public int SucursalId { get; set; }

        public ICollection<FacturaVenta> FacturaVentas { get; set; }

        public Talonario()
        {
            FacturaVentas = new HashSet<FacturaVenta>();
        }
    }
}