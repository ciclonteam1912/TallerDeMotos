using System;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.ViewModels
{
    public class PresupuestoViewModel
    {
        public DateTime FechaDeEmision { get; set; }

        [Display(Name = "Clientes")]
        public int ClienteId { get; set; }

        [Display(Name = "Vehículos")]
        public int VehiculoId { get; set; }
    }
}