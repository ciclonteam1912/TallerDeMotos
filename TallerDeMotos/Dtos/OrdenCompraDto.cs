using System;

namespace TallerDeMotos.Dtos
{
    public class OrdenCompraDto
    {
        public int Id { get; set; }

        public int OrdenCompraNumero { get; set; }

        public DateTime FechaDeEmision { get; set; }

        public FormaPagoDto FormaPago { get; set; }

        public byte FormaPagoId { get; set; }

        public int SubTotal { get; set; }

        public EstadoDto Estado { get; set; }

        public byte EstadoId { get; set; }

        public ProveedorDto Proveedor { get; set; }

        public int ProveedorId { get; set; }        
    }
}