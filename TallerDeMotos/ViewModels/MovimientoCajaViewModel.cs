using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class MovimientoCajaViewModel
    {
        public IEnumerable<FacturaVenta> FacturaVentas { get; set; }
        public IEnumerable<Banco> Bancos { get; set; }
        public IEnumerable<TipoMovimiento> TipoMovimientos { get; set; }

        [Display(Name = "Caja")]
        public string NombreCaja { get; set; }

        [Display(Name = "Estado")]
        public string EstadoCaja { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioCaja { get; set; }
        public DateTime Fecha { get; set; }

        [Display(Name = "Facturas Pendientes")]
        public int FacturaVentaId { get; set; }

        [Display(Name = "Tipo de Movimiento")]
        public byte TipoMovimientoId { get; set; }
        public string Cliente { get; set; }
        public string Vehiculo { get; set; }
        public bool FormaPagoEfectivo { get; set; }
        public bool FormaPagoTarjeta { get; set; }
        public bool FormaPagoCheque { get; set; }
        public bool TarjetaDebito { get; set; }
        public bool TarjetaCredito { get; set; }

        [Display(Name = "Bancos")]
        public int BancoId { get; set; }

        [Display(Name = "Nro. de Autorización")]
        public int NroAutorizacion { get; set; }

        [Display(Name = "Nro. de Cheque")]
        public int NroCheque { get; set; }
        public int Librador { get; set; }

        [Display(Name = "Monto de la Factura")]
        public long MontoFactura { get; set; }

        [Display(Name = "Monto del Pago")]
        public long MontoPago { get; set; }

        [Display(Name = "Vuelto")]
        public long MontoVuelto { get; set; }
        public long SaldoInicial { get; set; }
    }
}