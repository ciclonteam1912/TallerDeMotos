using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class ProveedorViewModel
    {
        public IEnumerable<Ciudad> Ciudades { get; set; }
        public IEnumerable<Contacto> Contactos { get; set; }
        public IEnumerable<ProveedorContacto> ProveedorContactos { get; set; }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [StringLength(50)]
        public string Propietario { get; set; }

        [Required]
        [StringLength(9)]
        [RegularExpression(@"\d{6,7}[-]\d{1}", ErrorMessage = "El Ruc debe tener el siguiente formato. Ej.: 3202258-1")]
        [Remote("RucExisteEnProveedores", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Ruc ya existe.")]
        [Display(Name = "RUC")]
        public string Ruc { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Proveedor" : "Nuevo Proveedor";
            }
        }

        public ProveedorViewModel()
        {

        }

        public ProveedorViewModel(Proveedor proveedor)
        {
            Id = proveedor.Id;
            RazonSocial = proveedor.RazonSocial;
            Propietario = proveedor.Propietario;
            Ruc = proveedor.Ruc;
            Direccion = proveedor.Direccion;
            Telefono = proveedor.Telefono;
            CorreoElectronico = proveedor.CorreoElectronico;
            CiudadId = proveedor.CiudadId;
        }
    }
}