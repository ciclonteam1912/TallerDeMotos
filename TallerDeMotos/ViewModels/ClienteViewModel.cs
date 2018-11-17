using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class ClienteViewModel
    {
        #region Listas
        public IEnumerable<TipoDocumento> TiposDocumentos { get; set; }
        public IEnumerable<Personeria> Personerias { get; set; }
        public IEnumerable<Ciudad> Ciudades { get; set; }
        #endregion

        #region Propiedades
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
        [Display(Name = "Propietario")]
        public string NombrePropietario { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public string Fecha{ get; set; }

        [Display(Name = "Personería")]
        public byte PersoneriaId { get; set; }

        [Display(Name = "Tipo de Documento")]
        public byte TipoDocumentoId { get; set; }

        [Required]
        [RegularExpression(@"[^\s]+", ErrorMessage = "El campo Valor del Documento no es válido. No se permiten espacios.")]
        [Remote("NumeroDocumentoExisteEnClientes", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Número de Documento ya existe.")]
        [Display(Name = "Valor del Documento")]
        public string ValorDocumento { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Cliente" : "Nuevo Cliente";
            }
        }
        #endregion

        #region Constructores
        public ClienteViewModel()
        {

        }

        public ClienteViewModel(Cliente cliente)
        {
            Id = cliente.Id;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            Telefono = cliente.Telefono;
            Direccion = cliente.Direccion;
            CorreoElectronico = cliente.CorreoElectronico;
            NombrePropietario = cliente.NombrePropietario;
            FechaDeNacimiento = cliente.FechaDeNacimiento;
            Fecha = cliente.Fecha;
            PersoneriaId = cliente.PersoneriaId;
            TipoDocumentoId = cliente.TipoDocumentoId;
            ValorDocumento = cliente.ValorDocumento;
            CiudadId = cliente.CiudadId;
        }
        #endregion
    }
}