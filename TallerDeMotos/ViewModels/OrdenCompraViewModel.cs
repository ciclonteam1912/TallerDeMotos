using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class OrdenCompraViewModel
    {
        public IEnumerable<FormaPago> FormaPagos { get; set; }

        public IEnumerable<Proveedor> Proveedores { get; set; }

        public int Id { get; set; }

        [Display(Name = "Orden Nro.")]
        public int OrdenCompraNumero { get; set; }

        public DateTime FechaDeEmision { get; set; }

        [Display(Name = "Forma de Pago")]
        public byte FormaPagoId { get; set; }

        [Display(Name = "Sub Totol")]
        public int SubTotal { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        public int ProveedorId { get; set; }

        [Display(Name = "Proveedor")]
        public string Fecha { get; set; }

        public DateTime FechaDeVencimiento { get; set; }

    }
}