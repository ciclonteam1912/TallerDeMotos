using System;

namespace TallerDeMotos.Dtos
{
    public class PresupuestoDto
    {
        public int Id { get; set; }

        public DateTime FechaDeEmision { get; set; }

        public VehiculoDto Vehiculo { get; set; }

        public int VehiculoId { get; set; }

        public int SubTotal { get; set; }

        public EstadoDto Estado { get; set; }

        public byte EstadoId { get; set; }

        public string UsuarioId { get; set; }
    }
}