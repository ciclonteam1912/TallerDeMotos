using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using TallerDeMotos.Models.AtributosDeValidacion;

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
        [RestriccionUnicaEnEmpleado]
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

        public DateTime FechaDeIngreso { get; set; }

        public Cargo Cargo { get; set; }

        [Display(Name = "Cargo")]
        public byte CargoId { get; set; }

        public Ciudad Ciudad { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [NotMapped]
        public string Fecha { get; set; }
        public string NombreCompleto
        {
            get
            {
                return Nombre.ToUpper() + " " + Apellido?.ToUpper();
            }
        }

        public ICollection<ApplicationUser> Usuarios { get; set; }

        public Empleado()
        {
            Usuarios = new HashSet<ApplicationUser>();
        }
    }
}