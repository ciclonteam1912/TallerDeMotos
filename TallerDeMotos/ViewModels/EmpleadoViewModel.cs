using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class EmpleadoViewModel
    {
        public IEnumerable<Cargo> Cargos { get; set; }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Display(Name = "Hora de Entrada")]
        public TimeSpan? HoraDeEntrada { get; set; }

        [Display(Name = "Hora de Salida")]
        public TimeSpan? HoraDeSalida { get; set; }

        public int? Salario { get; set; }

        [Display(Name = "Cargo")]
        public byte? CargoId { get; set; }

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
            Cedula = empleado.Cedula;
            Direccion = empleado.Direccion;
            Telefono = empleado.Telefono;
            CorreoElectronico = empleado.CorreoElectronico;
            FechaDeNacimiento = empleado.FechaDeNacimiento;
            HoraDeEntrada = empleado.HoraDeEntrada;
            HoraDeSalida = empleado.HoraDeSalida;
            Salario = empleado.Salario;
            CargoId = empleado.CargoId;
        }
    }
}