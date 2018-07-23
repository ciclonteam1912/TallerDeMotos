using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Dtos
{
    public class NuevaFacturaVentaDto
    {
        public FacturaVentaDto FacturaVentaDto { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public List<FacturaVentaDetalleDto> FacturaVentaDetalles { get; set; }
    }
}