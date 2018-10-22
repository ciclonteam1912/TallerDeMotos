using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.AtributosDeValidacion;

namespace TallerDeMotos.Dtos
{
    public class NuevaFacturaVentaDto
    {
        public FacturaVentaDto FacturaVentaDto { get; set; }        
        public List<FacturaVentaDetalleDto> FacturaVentaDetalles { get; set; }

        [RequiredIf("SinPresupuesto", Comparison.IsNotEqualTo, true)]
        [Display(Name = "Presupuestos")]
        public int? PresupuestoCodigo { get; set; }


        [RequiredIf("SinPresupuesto", Comparison.IsEqualTo, true)]
        [Display(Name = "Clientes")]
        public int? ClienteId { get; set; }

        [RequiredIf("SinPresupuesto", Comparison.IsEqualTo, true)]
        [Display(Name = "Vehículos")]
        public int? VehiculoId { get; set; }

        public string Cliente { get; set; }
        [Display(Name = "Vehículo")]
        public string Vehiculo { get; set; }
        public bool SinPresupuesto { get; set; }
    }
}