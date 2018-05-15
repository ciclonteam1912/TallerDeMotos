using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.AtributosDeValidacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class MovimientoCajaViewModel
    {
        public IEnumerable<FacturaVenta> FacturaVentas { get; set; }
        public IEnumerable<Banco> Bancos { get; set; }
        public IEnumerable<TipoMovimiento> TipoMovimientos { get; set; }

        #region Datos del Movimiento
        public int Id { get; set; }

        public int AperturaCierreCajaId { get; set; }

        public int? BancoId { get; set; }

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

        [Display(Name = "Vehículo")]
        public string Vehiculo { get; set; }

        [Display(Name = "Monto de la Factura")]
        public long? MontoFactura { get; set; }

        [Display(Name = "Saldo Inicial")]
        public long SaldoInicial { get; set; }

        [Required]
        [MontoTotalIgualAMontoFactura("MontoFactura")]
        [Display(Name = "Monto Total a Cobrar")]
        public long? Monto { get; set; }

        public string MensajeError { get; set; }
        public bool Resultado { get; set; }
        #endregion

        #region Forma de Pago Efectivo
        [Display(Name = "Forma de Pago en Efectivo")]
        [PorLoMenosUnCheckBox("FormaPagoTarjeta", "FormaPagoCheque")]
        public bool FormaPagoEfectivo { get; set; }

        [Display(Name = "Monto del Pago")]
        [RequiredIf("FormaPagoEfectivo", Comparison.IsEqualTo, true)]
        public long? MontoPagoEfectivo { get; set; }

        [Display(Name = "Vuelto")]
        public long? Vuelto { get; set; }
        #endregion

        #region Forma de Pago Cheque
        [Display(Name = "Forma de Pago en Cheque")]
        public bool FormaPagoCheque { get; set; }

        [Display(Name = "Monto Pago")]
        [RequiredIf("FormaPagoCheque", Comparison.IsEqualTo, true)]        
        public long? MontoPagoCheque { get; set; }

        [Display(Name = "Bancos")]
        [RequiredIf("FormaPagoCheque", Comparison.IsEqualTo, true)]
        public int? BancoIdCheque { get; set; }

        [Display(Name = "Nro. de Cheque")]
        [RequiredIf("FormaPagoCheque", Comparison.IsEqualTo, true)]
        public int? NroCheque { get; set; }

        [RequiredIf("FormaPagoCheque", Comparison.IsEqualTo, true)]
        public int? Librador { get; set; }
        #endregion

        #region Forma de Pago Tarjeta
        [Display(Name = "Forma de Pago en Tarjeta")]
        public bool FormaPagoTarjeta { get; set; }

        [Display(Name = "Monto Pago")]
        [RequiredIf("FormaPagoTarjeta", Comparison.IsEqualTo, true)]
        public long? MontoPagoTarjeta { get; set; }

        public string TipoTarjeta { get; set; }

        [Display(Name = "Bancos")]
        [RequiredIf("FormaPagoTarjeta", Comparison.IsEqualTo, true)]
        public int? BancoIdTarjeta { get; set; }


        [Display(Name = "Nro. de Autorización")]
        [RequiredIf("FormaPagoTarjeta", Comparison.IsEqualTo, true)]
        public int? NroAutorizacion { get; set; }
        #endregion        
    }
}