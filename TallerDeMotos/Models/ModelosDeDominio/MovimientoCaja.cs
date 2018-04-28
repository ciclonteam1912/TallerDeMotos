using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class MovimientoCaja
    {
        public int Id { get; set; }
        public AperturaCierreCaja AperturaCierreCaja { get; set; }
        public int AperturaCierreCajaId { get; set; }
        public FacturaCompra FacturaCompra { get; set; }
        public int FacturaCompraId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public byte TipoMovimientoId { get; set; }
        public long Monto { get; set; }
        public long Vuelto { get; set; }
        public ICollection<MovimientoCajaFormaPago> MovimientosFormaPagos { get; set; }

        public MovimientoCaja()
        {
            MovimientosFormaPagos = new HashSet<MovimientoCajaFormaPago>();
        }
    }
}