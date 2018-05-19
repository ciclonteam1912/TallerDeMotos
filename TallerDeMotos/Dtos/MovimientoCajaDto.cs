namespace TallerDeMotos.Dtos
{
    public class MovimientoCajaDto
    {
        public int Id { get; set; }
        public AperturaCierreDto AperturaCierreCaja { get; set; }
        public int AperturaCierreCajaId { get; set; }
        public FacturaVentaDto FacturaVenta { get; set; }
        public int FacturaVentaId { get; set; }
        public TipoMovimientoDto TipoMovimiento { get; set; }
        public byte TipoMovimientoId { get; set; }
        public long Monto { get; set; }
        public long Vuelto { get; set; }
    }
}