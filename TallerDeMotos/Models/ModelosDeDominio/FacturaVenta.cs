using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FacturaVenta
    {
        public int Id { get; set; }        
        public int NumeroFactura { get; set; }
        public DateTime FechaFacturaVenta { get; set; }
        public Presupuesto Presupuesto { get; set; }
        [NotMapped]
        public int PresupuestoCodigo { get; set; }
        public long SubTotal { get; set; }
        public long TotalDiezPorCiento { get; set; }
        public long TotalCincoPorCiento { get; set; }
        public long TotalExenta { get; set; }
        public ApplicationUser Usuario { get; set; }
        public string UsuarioId { get; set; }
        public Talonario Talonario { get; set; }
        public int TalonarioId { get; set; }
        public Estado Estado { get; set; }
        public byte EstadoId { get; set; }
        public ICollection<FacturaVentaDetalle> FacturaVentaDetalles { get; set; }
        public ICollection<FacturaVentaCliente> FacturaVentaClientes { get; set; }
        //public ICollection<MovimientoCaja> MovimientoCajas { get; set; }

        public FacturaVenta()
        {
            FacturaVentaDetalles = new HashSet<FacturaVentaDetalle>();
            FacturaVentaClientes = new HashSet<FacturaVentaCliente>();
            //MovimientoCajas = new HashSet<MovimientoCaja>();
        }
    }
}