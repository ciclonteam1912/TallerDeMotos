using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class FacturaVentaViewModel
    {
        public IEnumerable<Presupuesto> Presupuestos { get; set; }

        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime FechaFacturaVenta { get; set; }
        public int PresupuestoCodigo { get; set; }

        public long SubTotal { get; set; }
        public long TotalDiezPorCiento { get; set; }
        public long TotalCincoPorCiento { get; set; }
        public long TotalExenta { get; set; }

        public string UsuarioId { get; set; }
        public Talonario Talonario { get; set; }
        public int TalonarioId { get; set; }
        public Estado Estado { get; set; }
        public byte EstadoId { get; set; }
    }
}