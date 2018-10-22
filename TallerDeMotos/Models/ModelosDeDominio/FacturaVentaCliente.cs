namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FacturaVentaCliente
    {
        public int Id { get; set; }
        public FacturaVenta FacturaVenta { get; set; }
        public int FacturaVentaId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int VehiculoId { get; set; }
    }
}