namespace TallerDeMotos.Dtos
{
    public class ProveedorDto
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Propietario { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }    
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int CiudadId { get; set; }
    }
}