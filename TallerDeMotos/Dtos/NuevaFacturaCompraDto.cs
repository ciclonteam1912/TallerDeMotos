using System.Collections.Generic;

namespace TallerDeMotos.Dtos
{
    public class NuevaFacturaCompraDto
    {
        public FacturaCompraDto FacturaCompraDto { get; set; }

        public List<FacturaCompraDetalleDto> FacturaCompraDetalles { get; set; }
    }
}