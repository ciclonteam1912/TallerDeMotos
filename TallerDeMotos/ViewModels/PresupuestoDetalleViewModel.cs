using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerDeMotos.ViewModels
{
    public class PresupuestoDetalleViewModel
    {
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public ProductoViewModel Producto { get; set; }
        public int ProductoId { get; set; }
        public byte Cantidad { get; set; }
        public int Total { get; set; }
        public int TotalLineaExenta { get; set; }
        public int TotalLineaCincoXCiento { get; set; }
        public int TotalLineaDiezXCiento { get; set; }
    }
}