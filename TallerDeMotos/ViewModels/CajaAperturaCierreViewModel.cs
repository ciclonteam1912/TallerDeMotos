using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class CajaAperturaCierreViewModel
    {
        public IEnumerable<Caja> Cajas { get; set; }
        public IEnumerable<ApplicationUser> Usuarios { get; set; }

        public int Id { get; set; }

        [Display(Name = "Caja")]
        public int CajaId { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Saldo Inicial")]
        public long? SaldoInicial { get; set; }

        [Display(Name = "Saldo Final")]
        public long? SaldoFinal { get; set; }

        public bool EstaAbierta { get; set; }

        [Required]
        [Display(Name = "Asignar usuario a una Caja")]
        public string UsuarioId { get; set; }

        public string MensajeError { get; set; }
        public bool Resultado { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Apertura de Caja" : "Nueva Apertura de Caja";
            }
        }

        public CajaAperturaCierreViewModel()
        {
            Fecha = DateTime.Now;
        }

        public CajaAperturaCierreViewModel(AperturaCierreCaja aperturaCierre)
        {
            Id = aperturaCierre.Id;
            CajaId = aperturaCierre.CajaId;
            Fecha = aperturaCierre.Fecha;
            SaldoInicial = aperturaCierre.SaldoInicial;
            EstaAbierta = aperturaCierre.EstaAbierta;
            UsuarioId = aperturaCierre.UsuarioId;
        }
    }
}