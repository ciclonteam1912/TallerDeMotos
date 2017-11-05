namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class PresupuestoDetalle
    {
        public int Id { get; set; }

        public Presupuesto Presupuesto { get; set; }

        public int PresupuestoId { get; set; }

        public Producto Producto { get; set; }

        public int ProductoId { get; set; }

        public byte Cantidad { get; set; }

        public int Total { get; set; }
    }
}