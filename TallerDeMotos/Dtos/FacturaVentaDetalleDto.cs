namespace TallerDeMotos.Dtos
{
    public class FacturaVentaDetalleDto
    {
        public int Id { get; set; }
        public int FacturaVentaId { get; set; }
        public int ProductoId { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public int TotalLineaExenta { get; set; }
        public int TotalLineaCincoXCiento { get; set; }
        public int TotalLineaDiezXCiento { get; set; }
    }
}