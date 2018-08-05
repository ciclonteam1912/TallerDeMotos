using System;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Dtos
{
    public class FacturaVentaDto
    {
        public int Id { get; set; }
        public int TalonarioId { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime FechaFacturaVenta { get; set; }
        public long TotalDiezPorCiento { get; set; }
        public long TotalCincoPorCiento { get; set; }
        public long TotalExenta { get; set; }

        [Display(Name = "Total a pagar")]
        public int SubTotal { get; set; }
        public string UsuarioId { get; set; }
        public byte EstadoId { get; set; }
    }
}