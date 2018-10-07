using System.Collections.Generic;

namespace TallerDeMotos.Dtos
{
    public class NuevoProveedorDto
    {
        public ProveedorDto ProveedorDto { get; set; }
        public List<ProveedorContactoDto> ProveedorContactos { get; set; }
    }
}