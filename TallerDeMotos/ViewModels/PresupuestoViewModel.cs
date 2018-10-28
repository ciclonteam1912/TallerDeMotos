using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TallerDeMotos.ViewModels
{
    public class PresupuestoViewModel
    {
        public DateTime FechaDeEmision { get; set; }

        [Remote("ValidarFechaDeValidez", "RemoteValidation", HttpMethod = "POST", ErrorMessage = "La fecha de validez debe ser mayor a la fecha actual.")]
        [Display(Name = "Validez hasta")]
        public string Fecha { get; set; }

        [Display(Name = "Clientes")]
        public int ClienteId { get; set; }

        [Display(Name = "Vehículos")]
        public int VehiculoId { get; set; }
    }
}