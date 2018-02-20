using System;
using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Presupuesto
    {
        public int Id { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public int VehiculoId { get; set; }        

        public Estado Estado { get; set; }

        public byte EstadoId { get; set; }

        public long TotalExenta { get; set; }

        public long TotalIvaCincoPorCiento { get; set; }

        public long TotalIvaDiezPorCiento { get; set; }

        public long SubTotal { get; set; }

        public DateTime FechaDeEmision { get; set; }

        public ApplicationUser Usuario { get; set; }

        public string UsuarioId { get; set; }

        public FacturaVenta FacturaVenta { get; set; }

        public ICollection<PresupuestoDetalle> PresupuestoDetalles { get; set; }

        public Presupuesto()
        {
            PresupuestoDetalles = new HashSet<PresupuestoDetalle>();
        }
    }
}