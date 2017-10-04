using System;

namespace TallerDeMotos.Dtos
{
    public class OrdenCompraDto
    {
        public int Id { get; set; }

        public int OrdenCompraNumero { get; set; }

        public DateTime FechaDeEmision { get; set; }

        public byte FormaPagoId { get; set; }

        public int SubTotal { get; set; }

        public byte EstadoId { get; set; }

        public byte AseguradoraId { get; set; }
    }
}