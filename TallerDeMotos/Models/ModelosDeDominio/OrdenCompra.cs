﻿using System;
using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class OrdenCompra
    {
        public int Id { get; set; }

        public int OrdenCompraNumero { get; set; }

        public DateTime FechaDeEmision { get; set; }

        public FormaPago FormaPago { get; set; }

        public byte FormaPagoId { get; set; }

        public int SubTotal { get; set; }

        public Estado Estado { get; set; }

        public byte EstadoId { get; set; }

        public Proveedor Proveedor { get; set; }

        public int ProveedorId { get; set; }

        public FacturaCompra FacturaCompra { get; set; }

        public ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }

        public OrdenCompra()
        {
            OrdenCompraDetalles = new HashSet<OrdenCompraDetalle>();
        }
    }
}