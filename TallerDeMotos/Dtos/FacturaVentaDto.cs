using System;

namespace TallerDeMotos.Dtos
{
    public class FacturaVentaDto
    {
        public int Id { get; set; }

        public PresupuestoDto Presupuesto { get; set; }

        public int PresupuestoId { get; set; }

        public int TalonarioId { get; set; }

        public DateTime FechaFacturaVenta { get; set; }

        public int SubTotal { get; set; }

        public string UsuarioId { get; set; }
    }
}