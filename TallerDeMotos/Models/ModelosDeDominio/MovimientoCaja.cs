﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class MovimientoCaja
    {
        public int Id { get; set; }
        public AperturaCierreCaja AperturaCierreCaja { get; set; }
        public int AperturaCierreCajaId { get; set; }
        public FacturaVenta FacturaVenta { get; set; }
        public int FacturaVentaId { get; set; }
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