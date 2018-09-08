using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class VehiculoViewModel
    {
        #region Listas
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<Aseguradora> Aseguradoras { get; set; }
        public IEnumerable<Modelo> Modelos { get; set; }
        public IEnumerable<Combustible> Combustibles { get; set; }        
        #endregion

        #region Propiedades
        public int Id { get; set; }

        [Display(Name = "Matrícula")]
        [StringLength(6)]
        [Remote("MatriculaExisteEnVehiculos", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Matrícula ya existe.")]
        public string Matricula { get; set; }

        [Required]
        [StringLength(20)]
        [Remote("ChasisExisteEnVehiculos", "RemoteValidation", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Chasis ya existe.")]
        public string Chasis { get; set; }

        [Display(Name = "Odómetro (Km.)")]
        public float? Kilometro { get; set; }

        [Display(Name = "Fecha de Fabricación")]
        public DateTime FechaDeFabricacion { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        [Display(Name = "Modelo")]
        public byte ModeloId { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Combustible")]
        public byte CombustibleId { get; set; }

        [Display(Name = "Aseguradora")]
        public byte? AseguradoraCodigo { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Vehículo" : "Nuevo Vehículo";
            }
        }
        #endregion

        #region Constructores
        public VehiculoViewModel()
        {
            Id = 0;
        }

        public VehiculoViewModel(Vehiculo vehiculo)
        {
            Id = vehiculo.Id;
            Matricula = vehiculo.Matricula;
            Chasis = vehiculo.Chasis;
            Kilometro = vehiculo.Kilometro;
            Color = vehiculo.Color;
            ModeloId = vehiculo.ModeloId;
            ClienteId = vehiculo.ClienteId;
            CombustibleId = vehiculo.CombustibleId;
            FechaDeFabricacion = vehiculo.FechaDeFabricacion;
            AseguradoraCodigo = vehiculo.Aseguradora == null ? (byte)0 : vehiculo.Aseguradora.Id;
        }
        #endregion
    }
}