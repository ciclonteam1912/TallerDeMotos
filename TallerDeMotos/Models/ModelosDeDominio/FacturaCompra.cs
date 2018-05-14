using System;
using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FacturaCompra
    {
        public int Id { get; set; }
        public int Timbrado { get; set; }
        public int FacturaNumero { get; set; }
        public DateTime FechaFacturaCompra { get; set; }
        public OrdenCompra OrdenCompra { get; set; }
        public int OrdenCompraId { get; set; }
        public int Subtotal { get; set; }
        public ApplicationUser Usuario { get; set; }
        public string UsuarioId { get; set; }
        public DateTime FechaDeGuardado { get; set; }

        public ICollection<FacturaCompraDetalle> FacturaCompraDetalles { get; set; }

        public FacturaCompra()
        {
            FacturaCompraDetalles = new HashSet<FacturaCompraDetalle>();
        }
    }
}