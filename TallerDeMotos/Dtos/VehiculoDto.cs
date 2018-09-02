using System;

namespace TallerDeMotos.Dtos
{
    public class VehiculoDto
    {
        public int Id { get; set; }    
        public string Matricula { get; set; }
        public string Chasis { get; set; }
        public float? Kilometro { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public string Color { get; set; }
        public byte ModeloId { get; set; }
        public ClienteDto Cliente { get; set; }
        public int ClienteId { get; set; }
        public byte CombustibleId { get; set; }
        public byte AseguradoraId { get; set; }
    }
}