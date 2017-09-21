using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class ClienteViewModel
    {
        public IEnumerable<TipoDocumento> TiposDocumentos { get; set; }

        public IEnumerable<Personeria> Personerias { get; set; }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Propietario")]
        public string NombrePropietario { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        [Display(Name = "Personería")]
        public byte PersoneriaId { get; set; }

        [Display(Name = "Tipo de Documento")]
        public byte TipoDocumentoId { get; set; }

        [Required]
        [Display(Name = "Valor del Documento")]
        public string ValorDocumento { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Cliente" : "Nuevo Cliente";
            }
        }

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
            PersoneriaId = cliente.PersoneriaId;
            TipoDocumentoId = cliente.TipoDocumentoId;
            ValorDocumento = cliente.ValorDocumento;
        }
    }
}