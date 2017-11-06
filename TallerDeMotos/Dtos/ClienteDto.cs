using System;

namespace TallerDeMotos.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string CorreoElectronico { get; set; }

        public string NombrePropietario { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public byte PersoneriaId { get; set; }

        public byte TipoDocumentoId { get; set; }

        public string ValorDocumento { get; set; }

        public int CiudadId { get; set; }
    }
}