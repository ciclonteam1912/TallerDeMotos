using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class EmpleadoViewModel
    {
        public IEnumerable<Cargo> Cargos { get; set; }

        public IEnumerable<Ciudad> Ciudades { get; set; }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Número de Documento")]
        public string NumeroDocumento { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Display(Name = "Cargo")]
        public byte? CargoId { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Empleado" : "Nuevo Empleado";
            }
        }

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
    }
}