using System.Collections.Generic;

namespace TallerDeMotos.Dtos
{
    public class NuevaOrdenCompraDto
    {
        public OrdenCompraDto OrdenCompra { get; set; }

        public List<OrdenCompraDetalleDto> OrdenCompraDetalles { get; set; }
    }
}