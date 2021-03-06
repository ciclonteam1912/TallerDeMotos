﻿using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Dtos
{
    public class PresupuestoDetalleDto
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Presupuesto")]
        public int PresupuestoId { get; set; }
        public ProductoDto Producto { get; set; }

        [Display(Name = "Producto Cod.")]
        public int ProductoId { get; set; }

        public byte Cantidad { get; set; }

        public int Total { get; set; }

        public int TotalLineaExenta { get; set; }

        public int TotalLineaCincoXCiento { get; set; }

        public int TotalLineaDiezXCiento { get; set; }
    }
}