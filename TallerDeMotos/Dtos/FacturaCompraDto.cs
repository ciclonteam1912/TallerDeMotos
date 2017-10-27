using System;

namespace TallerDeMotos.Dtos
{
    public class FacturaCompraDto
    {
        public int Id { get; set; }

        public int Timbrado { get; set; }

        public int FacturaNumero { get; set; }

        public DateTime FechaFacturaCompra { get; set; }

        public OrdenCompraDto OrdenCompra { get; set; }

        public int OrdenCompraId { get; set; }

        public int Subtotal { get; set; }
    }
}