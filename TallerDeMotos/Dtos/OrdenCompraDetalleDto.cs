namespace TallerDeMotos.Dtos
{
    public class OrdenCompraDetalleDto
    {
        public int Id { get; set; }

        public int OrdenCompraId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public int Total { get; set; }
    }
}