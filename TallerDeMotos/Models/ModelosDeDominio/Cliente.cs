using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombre del Propietario")]
        public string NombrePropietario { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaDeIngreso { get; set; }

        public Personeria Personeria { get; set; }

        [Display(Name = "Personería")]
        public byte PersoneriaId { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        [Display(Name = "Tipo de Documento")]
        public byte TipoDocumentoId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Valor del Documento")]
        public string ValorDocumento { get; set; }

        public Ciudad Ciudad { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre.ToUpper() + " " + Apellido?.ToUpper();
            }
        }

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public Cliente()
        {
            Vehiculos = new Collection<Vehiculo>();
        }
    }
}