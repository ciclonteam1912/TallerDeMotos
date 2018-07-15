namespace TallerDeMotos.Dtos
{
    public class SucursalDto
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public EmpresaDto Empresa { get; set; }
        public int EmpresaId { get; set; }
        public CiudadDto Ciudad { get; set; }
        public int CiudadId { get; set; }
    }
}