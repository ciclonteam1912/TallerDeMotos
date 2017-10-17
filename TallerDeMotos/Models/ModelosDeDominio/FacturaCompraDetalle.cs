namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FacturaCompraDetalle
    {
        public int Id { get; set; }

        public FacturaCompra FacturaCompra { get; set; }

        public int FacturaCompraId { get; set; }
    }
}