using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.Models.AtributosDeValidacion;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class TalonarioViewModel
    {
        public IEnumerable<Caja> Cajas { get; set; }

        public int Id { get; set; }

        [Required]
        [Remote("TimbradoExistente", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Timbrado ya existe.")]
        public int? Timbrado { get; set; }

        [Required]
        [StringLength(10)]
        public string Ruc { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio de Vigencia")]
        public DateTime? FechaInicioVigencia { get; set; }

        [Display(Name = "Fecha  de Inicio de Vigencia")]
        public string FechaIni { get; set; }

        [Required]
        [Display(Name = "Fecha Fin de Vigencia")]
        public DateTime? FechaFinVigencia { get; set; }

        [Display(Name = "Fecha  Fin de Vigencia")]
        public string FechaFin { get; set; }

        [Required]
        [MayorACero("NumeroFacturaInicial")]
        [Display(Name = "Número de Factura Inicial")]
        public int? NumeroFacturaInicial { get; set; }

        [Required]
        [MayorACero("NumeroFacturaFinal")]
        [Display(Name = "Número de Factura Final")]
        public int? NumeroFacturaFinal { get; set; }

        [Required]
        [Display(Name = "Número de Factura Actual")]
        public int? NumeroFacturaActual { get; set; }

        public bool EstaActivo { get; set; }

        [Display(Name = "Asignar Talonario a una Caja")]
        public int CajaId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Talonario" : "Agregar Talonario";
            }
        }

        public TalonarioViewModel()
        {
            FechaIni = DateTime.Now.ToString();
            FechaFin = DateTime.Now.ToString();
        }

        public TalonarioViewModel(Talonario talonario)
        {
            Id = talonario.Id;
            Timbrado = talonario.Timbrado;
            FechaIni = talonario.FechaIni;
            FechaInicioVigencia = talonario.FechaInicioVigencia;
            FechaFin = talonario.FechaFin;
            FechaFinVigencia = talonario.FechaFinVigencia;
            NumeroFacturaInicial = talonario.NumeroFacturaInicial;
            NumeroFacturaFinal = talonario.NumeroFacturaFinal;
            NumeroFacturaActual = talonario.NumeroFacturaActual;
            EstaActivo = talonario.EstaActivo;
            CajaId = talonario.CajaId;
        }
    }
}