namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }
        public OrdenCompra OrdenCompra { get; set; }
        public int OrdenCompraId { get; set; }
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public int PrecioOrden { get; set; }

        public OrdenCompraDetalle()
        {

        }

        public OrdenCompraDetalle(int id, string prod, int cant, int precio, byte iva, int total)
        {
            OrdenCompraId = id;
            Producto.Descripcion = prod;
            Cantidad = cant;
            Producto.PrecioCosto = precio;
            Producto.TipoImpuesto = iva;
            Total = total;
        }
    }
}