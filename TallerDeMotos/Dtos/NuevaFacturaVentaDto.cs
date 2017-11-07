using System.Collections.Generic;

namespace TallerDeMotos.Dtos
{
    public class NuevaFacturaVentaDto
    {
        public FacturaVentaDto FacturaVentaDto { get; set; }

        public List<FacturaVentaDetalleDto> FacturaVentaDetalles { get; set; }
    }
}