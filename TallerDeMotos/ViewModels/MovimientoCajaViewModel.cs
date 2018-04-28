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

        [Display(Name = "Caja")]
        public string NombreCaja { get; set; }

        [Display(Name = "Estado")]
        public string EstadoCaja { get; set; }

        [Display(Name = "Estado")]
        public string UsuarioCaja { get; set; }
        public DateTime Fecha { get; set; }
        public int NroFactura { get; set; }
        public string Cliente { get; set; }
        public string Vehiculo { get; set; }
        public bool FormaPagoEfectivo { get; set; }
        public bool FormaPagoTarjeta { get; set; }
        public bool FormaPagoCheque { get; set; }
        public bool TarjetaDebito { get; set; }
        public bool TarjetaCredito { get; set; }
        public int BancoId { get; set; }
        public int NroAutorizacion { get; set; }
        public int NroCheque { get; set; }
        public int Librador { get; set; }
        public long MontoFactura { get; set; }
        public long MontoPago { get; set; }
        public long MontoVuelto { get; set; }
        public long SaldoInicial { get; set; }
    }
}