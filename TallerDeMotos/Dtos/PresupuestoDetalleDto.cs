namespace TallerDeMotos.Dtos
{
    public class PresupuestoDetalleDto
    {
        public int Id { get; set; }

        public int PresupuestoId { get; set; }

        public int ProductoId { get; set; }

        public byte Cantidad { get; set; }

        public int Total { get; set; }
    }
}