namespace TallerDeMotos.Dtos
{
    public class FacturaCompraDetalleDto
    {
        public int Id { get; set; }

        public int FacturaCompraId { get; set; }

        public int ProductoId { get; set; }

        public int PrecioProducto { get; set; }

        public int Cantidad { get; set; }

        public int Total { get; set; }
    }
}