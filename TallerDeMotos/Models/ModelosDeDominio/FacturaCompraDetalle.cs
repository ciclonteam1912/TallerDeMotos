﻿namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FacturaCompraDetalle
    {
        public int Id { get; set; }

        public FacturaCompra FacturaCompra { get; set; }

        public int FacturaCompraId { get; set; }

        public Producto Producto { get; set; }

        public int ProductoId { get; set; }

        public int PrecioProducto { get; set; }

        public int Cantidad { get; set; }

        public int Total { get; set; }
    }
}