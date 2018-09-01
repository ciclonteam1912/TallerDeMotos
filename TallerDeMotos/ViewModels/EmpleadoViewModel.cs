using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class EmpleadoViewModel
    {
        #region Listas
        public IEnumerable<Cargo> Cargos { get; set; }
        public IEnumerable<Ciudad> Ciudades { get; set; }
        #endregion

        #region Propiedades
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50)]
        [Remote("NumeroDocumentoExisteEnEmpleados", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Número de Documento ya existe.")]
        [Display(Name = "Número de Documento")]
        public string NumeroDocumento { get; set; }

        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Display(Name = "Cargo")]
        public byte CargoId { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public string Fecha { get; set; }
        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Empleado" : "Nuevo Empleado";
            }
        }
        #endregion

        #region Constructores
        public EmpleadoViewModel()
        {

        }

        public EmpleadoViewModel(Empleado empleado)
        {
            Id = empleado.Id;
            Nombre = empleado.Nombre;
            Apellido = empleado.Apellido;
            NumeroDocumento = empleado.NumeroDocumento;
            Direccion = empleado.Direccion;
            Telefono = empleado.Telefono;
            CorreoElectronico = empleado.CorreoElectronico;
            FechaDeNacimiento = empleado.FechaDeNacimiento;
            CargoId = empleado.CargoId;
            CiudadId = empleado.CiudadId;
        }
        #endregion
    }
}