using System;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

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

        [Display(Name = "Hora de Entrada")]
        public TimeSpan? HoraDeEntrada { get; set; }

        [Display(Name = "Hora de Salida")]
        public TimeSpan? HoraDeSalida { get; set; }

        public int Salario { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public Cargo Cargo { get; set; }

        [Display(Name = "Cargo")]
        public byte CargoId { get; set; }
    }
}