using System;
using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FacturaVenta
    {
        public int Id { get; set; }

        public Presupuesto Presupuesto { get; set; }

        public int PresupuestoId { get; set; }

        public Talonario Talonario { get; set; }

        public int TalonarioId { get; set; }

        public int NumeroFactura { get; set; }

        public DateTime FechaFacturaVenta { get; set; }

        public int SubTotal { get; set; }

        public ApplicationUser Usuario { get; set; }

        public string UsuarioId { get; set; }

        public ICollection<FacturaVentaDetalle> FacturaVentaDetalles { get; set; }

        public FacturaVenta()
        {
            FacturaVentaDetalles = new HashSet<FacturaVentaDetalle>();
        }
    }
}